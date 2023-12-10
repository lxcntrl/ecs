using Unity.Entities;
using Unity.Entities.Content;

public struct LoadSceneData : IComponentData {
    public WeakObjectSceneReference SceneReference;
}

