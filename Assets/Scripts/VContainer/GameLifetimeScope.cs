using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    [Header("Settings")]
    [SerializeField] private CardSettings cardSettings;

    [Header("Views")]
    [Header("Cards")]
    [SerializeField] private CardView cardOwnView;
    [SerializeField] private CardView cardPeerView;

    protected override void Configure(IContainerBuilder builder)
    {
        // Settings
        builder.RegisterInstance(cardSettings);

        // Model
        builder.Register<GameModel>(Lifetime.Singleton);

        // Views
        builder.RegisterInstance(cardOwnView);
        builder.RegisterInstance(cardPeerView);
    }
}
