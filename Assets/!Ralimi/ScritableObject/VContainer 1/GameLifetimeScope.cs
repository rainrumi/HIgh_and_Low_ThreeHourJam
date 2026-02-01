using RaruLib;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    [Header("Settings")]
    [SerializeField] private CardSettings cardSettings;
    [SerializeField] private ButtonSettings buttonSettings;

    [Header("Views")]
    [Header("Cards")]
    [SerializeField] private CardDeckView cardDeckView;
    [SerializeField] private GudgeButtonView gudgeButtonView;

    protected override void Configure(IContainerBuilder builder)
    {
        // Settings
        builder.RegisterInstance(cardSettings);
        builder.RegisterInstance(buttonSettings);

        // Model
        builder.Register<GameModel>(Lifetime.Singleton);

        // Views
        builder.RegisterInstance(cardDeckView);
        builder.RegisterInstance(gudgeButtonView);

        // Presenter
        builder.Register<CardPresenter>(Lifetime.Singleton);
        builder.Register<GudgeButtonPresenter>(Lifetime.Singleton);

        // EntryPoint
        builder.RegisterEntryPoint<GameInitializer>();

        // Macro
        builder.Register<URandom>(Lifetime.Singleton)
            .As<IRandom>();
    }
}
