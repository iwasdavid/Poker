
type Face = 
    | Ace
    | Two
    | Three 
    | Four
    | Five
    | Six
    | Seven
    | Eight
    | Nine
    | Ten
    | Jack
    | Queen
    | King

type Suit =
    | Heart
    | Diamond
    | Spade
    | Club

type Card =
    { Value: Face;
      Suit: Suit; }

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

type Hand =
    { Cards: Card list;
      Hand: Hands }

let getValue value =
    match value with
    | "A" -> Ace
    | "2" -> Two
    | "3" -> Three
    | "4" -> Four
    | "5" -> Five
    | "6" -> Six
    | "7" -> Seven
    | "8" -> Eight
    | "9" -> Nine
    | "10" -> Ten
    | "J" -> Jack
    | "Q" -> Queen
    | "K" -> King
    | _ -> failwith "Nope"

let getSuit value =
    match value with
    | "S" -> Spade
    | "H" -> Heart
    | "C" -> Club
    | "D" -> Diamond
    | _ -> failwith "Nope"

let getCard (s:string) =
    let list = s |> Seq.toList
    if s.Length = 2 then
        let value = getValue <| string list.[0]
        let suit = getSuit <| string list.[1]
        { Value = value; Suit = suit }
    else
        let value = getValue <| sprintf "%c%c" list.[0] list.[1]
        let suit = getSuit <| string list.[2]
        { Value = value; Suit = suit }
    

let royalFlush (cards: Card list) =
    let suits = cards |> List.groupBy (fun c -> c.Suit) |> List.length = 1
    let value = cards |> List.map (fun c -> c.Value) |> List.distinct |> List.length = 5
    let has10 = cards |> List.filter (fun c -> c.Value = Ten) |> List.length = 1
    let hasAce = cards |> List.filter (fun c -> c.Value = Ace) |> List.length = 1
    suits && value && has10 && hasAce // this is still straight flush and needs work

let straightFlush cards =
    let suits = cards |> List.map (fun c -> c.Suit) |> List.distinct |> List.length = 1
    let value = cards |> List.map (fun c -> c.Value) |> List.distinct |> List.length = 5
    suits && value

let fourOfAKind cards =
    printfn "Cards: %A" cards
    cards |> List.map (fun c -> c.Suit) |> List.distinct |> List.length = 4

let fullHouse cards =
    true

let flush cards =
    true

let straight cards =
    true

let threeOfAKind cards =
    true

let twoPair cards =
    true

let pair cards =
    true

let getResult cards =
    match cards with
    | cards when royalFlush cards -> RoyalFlush
    | cards when straightFlush cards -> StraightFlush
    | cards when fourOfAKind cards -> FourOfAKind
    | cards when fullHouse cards -> FullHouse
    | cards when flush cards -> Flush
    | cards when straight cards -> Straight
    | cards when threeOfAKind cards -> ThreeOfAKind
    | cards when twoPair cards -> TwoPair
    | cards when pair cards -> Pair
    | _ -> HighCard
    
let getHand (hand:string) =
    let cards = hand.Split ' ' |> Array.map getCard |> Array.toList
    { Cards = cards; Hand = getResult cards }

let royalFlushHand = "AS 10S JS QS KS"
let straightFlushHand = "3S 4S 5S 6S 7S"

//let rf = getHand royalFlushHand
//let sf = getHand straightFlushHand

let sf = getHand straightFlushHand







