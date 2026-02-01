using VContainer.Unity;

public class GameInitializer : IStartable
{
    private readonly CardPresenter _cardPresenter;
    private readonly GudgeButtonPresenter _gudgeButtonPresenter;

    public GameInitializer(CardPresenter cardPresenter, GudgeButtonPresenter gudgeButtonPresenter)
    {
        _cardPresenter = cardPresenter;
        _gudgeButtonPresenter = gudgeButtonPresenter;
    }

    public void Start()
    {
        // ‚±‚±‚¢‚é‚ÌHH
    }
}
