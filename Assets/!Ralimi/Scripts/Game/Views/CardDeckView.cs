using System;
using UnityEngine;

public class CardDeckView : MonoBehaviour
{
    [Serializable]
    public struct CardDeck
    {
        [SerializeField] private CardView cardPrefab;

        [SerializeField] private Transform cardContainer;

        public CardView CardView { get; private set; }

        public void Initialize()
        {
            GenerateCardView();
        }

        private void GenerateCardView()
        {
            CardView = Instantiate(cardPrefab, cardContainer);
        }
    }

    [SerializeField] CardDeck _cardOwnDeckView;
    [SerializeField] CardDeck _cardPeerDeckView;

    public CardDeck cardOwnDeckView => _cardOwnDeckView;
    public CardDeck cardPeerDeckView => _cardPeerDeckView;

    public void Initialize()
    {
        _cardOwnDeckView.Initialize();
        _cardPeerDeckView.Initialize();
    }
}
