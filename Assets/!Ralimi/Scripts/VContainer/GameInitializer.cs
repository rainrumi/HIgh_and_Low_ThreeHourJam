using VContainer.Unity;

public class GameInitializer : IStartable
{
    private readonly ExplanationPresenter _explanationPresenter;
    private readonly CardPresenter _cardPresenter;
    private readonly GudgeButtonPresenter _gudgeButtonPresenter;
    private readonly ResultPresenter _resultPresenter;

    public GameInitializer(CardPresenter cardPresenter, GudgeButtonPresenter gudgeButtonPresenter,
        ResultPresenter resultPresenter, ExplanationPresenter explanationPresenter)
    {
        _cardPresenter = cardPresenter;
        _gudgeButtonPresenter = gudgeButtonPresenter;
        _resultPresenter = resultPresenter;
        _explanationPresenter = explanationPresenter;
    }

    public void Start()
    {
        // Ç±Ç±Ç¢ÇÈÇÃÅHÅH
    }
}
