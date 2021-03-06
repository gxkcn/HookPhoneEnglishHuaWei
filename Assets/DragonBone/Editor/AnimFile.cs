using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Animations;
using System.IO;
using CurveExtended;

namespace DragonBone
{
	/// <summary>
	/// generate Animation file
	/// author:  bingheliefeng
	/// </summary>
	public class AnimFile {

		private static Dictionary<string,string> slotPathKV = null;
		private static int tempZNumber = 0;

		public static void CreateAnimFile(ArmatureEditor armatureEditor)
		{
			slotPathKV = new Dictionary<string, string>();
			tempZNumber = 0;

			string path = AssetDatabase.GetAssetPath(armatureEditor.animTextAsset);
			path = path.Substring(0,path.LastIndexOf('/'))+"/"+armatureEditor.armature.name+"_Anims";
			if(!AssetDatabase.IsValidFolder(path)){
				Directory.CreateDirectory(path);
			}
			path+="/";

			Animator animator= armatureEditor.armature.gameObject.AddComponent<Animator>();
			AnimatorController controller = AssetDatabase.LoadAssetAtPath<AnimatorController>(path+armatureEditor.armature.name+".controller");
			AnimatorStateMachine rootStateMachine = null;
			if(controller==null){
				controller = AnimatorController.CreateAnimatorControllerAtPath(path+armatureEditor.armature.name+".controller");
				rootStateMachine = controller.layers[0].stateMachine;
			}
			animator.runtimeAnimatorController = controller;
			if(armatureEditor.armatureData.animDatas!=null)
			{
				int len = armatureEditor.armatureData.animDatas.Length;
				for(int i=0;i<len ;++i)
				{
					DragonBoneData.AnimationData animationData = armatureEditor.armatureData.animDatas[i];
					string clipPath = path+ animationData.name+".anim";
					AnimationClip clip = AssetDatabase.LoadAssetAtPath<AnimationClip>(clipPath);
					if(clip==null){
						clip = new AnimationClip();
						AssetDatabase.CreateAsset(clip,clipPath);
					}else{
						clip.ClearCurves();
					}
					clip.name = animationData.name;
					clip.frameRate = armatureEditor.armatureData.frameRate;

					CreateSlotAnim(armatureEditor ,clip,animationData.slotDatas , armatureEditor.slotsKV,animationData.duration );
					bool success = CreateBoneAnim(armatureEditor ,clip,animationData.boneDatas , armatureEditor.bonesKV,animationData.duration);
					if(!success){
						return;
					}

					CreateFFDAnim(armatureEditor ,clip,animationData.ffdDatas , armatureEditor.slotsKV);
					CreateAnimZOrder	(armatureEditor,clip,animationData.zOrderDatas);
					SetEvent(armatureEditor,clip,animationData.keyDatas);

					SerializedObject serializedClip = new SerializedObject(clip);
					AnimationClipSettings clipSettings = new AnimationClipSettings(serializedClip.FindProperty("m_AnimationClipSettings"));
					clipSettings.loopTime = animationData.playTimes==0;
					serializedClip.ApplyModifiedProperties();

					if(rootStateMachine!=null){
						AnimatorState state = rootStateMachine.AddState(clip.name);
						state.motion = clip;
					}
				}
				AssetDatabase.SaveAssets();
			}
			if(rootStateMachine!=null && rootStateMachine.states!=null && rootStateMachine.states.Length>0){
				rootStateMachine.defaultState= rootStateMachine.states[0].state;
			}

			//createAvatar
			if(armatureEditor.createAvatar)
				CreateAvatar(armatureEditor,animator,path);
		}

		static void CreateAvatar( ArmatureEditor armatureEditor,Animator animator,string path){
			Avatar avatar = AvatarBuilder.BuildGenericAvatar(armatureEditor.armature.gameObject,"");
			animator.avatar = avatar;
			AvatarMask avatarMask = new AvatarMask();
			string[] transofrmPaths = GetTransformPaths(armatureEditor);
			avatarMask.transformCount = transofrmPaths.Length;
			for (int i=0; i< transofrmPaths.Length; i++){
				avatarMask.SetTransformPath(i, transofrmPaths[i]);
				avatarMask.SetTransformActive(i, true);
			}
			AssetDatabase.CreateAsset(avatar    , path + "/" + armatureEditor.armature.name + "Avatar.asset");
			AssetDatabase.CreateAsset(avatarMask, path + "/" + armatureEditor.armature.name + "Mask.asset");
			AssetDatabase.SaveAssets();
		}

		static string[] GetTransformPaths(ArmatureEditor armatureEditor ){
			List<string> result = new List<string>();
			result.Add("");
			foreach(Transform t in armatureEditor.bones){
				string path = AnimationUtility.CalculateTransformPath(t,armatureEditor.armature);
				result.Add(path);
			}
			return result.ToArray();
		}


		static TangentMode GetPrevFrameTangentMode(float easingTween,float[] curves){
			if(curves!=null && curves.Length>0) return TangentMode.Editable;

			if(easingTween==float.PositiveInfinity){
				return TangentMode.Stepped;
			}
			else if(easingTween==0){
				return TangentMode.Linear;
			}else if(easingTween==1){
				return TangentMode.Linear;
			}else if(easingTween==2){
				return TangentMode.Smooth;
			}
			return TangentMode.Linear;
		}


		static void CreateAnimZOrder(ArmatureEditor armatureEditor, AnimationClip clip , DragonBoneData.AnimSubData[] subDatas)
		{
			if(subDatas==null) return;
			int len = subDatas.Length;
			AnimationCurve armatureCurve = new AnimationCurve();
			float perKeyTime = 1f/armatureEditor.armatureData.frameRate;
			for(int i=0;i<len;++i){
				DragonBoneData.AnimSubData animSubData = subDatas[i];
				float during = animSubData.offset;

				Dictionary<string ,AnimationCurve> slotZOrderKV = new Dictionary<string, AnimationCurve>();

				DragonBoneData.AnimFrameData[] frameDatas = animSubData.frameDatas;
				for(int j=0;j<frameDatas.Length;++j){
					DragonBoneData.AnimFrameData frameData = frameDatas[j]; 
					if(frameData.zOrder!=null && frameData.zOrder.Length>0)
					{
						for(int z=0;z<frameData.zOrder.Length;z+=2){
							int slotIdx = frameData.zOrder[z];
							int changeZ = frameData.zOrder[z+1];

							Slot slot = armatureEditor.slots[slotIdx];

							int temp = slotIdx+changeZ;
							if(temp<0) changeZ = -temp;

							string path = "";
							if(slotPathKV.ContainsKey(slot.name)){
								path = slotPathKV[slot.name];
							}else{
								path = GetNodeRelativePath(armatureEditor,slot.transform) ;
								slotPathKV[slot.name] = path;
							}

							AnimationCurve curve = null;
							if(slotZOrderKV.ContainsKey(slot.name)){
								curve = slotZOrderKV[slot.name];
							}else{
								curve = new AnimationCurve();
								slotZOrderKV[slot.name] = curve;
							}
							if(curve.length==0 && during>0){
								//first key
								curve.AddKey( new Keyframe(0,0,float.PositiveInfinity,float.PositiveInfinity));
							}
							if(frameDatas.Length==j+1){
								//last
								curve.AddKey( new Keyframe(during+frameData.duration*perKeyTime,changeZ,float.PositiveInfinity,float.PositiveInfinity));
							}
							curve.AddKey( new Keyframe(during,changeZ,float.PositiveInfinity,float.PositiveInfinity));

							//set Armature zorder invalid
//							++tempZNumber;
//							armatureCurve.AddKey(new Keyframe(during,tempZNumber,float.PositiveInfinity,float.PositiveInfinity));
						}
						for(int z=0;z<armatureEditor.slots.Count;++z){
							bool flag = true;
							for(int t=0;t<frameData.zOrder.Length;t+=2){
								int slotIdx = frameData.zOrder[t];
								if(z==slotIdx){
									flag = false;
									break;
								}
							}
							if(flag)
							{
								Slot slot = armatureEditor.slots[z];
								string path = "";
								if(slotPathKV.ContainsKey(slot.name)){
									path = slotPathKV[slot.name];
								}else{
									path = GetNodeRelativePath(armatureEditor,slot.transform) ;
									slotPathKV[slot.name] = path;
								}

								AnimationCurve curve = null;
								if(slotZOrderKV.ContainsKey(slot.name)){
									curve = slotZOrderKV[slot.name];
									curve.AddKey( new Keyframe(during,0,float.PositiveInfinity,float.PositiveInfinity));
								}
							}
						}
					}
					else
					{
						for(int z=0;z<armatureEditor.slots.Count;++z){
							Slot slot = armatureEditor.slots[z];
							string path = "";
							if(slotPathKV.ContainsKey(slot.name)){
								path = slotPathKV[slot.name];
							}else{
								path = GetNodeRelativePath(armatureEditor,slot.transform) ;
								slotPathKV[slot.name] = path;
							}

							AnimationCurve curve = null;
							if(slotZOrderKV.ContainsKey(slot.name)){
								curve = slotZOrderKV[slot.name];
							}else{
								curve = new AnimationCurve();
								slotZOrderKV[slot.name] = curve;
							}
							curve.AddKey( new Keyframe(during,0,float.PositiveInfinity,float.PositiveInfinity));
						}
						//set Armature zorder invalid
						++tempZNumber;
						armatureCurve.AddKey(new Keyframe(during,tempZNumber,float.PositiveInfinity,float.PositiveInfinity));
					}
					during+= frameData.duration*perKeyTime;
				}
				foreach(string name in slotZOrderKV.Keys)
				{
					AnimationCurve zOrderCurve = slotZOrderKV[name];
					CurveExtension.OptimizesCurve(zOrderCurve);
					if(zOrderCurve!=null && zOrderCurve.keys!=null && zOrderCurve.keys.Length>0 && CheckCurveValid(zOrderCurve,0)){
						clip.SetCurve(slotPathKV[name],typeof(Slot),"m_z",zOrderCurve);
					}
				}
				if(armatureCurve.keys.Length>0){
					clip.SetCurve("",typeof(DragonBoneArmature),"m_ZOrderValid",armatureCurve);
				}
			}
		}

		static void CreateFFDAnim(ArmatureEditor armatureEditor, AnimationClip clip , DragonBoneData.AnimSubData[] subDatas , Dictionary<string,Transform> transformKV)
		{
			if(subDatas==null) return;
			for(int i=0;i<subDatas.Length;++i)
			{
				DragonBoneData.AnimSubData animSubData = subDatas[i];
				string slotName = string.IsNullOrEmpty(animSubData.slot) ? animSubData.name : animSubData.slot;
				Transform slotNode = transformKV[slotName];

				List<AnimationCurve[]> vertexcurvexArray = null;
				List<AnimationCurve[]> vertexcurveyArray = null;
				if(slotNode.childCount>0){
					vertexcurvexArray = new List<AnimationCurve[]>();
					vertexcurveyArray = new List<AnimationCurve[]>();
					for(int j=0;j<slotNode.childCount;++j){
						Transform ffdNode = slotNode.GetChild(j);
						AnimationCurve[] vertex_xcurves = new AnimationCurve[ffdNode.childCount];
						AnimationCurve[] vertex_ycurves = new AnimationCurve[ffdNode.childCount];
						for(int r=0;r<vertex_xcurves.Length;++r){
							vertex_xcurves[r] = new AnimationCurve();
							vertex_ycurves[r] = new AnimationCurve();
						}
						vertexcurvexArray.Add(vertex_xcurves);
						vertexcurveyArray.Add(vertex_ycurves);
					}
				}

				float during = animSubData.offset;
				float perKeyTime = 1f/armatureEditor.armatureData.frameRate;
				bool isHaveCurve = false;
				for(int j=0;j<animSubData.frameDatas.Length;++j)
				{
					DragonBoneData.AnimFrameData frameData = animSubData.frameDatas[j];

					float prevTweeneasing = float.PositiveInfinity;//前一帧的tweenEasing
					float[] prevCurves = null;
					if(j>0) {
						prevTweeneasing = animSubData.frameDatas[j-1].tweenEasing;
						prevCurves = animSubData.frameDatas[j-1].curve;
					}
					TangentMode tanModeL = GetPrevFrameTangentMode(prevTweeneasing,prevCurves);
					TangentMode tanModeR = TangentMode.Linear;

					if(frameData.curve!=null && frameData.curve.Length>0){
						tanModeR = TangentMode.Editable;
						isHaveCurve = true;
					}else{
						if(frameData.tweenEasing==float.PositiveInfinity){
							tanModeR = TangentMode.Stepped;
						}
						else if(frameData.tweenEasing==0){
							tanModeR = TangentMode.Linear;
						}else if(frameData.tweenEasing==1){
							tanModeR = TangentMode.Smooth;
						}else if(frameData.tweenEasing==2){
							tanModeR = TangentMode.Linear;
						}
					}

					//mesh animation
					if(vertexcurvexArray!=null){
						for(int k=0;k<vertexcurvexArray.Count;++k)
						{
							Transform ffdNode = slotNode.GetChild(k);
							if(ffdNode.name==animSubData.name){
								AnimationCurve[] vertex_xcurves = vertexcurvexArray[k];
								AnimationCurve[] vertex_ycurves = vertexcurveyArray[k];
								int len = ffdNode.childCount;
								if(frameData.vertices!=null && frameData.vertices.Length>0)
								{
									for(int r =0;r<len;++r){
										AnimationCurve vertex_xcurve = vertex_xcurves[r];
										AnimationCurve vertex_ycurve = vertex_ycurves[r];
										Transform vCtr = ffdNode.GetChild(r);//顶点控制点
										if(r>=frameData.offset && r-frameData.offset<frameData.vertices.Length){
											Keyframe kfx = KeyframeUtil.GetNew(during,vCtr.localPosition.x+frameData.vertices[r-frameData.offset].x,tanModeL,tanModeR);
											vertex_xcurve.AddKey(kfx);
											Keyframe kfy = KeyframeUtil.GetNew(during,vCtr.localPosition.y+frameData.vertices[r-frameData.offset].y,tanModeL,tanModeR);
											vertex_ycurve.AddKey(kfy);
										}
										else
										{
											Keyframe kfx = KeyframeUtil.GetNew(during,vCtr.localPosition.x,tanModeL,tanModeR);
											vertex_xcurve.AddKey(kfx);
											Keyframe kfy = KeyframeUtil.GetNew(during,vCtr.localPosition.y,tanModeL,tanModeR);
											vertex_ycurve.AddKey(kfy);
										}
									}
								}
								else
								{
									//add default vertex position
									for(int r =0;r<len;++r){
										AnimationCurve vertex_xcurve = vertex_xcurves[r];
										AnimationCurve vertex_ycurve = vertex_ycurves[r];
										Transform vCtr = slotNode.GetChild(k).GetChild(r);//顶点控制点
										Keyframe kfx = KeyframeUtil.GetNew(during,vCtr.localPosition.x,tanModeL,tanModeR);
										vertex_xcurve.AddKey(kfx);
										Keyframe kfy = KeyframeUtil.GetNew(during,vCtr.localPosition.y,tanModeL,tanModeR);
										vertex_ycurve.AddKey(kfy);
									}
								}
							}
						}

					}

					during+= frameData.duration*perKeyTime;
				}

				string path = "";
				if(slotPathKV.ContainsKey(slotName)){
					path= slotPathKV[slotName];
				}else{
					path = GetNodeRelativePath(armatureEditor,slotNode) ;
					slotPathKV[slotName] = path;
				}

				if(vertexcurvexArray!=null)
				{
					for(int k=0;k<vertexcurvexArray.Count;++k){
						Transform ffdNode = slotNode.GetChild(k);
						if(ffdNode.name==animSubData.name){
							AnimationCurve[] vertex_xcurves= vertexcurvexArray[k];
							AnimationCurve[] vertex_ycurves= vertexcurveyArray[k];
							for(int r=0;r<vertex_xcurves.Length;++r){
								AnimationCurve vertex_xcurve = vertex_xcurves[r];
								AnimationCurve vertex_ycurve = vertex_ycurves[r];
								Transform v = ffdNode.GetChild(r);
								string ctrlPath = path+"/"+ffdNode.name+"/"+v.name;

								CurveExtension.OptimizesCurve(vertex_xcurve);
								CurveExtension.OptimizesCurve(vertex_ycurve);

								bool vcurveFlag = false;
								if(vertex_xcurve.keys !=null&& vertex_xcurve.keys.Length>0&& CheckCurveValid(vertex_xcurve,v.localPosition.x)) vcurveFlag = true;
								if(vertex_ycurve.keys !=null&& vertex_ycurve.keys.Length>0&& CheckCurveValid(vertex_ycurve,v.localPosition.y)) vcurveFlag=  true;
								if(vcurveFlag){
									if(isHaveCurve) SetCustomCurveTangents(vertex_xcurve,animSubData.frameDatas);
									CurveExtension.UpdateAllLinearTangents(vertex_xcurve);
									AnimationUtility.SetEditorCurve( clip, EditorCurveBinding.FloatCurve( ctrlPath, typeof( Transform ), "m_LocalPosition.x" ), vertex_xcurve );
									if(isHaveCurve) SetCustomCurveTangents(vertex_ycurve,animSubData.frameDatas);
									CurveExtension.UpdateAllLinearTangents(vertex_ycurve);
									AnimationUtility.SetEditorCurve( clip, EditorCurveBinding.FloatCurve( ctrlPath, typeof( Transform ), "m_LocalPosition.y" ), vertex_ycurve );
								}
							}
						}
					}

				}
			}
		}


		static bool CreateBoneAnim(ArmatureEditor armatureEditor, AnimationClip clip , DragonBoneData.AnimSubData[] subDatas , Dictionary<string,Transform> transformKV, int totalFrame)
		{
			if(subDatas==null) return true;
			Dictionary<string,string> bonePathKV = new Dictionary<string, string>();

			for(int i=0;i<subDatas.Length;++i)
			{
				DragonBoneData.AnimSubData animSubData = subDatas[i];
				if(animSubData.frameDatas!=null){
					CreateBoneAnimFrames(armatureEditor,bonePathKV,clip,animSubData,transformKV,totalFrame);
				}
				if(animSubData.translateFrameDatas!=null){
					CreateBoneAnimTranslate(armatureEditor,bonePathKV,clip,animSubData,transformKV,totalFrame);
				}
				if(animSubData.scaleFrameDatas!=null){
					CreateBoneAnimScale(armatureEditor,bonePathKV,clip,animSubData,transformKV,totalFrame);
				}
				if(animSubData.rotateFrameDatas!=null){
					CreateBoneAnimRotate(armatureEditor,bonePathKV,clip,animSubData,transformKV,totalFrame);
				}
			}
			return true;
		}

		static bool CreateBoneAnimFrames(ArmatureEditor armatureEditor,Dictionary<string,string> bonePathKV, AnimationClip clip , DragonBoneData.AnimSubData animSubData , Dictionary<string,Transform> transformKV,int totalFrame)
		{
			string boneName = animSubData.name;
			Transform boneNode = transformKV[boneName];
			DragonBoneData.TransformData defaultTransformData = armatureEditor.bonesDataKV[animSubData.name].transform;

			AnimationCurve xcurve = new AnimationCurve();
			AnimationCurve ycurve = new AnimationCurve();
			AnimationCurve sxcurve = new AnimationCurve();
			AnimationCurve sycurve = new AnimationCurve();
			AnimationCurve rotatecurve = new AnimationCurve();
			bool rotateCicle = false;

			float during = animSubData.offset;
			float perKeyTime = 1f/armatureEditor.armatureData.frameRate;
			bool isHaveCurve = false;
			for(int j=0;j<animSubData.frameDatas.Length;++j)
			{
				DragonBoneData.AnimFrameData frameData = animSubData.frameDatas[j];

				float prevTweeneasing = float.PositiveInfinity;//前一帧的tweenEasing
				float[] prevCurves = null;
				if(j>0) {
					prevTweeneasing = animSubData.frameDatas[j-1].tweenEasing;
					prevCurves = animSubData.frameDatas[j-1].curve;
				}
				TangentMode tanModeL = GetPrevFrameTangentMode(prevTweeneasing,prevCurves);
				TangentMode tanModeR = TangentMode.Linear;

				if(frameData.curve!=null && frameData.curve.Length>0){
					tanModeR = TangentMode.Editable;
					isHaveCurve = true;
				}else{
					if(frameData.tweenEasing==float.PositiveInfinity){
						tanModeR = TangentMode.Stepped;
					}
					else if(frameData.tweenEasing==0){
						tanModeR = TangentMode.Linear;
					}else if(frameData.tweenEasing==1){
						tanModeR = TangentMode.Smooth;
					}else if(frameData.tweenEasing==2){
						tanModeR = TangentMode.Linear;
					}
				}
				if(frameData.transformData!=null){
					if(!float.IsNaN(frameData.transformData.x)) {
						if(!float.IsNaN(defaultTransformData.x)){
							xcurve.AddKey(KeyframeUtil.GetNew(during,frameData.transformData.x+defaultTransformData.x,tanModeL,tanModeR));
						}else {
							xcurve.AddKey(KeyframeUtil.GetNew(during,frameData.transformData.x,tanModeL,tanModeR));
						}
					}
					else if(!float.IsNaN(defaultTransformData.x)){
						xcurve.AddKey(KeyframeUtil.GetNew(during,defaultTransformData.x,tanModeL,tanModeR));
					}

					if(!float.IsNaN(frameData.transformData.y)) {
						if(!float.IsNaN(defaultTransformData.y)) {
							ycurve.AddKey(KeyframeUtil.GetNew(during,frameData.transformData.y+defaultTransformData.y,tanModeL,tanModeR));
						}else {
							ycurve.AddKey(KeyframeUtil.GetNew(during,frameData.transformData.y,tanModeL,tanModeR));
						}
					}
					else if(!float.IsNaN(defaultTransformData.y))
					{
						ycurve.AddKey(KeyframeUtil.GetNew(during,defaultTransformData.y,tanModeL,tanModeR));
					}

					float rotate = 0;
					if(!float.IsNaN(frameData.transformData.rotate)) {
						rotate = frameData.transformData.rotate+defaultTransformData.rotate;
						rotatecurve.AddKey(KeyframeUtil.GetNew(during,rotate,tanModeL,tanModeR));
						if(j>0){
							DragonBoneData.AnimFrameData prevFrameData = animSubData.frameDatas[j-1];
							float frameDeltaTime = during+frameData.duration*perKeyTime - rotatecurve.keys[j-1].time;
							if(prevFrameData.tweenRotate!=0 && frameDeltaTime>perKeyTime){
								int tweenRotate = prevFrameData.tweenRotate;
								if (tweenRotate > 0 ? -frameData.transformData.rotate >= -prevFrameData.transformData.rotate : -frameData.transformData.rotate <= -prevFrameData.transformData.rotate)
								{
									tweenRotate = tweenRotate > 0 ? tweenRotate - 1 : tweenRotate + 1;
								}
								float endRotate = frameData.transformData.rotate - 360f * tweenRotate;
								float deltaRotate = (endRotate-prevFrameData.transformData.rotate)/(frameDeltaTime/perKeyTime);
								endRotate -= deltaRotate;
								//insert keyframe
								rotatecurve.AddKey(KeyframeUtil.GetNew(during-perKeyTime,endRotate+defaultTransformData.rotate,tanModeL,TangentMode.Stepped));
								rotateCicle = true;
							}
						}
					}
					else if(!float.IsNaN(defaultTransformData.rotate)){
						rotatecurve.AddKey(KeyframeUtil.GetNew(during,boneNode.localEulerAngles.z,tanModeL,tanModeR));
					}

					if(!float.IsNaN(frameData.transformData.scx)){
						sxcurve.AddKey(KeyframeUtil.GetNew(during,frameData.transformData.scx*defaultTransformData.scx,tanModeL,tanModeR));
					}
					else{
						sxcurve.AddKey(KeyframeUtil.GetNew(during,boneNode.localScale.x,tanModeL,tanModeR));
					}

					if(!float.IsNaN(frameData.transformData.scy)) {
						sycurve.AddKey(KeyframeUtil.GetNew(during,frameData.transformData.scy*defaultTransformData.scy,tanModeL,tanModeR));
					}
					else {
						sycurve.AddKey(KeyframeUtil.GetNew(during,boneNode.localScale.y,tanModeL,tanModeR));
					}

				}
				during+= frameData.duration*perKeyTime;
			}

			CurveExtension.OptimizesCurve(xcurve);
			CurveExtension.OptimizesCurve(ycurve);
			CurveExtension.OptimizesCurve(sxcurve);
			CurveExtension.OptimizesCurve(sycurve);
			CurveExtension.OptimizesCurve(rotatecurve);

			string path = "";
			if(bonePathKV.ContainsKey(boneName)){
				path = bonePathKV[boneName];
			}else{
				path = GetNodeRelativePath(armatureEditor,boneNode) ;
				bonePathKV[boneName] = path;
				if(slotPathKV.ContainsKey(boneName) && slotPathKV[boneName].Equals(path)){
					Debug.LogError("Bone2D Error: Name conflict ->"+path);
					return false;
				}
			}
			bool localPosFlag = false;
			if(xcurve.keys !=null && xcurve.keys.Length>0 && CheckCurveValid(xcurve,boneNode.localPosition.x)) localPosFlag = true;
			if(ycurve.keys !=null && ycurve.keys.Length>0 && CheckCurveValid(ycurve,boneNode.localPosition.y))  localPosFlag = true;
			if(localPosFlag){
				if(isHaveCurve) SetCustomCurveTangents(xcurve,animSubData.frameDatas);
				CurveExtension.UpdateAllLinearTangents(xcurve);
				AnimationUtility.SetEditorCurve( clip, EditorCurveBinding.FloatCurve( path, typeof( Transform ), "m_LocalPosition.x" ), xcurve );
				if(isHaveCurve) SetCustomCurveTangents(ycurve,animSubData.frameDatas);
				CurveExtension.UpdateAllLinearTangents(ycurve);
				AnimationUtility.SetEditorCurve( clip, EditorCurveBinding.FloatCurve( path, typeof( Transform ), "m_LocalPosition.y" ), ycurve );
			}

			bool localSc = false;
			if(sxcurve.keys !=null && sxcurve.keys.Length>0 && CheckCurveValid(sxcurve,defaultTransformData.scx)) localSc=true;
			if(sycurve.keys !=null && sycurve.keys.Length>0 && CheckCurveValid(sycurve,defaultTransformData.scy)) localSc=true;
			if(localSc){
				if(isHaveCurve) SetCustomCurveTangents(sxcurve,animSubData.frameDatas);
				CurveExtension.UpdateAllLinearTangents(sxcurve);
				AnimationUtility.SetEditorCurve( clip, EditorCurveBinding.FloatCurve( path, typeof( Transform ), "m_LocalScale.x" ), sxcurve );
				if(isHaveCurve) SetCustomCurveTangents(sycurve,animSubData.frameDatas);
				CurveExtension.UpdateAllLinearTangents(sycurve);
				AnimationUtility.SetEditorCurve( clip, EditorCurveBinding.FloatCurve( path, typeof( Transform ), "m_LocalScale.y" ), sycurve );
			}

			if(rotatecurve.keys !=null && rotatecurve.keys.Length>0 && CheckCurveValid(rotatecurve,defaultTransformData.rotate)){
				CurveExtension.ClampCurveRotate360(rotatecurve,rotateCicle);
				if(isHaveCurve) SetCustomRotateCurveTangents(rotatecurve,animSubData.frameDatas);
				CurveExtension.UpdateAllLinearTangents(rotatecurve);
				clip.SetCurve(path,typeof(Transform),"localEulerAngles.z",rotatecurve);
			}
			return true;
		}

		//for 5.5
		static bool CreateBoneAnimRotate(ArmatureEditor armatureEditor,Dictionary<string,string> bonePathKV, AnimationClip clip , DragonBoneData.AnimSubData animSubData , Dictionary<string,Transform> transformKV,int totalFrame)
		{
			string boneName = animSubData.name;
			Transform boneNode = transformKV[boneName];
			DragonBoneData.TransformData defaultTransformData = armatureEditor.bonesDataKV[animSubData.name].transform;

			AnimationCurve rotatecurve = new AnimationCurve();
			bool rotateCicle = false;

			float during = animSubData.offset;
			float perKeyTime = 1f/armatureEditor.armatureData.frameRate;
			bool isHaveCurve = false;
			for(int j=0;j<animSubData.rotateFrameDatas.Length;++j)
			{
				DragonBoneData.AnimFrameData frameData = animSubData.rotateFrameDatas[j];

				float prevTweeneasing = float.PositiveInfinity;//前一帧的tweenEasing
				float[] prevCurves = null;
				if(j>0) {
					prevTweeneasing = animSubData.rotateFrameDatas[j-1].tweenEasing;
					prevCurves = animSubData.rotateFrameDatas[j-1].curve;
				}
				TangentMode tanModeL = GetPrevFrameTangentMode(prevTweeneasing,prevCurves);
				TangentMode tanModeR = TangentMode.Linear;

				if(frameData.curve!=null && frameData.curve.Length>0){
					tanModeR = TangentMode.Editable;
					isHaveCurve = true;
				}else{
					if(frameData.tweenEasing==float.PositiveInfinity){
						tanModeR = TangentMode.Stepped;
					}
					else if(frameData.tweenEasing==0){
						tanModeR = TangentMode.Linear;
					}else if(frameData.tweenEasing==1){
						tanModeR = TangentMode.Smooth;
					}else if(frameData.tweenEasing==2){
						tanModeR = TangentMode.Linear;
					}
				}
				if(frameData.transformData!=null){
					float rotate = 0;
					if(!float.IsNaN(frameData.transformData.rotate)) {
						rotate = frameData.transformData.rotate+defaultTransformData.rotate;
						rotatecurve.AddKey(KeyframeUtil.GetNew(during,rotate,tanModeL,tanModeR));
						if(j>0){
							DragonBoneData.AnimFrameData prevFrameData = animSubData.rotateFrameDatas[j-1];
							float frameDeltaTime = during+frameData.duration*perKeyTime - rotatecurve.keys[j-1].time;
							if(prevFrameData.tweenRotate!=0 && frameDeltaTime>perKeyTime){
								int tweenRotate = prevFrameData.tweenRotate;
								if (tweenRotate > 0 ? -frameData.transformData.rotate >= -prevFrameData.transformData.rotate : -frameData.transformData.rotate <= -prevFrameData.transformData.rotate)
								{
									tweenRotate = tweenRotate > 0 ? tweenRotate - 1 : tweenRotate + 1;
								}
								float endRotate = frameData.transformData.rotate - 360f * tweenRotate;
								float deltaRotate = (endRotate-prevFrameData.transformData.rotate)/(frameDeltaTime/perKeyTime);
								endRotate -= deltaRotate;
								//insert keyframe
								rotatecurve.AddKey(KeyframeUtil.GetNew(during-perKeyTime,endRotate+defaultTransformData.rotate,tanModeL,TangentMode.Stepped));
								rotateCicle = true;
							}
						}
					}
					else if(!float.IsNaN(defaultTransformData.rotate)){
						rotatecurve.AddKey(KeyframeUtil.GetNew(during,boneNode.localEulerAngles.z,tanModeL,tanModeR));
					}

				}else {
					rotatecurve.AddKey (KeyframeUtil.GetNew (during, boneNode.localEulerAngles.z, tanModeL, tanModeR));
				}

				if (frameData.duration > 0) {
					during += frameData.duration * perKeyTime;
				} else {
					frameData = animSubData.rotateFrameDatas [j + 1];
					if (during == totalFrame) {
						//之前已经是最后一帧
						Keyframe kf = rotatecurve.keys[rotatecurve.length-1];
						if (frameData.transformData != null) {
							if (!float.IsNaN (frameData.transformData.rotate)) {
								kf.value = frameData.transformData.rotate + defaultTransformData.rotate;
							} else {
								kf.value = defaultTransformData.rotate;
							}
						} else {
							kf.value = defaultTransformData.rotate;
						}
						rotatecurve.keys [rotatecurve.length - 1] = kf;

					} else {
						//最后一帧
						rotatecurve.AddKey(KeyframeUtil.GetNew(perKeyTime*totalFrame,defaultTransformData.rotate,tanModeL,TangentMode.Stepped));
					}
					break;
				}
			}
			CurveExtension.OptimizesCurve(rotatecurve);

			string path = "";
			if(bonePathKV.ContainsKey(boneName)){
				path = bonePathKV[boneName];
			}else{
				path = GetNodeRelativePath(armatureEditor,boneNode) ;
				bonePathKV[boneName] = path;
				if(slotPathKV.ContainsKey(boneName) && slotPathKV[boneName].Equals(path)){
					Debug.LogError("Bone2D Error: Name conflict ->"+path);
					return false;
				}
			}
			if(rotatecurve.keys !=null && rotatecurve.keys.Length>0 && CheckCurveValid(rotatecurve,defaultTransformData.rotate)){
				CurveExtension.ClampCurveRotate360(rotatecurve,rotateCicle);
				if(isHaveCurve) SetCustomRotateCurveTangents(rotatecurve,animSubData.rotateFrameDatas);
				CurveExtension.UpdateAllLinearTangents(rotatecurve);
				clip.SetCurve(path,typeof(Transform),"localEulerAngles.z",rotatecurve);
			}
			return true;
		}

		//for 5.5
		static bool CreateBoneAnimTranslate(ArmatureEditor armatureEditor,Dictionary<string,string> bonePathKV, AnimationClip clip , DragonBoneData.AnimSubData animSubData , Dictionary<string,Transform> transformKV,int totalFrame)
		{
			string boneName = animSubData.name;
			Transform boneNode = transformKV[boneName];
			DragonBoneData.TransformData defaultTransformData = armatureEditor.bonesDataKV[animSubData.name].transform;

			AnimationCurve xcurve = new AnimationCurve();
			AnimationCurve ycurve = new AnimationCurve();

			float during = animSubData.offset;
			float perKeyTime = 1f/armatureEditor.armatureData.frameRate;
			bool isHaveCurve = false;
			for(int j=0;j<animSubData.translateFrameDatas.Length;++j)
			{
				DragonBoneData.AnimFrameData frameData = animSubData.translateFrameDatas[j];

				float prevTweeneasing = float.PositiveInfinity;//前一帧的tweenEasing
				float[] prevCurves = null;
				if(j>0) {
					prevTweeneasing = animSubData.translateFrameDatas[j-1].tweenEasing;
					prevCurves = animSubData.translateFrameDatas[j-1].curve;
				}
				TangentMode tanModeL = GetPrevFrameTangentMode(prevTweeneasing,prevCurves);
				TangentMode tanModeR = TangentMode.Linear;

				if(frameData.curve!=null && frameData.curve.Length>0){
					tanModeR = TangentMode.Editable;
					isHaveCurve = true;
				}else{
					if(frameData.tweenEasing==float.PositiveInfinity){
						tanModeR = TangentMode.Stepped;
					}
					else if(frameData.tweenEasing==0){
						tanModeR = TangentMode.Linear;
					}else if(frameData.tweenEasing==1){
						tanModeR = TangentMode.Smooth;
					}else if(frameData.tweenEasing==2){
						tanModeR = TangentMode.Linear;
					}
				}
				if(frameData.transformData!=null){
					if(!float.IsNaN(frameData.transformData.x)) {
						if(!float.IsNaN(defaultTransformData.x)){
							xcurve.AddKey(KeyframeUtil.GetNew(during,frameData.transformData.x+defaultTransformData.x,tanModeL,tanModeR));
						}else {
							xcurve.AddKey(KeyframeUtil.GetNew(during,frameData.transformData.x,tanModeL,tanModeR));
						}
					}
					else if(!float.IsNaN(defaultTransformData.x)){
						xcurve.AddKey(KeyframeUtil.GetNew(during,defaultTransformData.x,tanModeL,tanModeR));
					}

					if(!float.IsNaN(frameData.transformData.y)) {
						if(!float.IsNaN(defaultTransformData.y)) {
							ycurve.AddKey(KeyframeUtil.GetNew(during,frameData.transformData.y+defaultTransformData.y,tanModeL,tanModeR));
						}else {
							ycurve.AddKey(KeyframeUtil.GetNew(during,frameData.transformData.y,tanModeL,tanModeR));
						}
					}
					else if(!float.IsNaN(defaultTransformData.y))
					{
						ycurve.AddKey(KeyframeUtil.GetNew(during,defaultTransformData.y,tanModeL,tanModeR));
					}
				}
				else{
					xcurve.AddKey(KeyframeUtil.GetNew(during,defaultTransformData.x,tanModeL,tanModeR));
					ycurve.AddKey(KeyframeUtil.GetNew(during,defaultTransformData.y,tanModeL,tanModeR));
				}

				if (frameData.duration > 0) {
					during += frameData.duration * perKeyTime;
				} else {
					frameData = animSubData.translateFrameDatas [j + 1];
					if (during == totalFrame) {
						//之前已经是最后一帧
						Keyframe kf_x = xcurve.keys[xcurve.length-1];
						Keyframe kf_y = ycurve.keys[ycurve.length-1];
						if (frameData.transformData != null) {
							if (!float.IsNaN (frameData.transformData.x)) {
								kf_x.value = frameData.transformData.x+defaultTransformData.x;
							} else {
								kf_x.value = defaultTransformData.x;
							}

							if (!float.IsNaN (frameData.transformData.y)) {
								kf_y.value = frameData.transformData.y+defaultTransformData.y;
							} else {
								kf_y.value = defaultTransformData.y;
							}
						} else {
							kf_x.value = defaultTransformData.x;
							kf_y.value = defaultTransformData.y;
						}
						xcurve.keys [xcurve.length - 1] = kf_x;
						ycurve.keys [ycurve.length - 1] = kf_y;

					} else {
						//最后一帧
						xcurve.AddKey(KeyframeUtil.GetNew(perKeyTime*totalFrame,defaultTransformData.x,tanModeL,TangentMode.Stepped));
						ycurve.AddKey(KeyframeUtil.GetNew(perKeyTime*totalFrame,defaultTransformData.y,tanModeL,TangentMode.Stepped));
					}
					break;
				}
			}

			CurveExtension.OptimizesCurve(xcurve);
			CurveExtension.OptimizesCurve(ycurve);

			string path = "";
			if(bonePathKV.ContainsKey(boneName)){
				path = bonePathKV[boneName];
			}else{
				path = GetNodeRelativePath(armatureEditor,boneNode) ;
				bonePathKV[boneName] = path;
				if(slotPathKV.ContainsKey(boneName) && slotPathKV[boneName].Equals(path)){
					Debug.LogError("Bone2D Error: Name conflict ->"+path);
					return false;
				}
			}
			bool localPosFlag = false;
			if(xcurve.keys !=null && xcurve.keys.Length>0 && CheckCurveValid(xcurve,boneNode.localPosition.x)) localPosFlag = true;
			if(ycurve.keys !=null && ycurve.keys.Length>0 && CheckCurveValid(ycurve,boneNode.localPosition.y))  localPosFlag = true;
			if(localPosFlag){
				if(isHaveCurve) SetCustomCurveTangents(xcurve,animSubData.translateFrameDatas);
				CurveExtension.UpdateAllLinearTangents(xcurve);
				AnimationUtility.SetEditorCurve( clip, EditorCurveBinding.FloatCurve( path, typeof( Transform ), "m_LocalPosition.x" ), xcurve );
				if(isHaveCurve) SetCustomCurveTangents(ycurve,animSubData.translateFrameDatas);
				CurveExtension.UpdateAllLinearTangents(ycurve);
				AnimationUtility.SetEditorCurve( clip, EditorCurveBinding.FloatCurve( path, typeof( Transform ), "m_LocalPosition.y" ), ycurve );
			}
			return true;
		}

		static bool CreateBoneAnimScale(ArmatureEditor armatureEditor,Dictionary<string,string> bonePathKV, AnimationClip clip , DragonBoneData.AnimSubData animSubData , Dictionary<string,Transform> transformKV,int totalFrame)
		{
			string boneName = animSubData.name;
			Transform boneNode = transformKV[boneName];
			DragonBoneData.TransformData defaultTransformData = armatureEditor.bonesDataKV[animSubData.name].transform;

			AnimationCurve sxcurve = new AnimationCurve();
			AnimationCurve sycurve = new AnimationCurve();

			float during = animSubData.offset;
			float perKeyTime = 1f/armatureEditor.armatureData.frameRate;
			bool isHaveCurve = false;
			for(int j=0;j<animSubData.scaleFrameDatas.Length;++j)
			{
				DragonBoneData.AnimFrameData frameData = animSubData.scaleFrameDatas[j];

				float prevTweeneasing = float.PositiveInfinity;//前一帧的tweenEasing
				float[] prevCurves = null;
				if(j>0) {
					prevTweeneasing = animSubData.scaleFrameDatas[j-1].tweenEasing;
					prevCurves = animSubData.scaleFrameDatas[j-1].curve;
				}
				TangentMode tanModeL = GetPrevFrameTangentMode(prevTweeneasing,prevCurves);
				TangentMode tanModeR = TangentMode.Linear;

				if(frameData.curve!=null && frameData.curve.Length>0){
					tanModeR = TangentMode.Editable;
					isHaveCurve = true;
				}else{
					if(frameData.tweenEasing==float.PositiveInfinity){
						tanModeR = TangentMode.Stepped;
					}
					else if(frameData.tweenEasing==0){
						tanModeR = TangentMode.Linear;
					}else if(frameData.tweenEasing==1){
						tanModeR = TangentMode.Smooth;
					}else if(frameData.tweenEasing==2){
						tanModeR = TangentMode.Linear;
					}
				}
				if(frameData.transformData!=null){
					if(!float.IsNaN(frameData.transformData.scx)){
						sxcurve.AddKey(KeyframeUtil.GetNew(during,frameData.transformData.scx*defaultTransformData.scx,tanModeL,tanModeR));
					}
					else{
						sxcurve.AddKey(KeyframeUtil.GetNew(during,boneNode.localScale.x,tanModeL,tanModeR));
					}

					if(!float.IsNaN(frameData.transformData.scy)) {
						sycurve.AddKey(KeyframeUtil.GetNew(during,frameData.transformData.scy*defaultTransformData.scy,tanModeL,tanModeR));
					}
					else {
						sycurve.AddKey(KeyframeUtil.GetNew(during,boneNode.localScale.y,tanModeL,tanModeR));
					}
				}else{
					sxcurve.AddKey(KeyframeUtil.GetNew(during,boneNode.localScale.x,tanModeL,tanModeR));
					sycurve.AddKey(KeyframeUtil.GetNew(during,boneNode.localScale.y,tanModeL,tanModeR));
				}
				if (frameData.duration > 0) {
					during += frameData.duration * perKeyTime;
				} else {
					frameData = animSubData.scaleFrameDatas [j + 1];
					if (during == totalFrame) {
						//之前已经是最后一帧
						Keyframe kf_sx = sxcurve.keys[sxcurve.length-1];
						Keyframe kf_sy = sycurve.keys[sycurve.length-1];
						if (frameData.transformData != null) {
							if (!float.IsNaN (frameData.transformData.scx)) {
								kf_sx.value = frameData.transformData.scx*defaultTransformData.scx;
							} else {
								kf_sx.value = boneNode.localScale.x;
							}

							if (!float.IsNaN (frameData.transformData.scy)) {
								kf_sy.value = frameData.transformData.scy*defaultTransformData.scy;
							} else {
								kf_sy.value = boneNode.localScale.y;
							}
						} else {
							kf_sx.value = boneNode.localScale.x;
							kf_sy.value = boneNode.localScale.y;
						}
						sxcurve.keys [sxcurve.length - 1] = kf_sx;
						sycurve.keys [sycurve.length - 1] = kf_sy;

					} else {
						//最后一帧
						sxcurve.AddKey(KeyframeUtil.GetNew(perKeyTime*totalFrame,boneNode.localScale.x,tanModeL,TangentMode.Stepped));
						sycurve.AddKey(KeyframeUtil.GetNew(perKeyTime*totalFrame,boneNode.localScale.y,tanModeL,TangentMode.Stepped));
					}
					break;
				}
			}

			CurveExtension.OptimizesCurve(sxcurve);
			CurveExtension.OptimizesCurve(sycurve);

			string path = "";
			if(bonePathKV.ContainsKey(boneName)){
				path = bonePathKV[boneName];
			}else{
				path = GetNodeRelativePath(armatureEditor,boneNode) ;
				bonePathKV[boneName] = path;
				if(slotPathKV.ContainsKey(boneName) && slotPathKV[boneName].Equals(path)){
					Debug.LogError("Bone2D Error: Name conflict ->"+path);
					return false;
				}
			}
			bool localSc = false;
			if(sxcurve.keys !=null && sxcurve.keys.Length>0 && CheckCurveValid(sxcurve,defaultTransformData.scx)) localSc=true;
			if(sycurve.keys !=null && sycurve.keys.Length>0 && CheckCurveValid(sycurve,defaultTransformData.scy)) localSc=true;
			if(localSc){
				if(isHaveCurve) SetCustomCurveTangents(sxcurve,animSubData.scaleFrameDatas);
				CurveExtension.UpdateAllLinearTangents(sxcurve);
				AnimationUtility.SetEditorCurve( clip, EditorCurveBinding.FloatCurve( path, typeof( Transform ), "m_LocalScale.x" ), sxcurve );
				if(isHaveCurve) SetCustomCurveTangents(sycurve,animSubData.scaleFrameDatas);
				CurveExtension.UpdateAllLinearTangents(sycurve);
				AnimationUtility.SetEditorCurve( clip, EditorCurveBinding.FloatCurve( path, typeof( Transform ), "m_LocalScale.y" ), sycurve );
			}
			return true;
		}

		static void CreateSlotAnim(ArmatureEditor armatureEditor, AnimationClip clip , DragonBoneData.AnimSubData[] subDatas , Dictionary<string,Transform> transformKV, int totalFrame)
		{
			if(subDatas==null) return;
			for(int i=0;i<subDatas.Length;++i)
			{
				DragonBoneData.AnimSubData animSubData = subDatas[i];

				if(animSubData.frameDatas!=null){
					CreateSlotAnimFrames(armatureEditor, clip , animSubData , transformKV,totalFrame);
				}
				if(animSubData.colorFrameDatas!=null)
				{
					CreateSlotAnimColorFrames(armatureEditor, clip , animSubData , transformKV,totalFrame);
				}
				if(animSubData.displayFrameDatas!=null)
				{
					CreateSlotAnimDisplayFrames(armatureEditor, clip , animSubData , transformKV,totalFrame);
				}
			}
		}
		//for 5.5
		static void CreateSlotAnimDisplayFrames(ArmatureEditor armatureEditor, AnimationClip clip , DragonBoneData.AnimSubData animSubData , Dictionary<string,Transform> transformKV, int totalFrame)
		{
			string slotName = string.IsNullOrEmpty(animSubData.slot) ? animSubData.name : animSubData.slot;
			Transform slotNode = transformKV[slotName];

			AnimationCurve display_curve = new AnimationCurve();

			float during = animSubData.offset;
			float perKeyTime = 1f/armatureEditor.armatureData.frameRate;
			for(int j=0;j<animSubData.displayFrameDatas.Length;++j)
			{
				DragonBoneData.AnimFrameData frameData = animSubData.displayFrameDatas[j];

				//改displyindex
				if(frameData.displayIndex>-2)
					display_curve.AddKey(new Keyframe(during,frameData.displayIndex,float.PositiveInfinity,float.PositiveInfinity));

				if (frameData.duration > 0) {
					during += frameData.duration * perKeyTime;
				} else {
					frameData = animSubData.displayFrameDatas [j + 1];
					if (during == totalFrame) {
						//之前已经是最后一帧
						Keyframe kf = display_curve.keys[display_curve.length-1];
						if(frameData.displayIndex>-2){
							kf.value = frameData.displayIndex;
						} else {
							kf.value = slotNode.GetComponent<Slot>().displayIndex;
						}
						display_curve.keys [display_curve.length - 1] = kf;

					} else {
						//最后一帧
						display_curve.AddKey(new Keyframe(perKeyTime*totalFrame,slotNode.GetComponent<Slot>().displayIndex,float.PositiveInfinity,float.PositiveInfinity));
					}
					break;
				}
			}

			CurveExtension.OptimizesCurve(display_curve);

			string path="";
			if(slotPathKV.ContainsKey(slotName)){
				path = slotPathKV[slotName];
			}else{
				path = GetNodeRelativePath(armatureEditor,slotNode);
				slotPathKV[slotNode.name] = path;
			}

			if(display_curve.keys!=null && display_curve.keys.Length>0 && 
				CheckCurveValid(display_curve,slotNode.GetComponent<Slot>().displayIndex))
			{
				clip.SetCurve(path,typeof(Slot),"m_DisplayIndex",display_curve);
			}
		}

		//for 5.5
		static void CreateSlotAnimColorFrames(ArmatureEditor armatureEditor, AnimationClip clip , DragonBoneData.AnimSubData animSubData , Dictionary<string,Transform> transformKV, int totalFrame)
		{
			string slotName = string.IsNullOrEmpty(animSubData.slot) ? animSubData.name : animSubData.slot;
			Transform slotNode = transformKV[slotName];
			DragonBoneData.SlotData defaultSlotData = armatureEditor.slotsDataKV[slotName];
			DragonBoneData.ColorData defaultColorData = defaultSlotData.color ;

			AnimationCurve color_rcurve = new AnimationCurve();
			AnimationCurve color_gcurve = new AnimationCurve();
			AnimationCurve color_bcurve = new AnimationCurve();
			AnimationCurve color_acurve = new AnimationCurve();

			float during = animSubData.offset;
			float perKeyTime = 1f/armatureEditor.armatureData.frameRate;
			bool isHaveCurve = false;
			for(int j=0;j<animSubData.colorFrameDatas.Length;++j)
			{
				DragonBoneData.AnimFrameData frameData = animSubData.colorFrameDatas[j];

				float prevTweeneasing = float.PositiveInfinity;//前一帧的tweenEasing
				float[] prevCurves = null;
				if(j>0) {
					prevTweeneasing = animSubData.colorFrameDatas[j-1].tweenEasing;
					prevCurves = animSubData.colorFrameDatas[j-1].curve;
				}
				TangentMode tanModeL = GetPrevFrameTangentMode(prevTweeneasing,prevCurves);
				TangentMode tanModeR = TangentMode.Linear;

				if(frameData.curve!=null && frameData.curve.Length>0){
					tanModeR = TangentMode.Editable;
					isHaveCurve = true;
				}else{
					if(frameData.tweenEasing==float.PositiveInfinity){
						tanModeR = TangentMode.Stepped;
					}
					else if(frameData.tweenEasing==0){
						tanModeR = TangentMode.Linear;
					}else if(frameData.tweenEasing==1){
						tanModeR = TangentMode.Smooth;
					}else if(frameData.tweenEasing==2){
						tanModeR = TangentMode.Linear;
					}
				}

				if(frameData.color!=null){
					if(defaultColorData==null) defaultColorData = new DragonBoneData.ColorData();
					Color c = new Color(  
						frameData.color.rM+frameData.color.r0,
						frameData.color.gM+frameData.color.g0,
						frameData.color.bM+frameData.color.b0,
						frameData.color.aM+frameData.color.a0
					);
					color_rcurve.AddKey(KeyframeUtil.GetNew(during,c.r,tanModeL,tanModeR));
					color_gcurve.AddKey(KeyframeUtil.GetNew(during,c.g,tanModeL,tanModeR));
					color_bcurve.AddKey(KeyframeUtil.GetNew(during,c.b,tanModeL,tanModeR));
					color_acurve.AddKey(KeyframeUtil.GetNew(during,c.a,tanModeL,tanModeR));
				}
				else if(color_rcurve.length>0)
				{
					if(defaultColorData==null) defaultColorData = new DragonBoneData.ColorData();
					Color c = new Color();
					c.a = defaultColorData.aM+defaultColorData.a0;
					c.r = defaultColorData.rM+defaultColorData.r0;
					c.g = defaultColorData.gM+defaultColorData.g0;
					c.b = defaultColorData.bM+defaultColorData.b0;
					color_rcurve.AddKey(KeyframeUtil.GetNew(during,c.r,tanModeL,tanModeR));
					color_gcurve.AddKey(KeyframeUtil.GetNew(during,c.g,tanModeL,tanModeR));
					color_bcurve.AddKey(KeyframeUtil.GetNew(during,c.b,tanModeL,tanModeR));
					color_acurve.AddKey(KeyframeUtil.GetNew(during,c.a,tanModeL,tanModeR));
				}

				if (frameData.duration > 0) {
					during += frameData.duration * perKeyTime;
				} else {
					frameData = animSubData.colorFrameDatas [j + 1];
					if (during == totalFrame) {
						//之前已经是最后一帧
						Keyframe kf_r = color_rcurve.keys[color_rcurve.length-1];
						Keyframe kf_g = color_gcurve.keys[color_gcurve.length-1];
						Keyframe kf_b = color_bcurve.keys[color_bcurve.length-1];
						Keyframe kf_a = color_acurve.keys[color_acurve.length-1];
						if(frameData.color!=null){
							if(defaultColorData==null) defaultColorData = new DragonBoneData.ColorData();
							kf_r.value = frameData.color.rM+frameData.color.r0;
							kf_r.value = frameData.color.gM+frameData.color.g0;
							kf_r.value = frameData.color.bM+frameData.color.b0;
							kf_r.value = frameData.color.aM+frameData.color.a0;
						}
						else
						{
							if(defaultColorData==null) defaultColorData = new DragonBoneData.ColorData();
							kf_r.value = defaultColorData.aM+defaultColorData.a0;
							kf_g.value = defaultColorData.rM+defaultColorData.r0;
							kf_b.value = defaultColorData.gM+defaultColorData.g0;
							kf_a.value = defaultColorData.bM+defaultColorData.b0;
						}
						color_rcurve.keys [color_rcurve.length - 1] = kf_r;
						color_gcurve.keys [color_gcurve.length - 1] = kf_r;
						color_bcurve.keys [color_bcurve.length - 1] = kf_r;
						color_acurve.keys [color_acurve.length - 1] = kf_r;

					} else {
						//最后一帧
						if(defaultColorData==null) defaultColorData = new DragonBoneData.ColorData();
						Color c = new Color();
						c.a = defaultColorData.aM+defaultColorData.a0;
						c.r = defaultColorData.rM+defaultColorData.r0;
						c.g = defaultColorData.gM+defaultColorData.g0;
						c.b = defaultColorData.bM+defaultColorData.b0;
						color_rcurve.AddKey(KeyframeUtil.GetNew(perKeyTime*totalFrame,c.r,tanModeL,TangentMode.Stepped));
						color_gcurve.AddKey(KeyframeUtil.GetNew(perKeyTime*totalFrame,c.g,tanModeL,TangentMode.Stepped));
						color_bcurve.AddKey(KeyframeUtil.GetNew(perKeyTime*totalFrame,c.b,tanModeL,TangentMode.Stepped));
						color_acurve.AddKey(KeyframeUtil.GetNew(perKeyTime*totalFrame,c.a,tanModeL,TangentMode.Stepped));
					}
					break;
				}
			}

			CurveExtension.OptimizesCurve(color_rcurve);
			CurveExtension.OptimizesCurve(color_gcurve);
			CurveExtension.OptimizesCurve(color_bcurve);
			CurveExtension.OptimizesCurve(color_acurve);

			string path="";
			if(slotPathKV.ContainsKey(slotName)){
				path = slotPathKV[slotName];
			}else{
				path = GetNodeRelativePath(armatureEditor,slotNode);
				slotPathKV[slotNode.name] = path;
			}

			if(defaultColorData==null) defaultColorData = new DragonBoneData.ColorData();

			float da = defaultColorData.aM+defaultColorData.a0;
			float dr = defaultColorData.rM+defaultColorData.r0;
			float dg = defaultColorData.gM+defaultColorData.g0;
			float db = defaultColorData.bM+defaultColorData.b0;

			SetColorCurve<Slot>(path,clip,color_rcurve,"color.r",isHaveCurve,dr,animSubData.colorFrameDatas);
			SetColorCurve<Slot>(path,clip,color_gcurve,"color.g",isHaveCurve,dg,animSubData.colorFrameDatas);
			SetColorCurve<Slot>(path,clip,color_bcurve,"color.b",isHaveCurve,db,animSubData.colorFrameDatas);
			SetColorCurve<Slot>(path,clip,color_acurve,"color.a",isHaveCurve,da,animSubData.colorFrameDatas);
		}

		static void CreateSlotAnimFrames(ArmatureEditor armatureEditor, AnimationClip clip , DragonBoneData.AnimSubData animSubData , Dictionary<string,Transform> transformKV, int totalFrame)
		{
			string slotName = string.IsNullOrEmpty(animSubData.slot) ? animSubData.name : animSubData.slot;
			Transform slotNode = transformKV[slotName];
			DragonBoneData.SlotData defaultSlotData = armatureEditor.slotsDataKV[slotName];
			DragonBoneData.ColorData defaultColorData = defaultSlotData.color ;

			AnimationCurve color_rcurve = new AnimationCurve();
			AnimationCurve color_gcurve = new AnimationCurve();
			AnimationCurve color_bcurve = new AnimationCurve();
			AnimationCurve color_acurve = new AnimationCurve();
			AnimationCurve display_curve = new AnimationCurve();

			float during = animSubData.offset;
			float perKeyTime = 1f/armatureEditor.armatureData.frameRate;
			bool isHaveCurve = false;
			for(int j=0;j<animSubData.frameDatas.Length;++j)
			{
				DragonBoneData.AnimFrameData frameData = animSubData.frameDatas[j];

				float prevTweeneasing = float.PositiveInfinity;//前一帧的tweenEasing
				float[] prevCurves = null;
				if(j>0) {
					prevTweeneasing = animSubData.frameDatas[j-1].tweenEasing;
					prevCurves = animSubData.frameDatas[j-1].curve;
				}
				TangentMode tanModeL = GetPrevFrameTangentMode(prevTweeneasing,prevCurves);
				TangentMode tanModeR = TangentMode.Linear;

				if(frameData.curve!=null && frameData.curve.Length>0){
					tanModeR = TangentMode.Editable;
					isHaveCurve = true;
				}else{
					if(frameData.tweenEasing==float.PositiveInfinity){
						tanModeR = TangentMode.Stepped;
					}
					else if(frameData.tweenEasing==0){
						tanModeR = TangentMode.Linear;
					}else if(frameData.tweenEasing==1){
						tanModeR = TangentMode.Smooth;
					}else if(frameData.tweenEasing==2){
						tanModeR = TangentMode.Linear;
					}
				}

				if(frameData.color!=null){
					if(defaultColorData==null) defaultColorData = new DragonBoneData.ColorData();
					Color c = new Color(  
						frameData.color.rM+frameData.color.r0,
						frameData.color.gM+frameData.color.g0,
						frameData.color.bM+frameData.color.b0,
						frameData.color.aM+frameData.color.a0
					);
					color_rcurve.AddKey(KeyframeUtil.GetNew(during,c.r,tanModeL,tanModeR));
					color_gcurve.AddKey(KeyframeUtil.GetNew(during,c.g,tanModeL,tanModeR));
					color_bcurve.AddKey(KeyframeUtil.GetNew(during,c.b,tanModeL,tanModeR));
					color_acurve.AddKey(KeyframeUtil.GetNew(during,c.a,tanModeL,tanModeR));
				}
				else if(color_rcurve.length>0)
				{
					if(defaultColorData==null) defaultColorData = new DragonBoneData.ColorData();
					Color c = new Color();
					c.a = defaultColorData.aM+defaultColorData.a0;
					c.r = defaultColorData.rM+defaultColorData.r0;
					c.g = defaultColorData.gM+defaultColorData.g0;
					c.b = defaultColorData.bM+defaultColorData.b0;
					color_rcurve.AddKey(KeyframeUtil.GetNew(during,c.r,tanModeL,tanModeR));
					color_gcurve.AddKey(KeyframeUtil.GetNew(during,c.g,tanModeL,tanModeR));
					color_bcurve.AddKey(KeyframeUtil.GetNew(during,c.b,tanModeL,tanModeR));
					color_acurve.AddKey(KeyframeUtil.GetNew(during,c.a,tanModeL,tanModeR));
				}


				//改displyindex
				if(frameData.displayIndex>-2)
					display_curve.AddKey(new Keyframe(during,frameData.displayIndex,float.PositiveInfinity,float.PositiveInfinity));

				during+= frameData.duration*perKeyTime;
			}

			CurveExtension.OptimizesCurve(color_rcurve);
			CurveExtension.OptimizesCurve(color_gcurve);
			CurveExtension.OptimizesCurve(color_bcurve);
			CurveExtension.OptimizesCurve(color_acurve);
			CurveExtension.OptimizesCurve(display_curve);

			string path="";
			if(slotPathKV.ContainsKey(slotName)){
				path = slotPathKV[slotName];
			}else{
				path = GetNodeRelativePath(armatureEditor,slotNode);
				slotPathKV[slotNode.name] = path;
			}

			if(defaultColorData==null) defaultColorData = new DragonBoneData.ColorData();

			float da = defaultColorData.aM+defaultColorData.a0;
			float dr = defaultColorData.rM+defaultColorData.r0;
			float dg = defaultColorData.gM+defaultColorData.g0;
			float db = defaultColorData.bM+defaultColorData.b0;

			SetColorCurve<Slot>(path,clip,color_rcurve,"color.r",isHaveCurve,dr,animSubData.frameDatas);
			SetColorCurve<Slot>(path,clip,color_gcurve,"color.g",isHaveCurve,dg,animSubData.frameDatas);
			SetColorCurve<Slot>(path,clip,color_bcurve,"color.b",isHaveCurve,db,animSubData.frameDatas);
			SetColorCurve<Slot>(path,clip,color_acurve,"color.a",isHaveCurve,da,animSubData.frameDatas);

			if(display_curve.keys!=null && display_curve.keys.Length>0 && 
				CheckCurveValid(display_curve,slotNode.GetComponent<Slot>().displayIndex))
			{
				clip.SetCurve(path,typeof(Slot),"m_DisplayIndex",display_curve);
			}
		}

		static bool SetColorCurve<T>(string path,AnimationClip clip, AnimationCurve curve,string prop, bool isHaveCurve,float defaultVal,DragonBoneData.AnimFrameData[] timelines){
			if(curve.keys !=null&& curve.keys.Length>0&& CheckCurveValid(curve,defaultVal)) 
			{
				if(isHaveCurve) SetCustomCurveTangents(curve,timelines);
				CurveExtension.UpdateAllLinearTangents(curve);
				AnimationUtility.SetEditorCurve(clip,EditorCurveBinding.FloatCurve(path,typeof(T),prop),curve);
				return true;
			}
			return false;
		}

		/// <summary>
		/// set events
		/// </summary>
		static void SetEvent( ArmatureEditor armatureEditor,AnimationClip clip,DragonBoneData.AnimKeyData[] frameDatas)
		{
			if(frameDatas==null || frameDatas.Length==0) return;

			if(armatureEditor.armature.gameObject.GetComponent<DragonBoneEvent>()==null)
				armatureEditor.armature.gameObject.AddComponent<DragonBoneEvent>();
			float during = 0;
			float perKeyTime = 1f/armatureEditor.armatureData.frameRate;

			List<AnimationEvent> evts=new List<AnimationEvent>();
			foreach(DragonBoneData.AnimKeyData keyData in frameDatas)
			{
				if(!string.IsNullOrEmpty(keyData.eventName))
				{
					AnimationEvent ae = new AnimationEvent();
					ae.messageOptions = SendMessageOptions.DontRequireReceiver;

					string param = keyData.eventName+"$";
					if(!string.IsNullOrEmpty(keyData.actionName))
					{
						param+=keyData.actionName+"$";
					}
					else
					{
						param+="$";
					}

					if(!string.IsNullOrEmpty(keyData.soundName))
					{
						param+=keyData.soundName;
					}

					ae.functionName = "OnAnimEvent";
					ae.time = during;
					ae.stringParameter = param;
					evts.Add(ae);
				}

				during += keyData.duration*perKeyTime;
			}
			if(evts.Count>0){
				AnimationUtility.SetAnimationEvents(clip,evts.ToArray());
			}

		}

		//check invalid curve
		static bool CheckCurveValid(AnimationCurve curve , float defaultValue){
			Keyframe frame = curve.keys[0];
			if(curve.length==1) {
				if(frame.value==defaultValue) return false;
				return true;
			}
			for(int i=0;i<curve.keys.Length;++i){
				Keyframe frame2 = curve.keys[i];
				if(frame.value!=defaultValue || frame.value!=frame2.value) {
					return true;
				}
			}
			return false;
		}

		static void OptimizesCurve( AnimationCurve curve){
			if(curve!=null && curve.length>0){
				for(int i=1;i<curve.keys.Length-1;++i){
					Keyframe f1 = curve.keys[i-1];//前一帧
					Keyframe frame = curve.keys[i];
					Keyframe f2 = curve.keys[i+1];//后一帧
					if(frame.value==f1.value && frame.value==f2.value) {
						curve.RemoveKey(i);
						i--;
					}
				}
			}
		}

		static string GetNodeRelativePath(ArmatureEditor armatureEditor ,Transform node){
			List<string> path = new List<string>();
			while(node!=armatureEditor.armature)
			{
				path.Add(node.name);
				node = node.parent;
			}
			string result="";
			for(int i=path.Count-1;i>=0;i--){
				result+=path[i]+"/";
			}
			return result.Substring(0,result.Length-1);
		}

		static void SetCustomCurveTangents(AnimationCurve curve, DragonBoneData.AnimFrameData[] frameDatas){
			int len=curve.keys.Length;
			for (int i = 0; i < len; i++) {
				int nextI = i + 1;
				if (nextI < curve.keys.Length){
					if (frameDatas[i].curve != null ){ 
						CurveExtension.SetCustomTangents(curve, i, nextI, frameDatas[i].curve);
					}
				}
			}
		}

		static void SetCustomRotateCurveTangents(AnimationCurve curve, DragonBoneData.AnimFrameData[] frameDatas){
			int len=curve.keys.Length;
			int j=0;
			for (int i = 0; i < len; i++) {
				int nextI = i + 1;
				if (nextI < curve.keys.Length && j<frameDatas.Length){
					if (frameDatas[j].curve != null ){ 
						CurveExtension.SetCustomTangents(curve, i, nextI, frameDatas[j].curve);
					}
				}
				if(curve.keys[i].value<=180f || curve.keys[i].value>=-180f){
					++j;
				}
			}
		}
	}
}
