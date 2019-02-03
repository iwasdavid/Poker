module Poker

type Face = 
    | Ace of int
    | Two of int
    | Three of int
    | Four of int
    | Five of int
    | Six of int
    | Seven of int
    | Eight of int
    | Nine of int
    | Ten of int
    | Jack of int
    | Queen of int
    | King of int

type Suit =
    | Heart
    | Diamond
    | Spade
    | Club

type Card =
    { Value: Face;
      Suit: Suit; }

type Hand =
    { Cards: Card list }

type Hands =
    | RoyalFlush
    | StraightFlush
    | FourOfAKind
    | FullHouse
    | Flush
    | Straight
    | ThreeOfAKind
    | TwoPair
    | Pair
    | HighCard







let bestHands hands = failwith "blah"