using System.Collections.Generic;
using UnityEngine;

public class Deck
{
    private List<Card> cards;
    
    public bool IsEmpty => cards.Count == 0;

    public Deck()
    {
        cards = new List<Card>();
        CreateNewDeck();
        Shuffle();
    }

    public void CreateNewDeck()
    {
        cards.Clear();

        foreach (Card.Suit suit in System.Enum.GetValues(typeof(Card.Suit)))
        {
            foreach (Card.Rank rank in System.Enum.GetValues(typeof(Card.Rank)))
            {
                cards.Add(new Card(suit, rank));
            }
        }
    }

    public void Shuffle()
    {
        System.Random rng = new System.Random();
        
        int n = cards.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Card temp = cards[k];
            cards[k] = cards[n];
            cards[n] = temp;
        }

        // Альтернативный способ - используя встроенный Random.Range из Unity
        // for (int i = 0; i < cards.Count; i++)
        // {
        //     Card temp = cards[i];
        //     int randomIndex = Random.Range(i, cards.Count);
        //     cards[i] = cards[randomIndex];
        //     cards[randomIndex] = temp;
        // }
    }

    // Метод для взятия верхней карты из колоды
    public Card DrawCard()
    {
        if (IsEmpty)
        {
            Debug.LogError("Колода пуста! Нельзя взять карту.");
            return null;
        }

        // Берем карту из конца списка (верха колоды)
        Card drawnCard = cards[cards.Count - 1];
        cards.RemoveAt(cards.Count - 1);
        return drawnCard;
    }

    public void PrintDeck()
    {
        foreach (Card card in cards)
        {
            Debug.Log($"{card.rank} of {card.suit} (Value: {card.Value})");
        }
        Debug.Log($"Всего карт в колоде: {cards.Count}");
    }
}