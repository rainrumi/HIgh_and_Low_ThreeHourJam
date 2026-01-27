using VContainer.Unity;

public class GameInitializer : IStartable
{
    private readonly CardPresenter _cardPresenter;

    public GameInitializer(CardPresenter cardPresenter)
    {
        _cardPresenter = cardPresenter;
    }

    public void Start()
    {
        // ‚±‚±‚¢‚é‚ÌHH
    }
}
