warning: LF will be replaced by CRLF in Assets/Scenes/SampleScene.unity.
The file will have its original line endings in your working directory
[1mdiff --git a/Assets/Scenes/SampleScene.unity b/Assets/Scenes/SampleScene.unity[m
[1mindex 6b71469..7eab0b4 100644[m
[1m--- a/Assets/Scenes/SampleScene.unity[m
[1m+++ b/Assets/Scenes/SampleScene.unity[m
[36m@@ -147,7 +147,8 @@[m [mTransform:[m
   m_LocalRotation: {x: 0, y: 0, z: 0, w: 1}[m
   m_LocalPosition: {x: -28.9, y: -0.037, z: 3.41}[m
   m_LocalScale: {x: 1, y: 1, z: 1}[m
[31m-  m_Children: [][m
[32m+[m[32m  m_Children:[m
[32m+[m[32m  - {fileID: 401482238}[m
   m_Father: {fileID: 0}[m
   m_RootOrder: 6[m
   m_LocalEulerAnglesHint: {x: 0, y: 0, z: 0}[m
[36m@@ -194,6 +195,99 @@[m [mCharacterController:[m
   m_SkinWidth: 0.08[m
   m_MinMoveDistance: 0.001[m
   m_Center: {x: 0, y: 0, z: 0}[m
[32m+[m[32m--- !u!1 &401482237[m
[32m+[m[32mGameObject:[m
[32m+[m[32m  m_ObjectHideFlags: 0[m
[32m+[m[32m  m_CorrespondingSourceObject: {fileID: 0}[m
[32m+[m[32m  m_PrefabInstance: {fileID: 0}[m
[32m+[m[32m  m_PrefabAsset: {fileID: 0}[m
[32m+[m[32m  serializedVersion: 6[m
[32m+[m[32m  m_Component:[m
[32m+[m[32m  - component: {fileID: 401482238}[m
[32m+[m[32m  - component: {fileID: 401482241}[m
[32m+[m[32m  - component: {fileID: 401482240}[m
[32m+[m[32m  - component: {fileID: 401482239}[m
[32m+[m[32m  m_Layer: 0[m
[32m+[m[32m  m_Name: hello[m
[32m+[m[32m  m_TagString: Untagged[m
[32m+[m[32m  m_Icon: {fileID: 0}[m
[32m+[m[32m  m_NavMeshLayer: 0[m
[32m+[m[32m  m_StaticEditorFlags: 0[m
[32m+[m[32m  m_IsActive: 1[m
[32m+[m[32m--- !u!4 &401482238[m
[32m+[m[32mTransform:[m
[32m+[m[32m  m_ObjectHideFlags: 0[m
[32m+[m[32m  m_CorrespondingSourceObject: {fileID: 0}[m
[32m+[m[32m  m_PrefabInstance: {fileID: 0}[m
[32m+[m[32m  m_PrefabAsset: {fileID: 0}[m
[32m+[m[32m  m_GameObject: {fileID: 401482237}[m
[32m+[m[32m  m_LocalRotation: {x: 0, y: 0, z: 0, w: 1}[m
[32m+[m[32m  m_LocalPosition: {x: 0, y: 0, z: 0}[m
[32m+[m[32m  m_LocalScale: {x: 1, y: 1, z: 1}[m
[32m+[m[32m  m_Children: [][m
[32m+[m[32m  m_Father: {fileID: 332644879}[m
[32m+[m[32m  m_RootOrder: 0[m
[32m+[m[32m  m_LocalEulerAnglesHint: {x: 0, y: 0, z: 0}[m
[32m+[m[32m--- !u!65 &401482239[m
[32m+[m[32mBoxCollider:[m
[32m+[m[32m  m_ObjectHideFlags: 0[m
[32m+[m[32m  m_CorrespondingSourceObject: {fileID: 0}[m
[32m+[m[32m  m_PrefabInstance: {fileID: 0}[m
[32m+[m[32m  m_PrefabAsset: {fileID: 0}[m
[32m+[m[32m  m_GameObject: {fileID: 401482237}[m
[32m+[m[32m  m_Material: {fileID: 0}[m
[32m+[m[32m  m_IsTrigger: 0[m
[32m+[m[32m  m_Enabled: 1[m
[32m+[m[32m  serializedVersion: 2[m
[32m+[m[32m  m_Size: {x: 1, y: 1, z: 1}[m
[32m+[m[32m  m_Center: {x: 0, y: 0, z: 0}[m
[32m+[m[32m--- !u!23 &401482240[m
[32m+[m[32mMeshRenderer:[m
[32m+[m[32m  m_ObjectHideFlags: 0[m
[32m+[m[32m  m_CorrespondingSourceObject: {fileID: 0}[m
[32m+[m[32m  m_PrefabInstance: {fileID: 0}[m
[32m+[m[32m  m_PrefabAsset: {fileID: 0}[m
[32m+[m[32m  m_GameObject: {fileID: 401482237}[m
[32m+[m[32m  m_Enabled: 1[m
[32m+[m[32m  m_CastShadows: 1[m
[32m+[m[32m  m_ReceiveShadows: 1[m
[32m+[m[32m  m_DynamicOccludee: 1[m
[32m+[m[32m  m_MotionVectors: 1[m
[32m+[m[32m  m_LightProbeUsage: 1[m
[32m+[m[32m  m_ReflectionProbeUsage: 1[m
[32m+[m[32m  m_RayTracingMode: 2[m
[32m+[m[32m  m_RenderingLayerMask: 1[m
[32m+[m[32m  m_RendererPriority: 0[m
[32m+[m[32m  m_Materials:[m
[32m+[m[32m  - {fileID: 10303, guid: 0000000000000000f000000000000000, type: 0}[m
[32m+[m[32m  m_StaticBatchInfo:[m
[32m+[m[32m    firstSubMesh: 0[m
[32m+[m[32m    subMeshCount: 0[m
[32m+[m[32m  m_StaticBatchRoot: {fileID: 0}[m
[32m+[m[32m  m_ProbeAnchor: {fileID: 0}[m
[32m+[m[32m  m_LightProbeVolumeOverride: {fileID: 0}[m
[32m+[m[32m  m_ScaleInLightmap: 1[m
[32m+[m[32m  m_ReceiveGI: 1[m
[32m+[m[32m  m_PreserveUVs: 0[m
[32m+[m[32m  m_IgnoreNormalsForChartDetection: 0[m
[32m+[m[32m  m_ImportantGI: 0[m
[32m+[m[32m  m_StitchLightmapSeams: 1[m
[32m+[m[32m  m_SelectedEditorRenderState: 3[m
[32m+[m[32m  m_MinimumChartSize: 4[m
[32m+[m[32m  m_AutoUVMaxDistance: 0.5[m
[32m+[m[32m  m_AutoUVMaxAngle: 89[m
[32m+[m[32m  m_LightmapParameters: {fileID: 0}[m
[32m+[m[32m  m_SortingLayerID: 0[m
[32m+[m[32m  m_SortingLayer: 0[m
[32m+[m[32m  m_SortingOrder: 0[m
[32m+[m[32m--- !u!33 &401482241[m
[32m+[m[32mMeshFilter:[m
[32m+[m[32m  m_ObjectHideFlags: 0[m
[32m+[m[32m  m_CorrespondingSourceObject: {fileID: 0}[m
[32m+[m[32m  m_PrefabInstance: {fileID: 0}[m
[32m+[m[32m  m_PrefabAsset: {fileID: 0}[m
[32m+[m[32m  m_GameObject: {fileID: 401482237}[m
[32m+[m[32m  m_Mesh: {fileID: 10202, guid: 0000000000000000e000000000000000, type: 0}[m
 --- !u!1 &568243710[m
 GameObject:[m
   m_ObjectHideFlags: 0[m
