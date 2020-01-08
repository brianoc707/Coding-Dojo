const deck1 = new Deck();
let hand = [];

const table = document.getElementById("table");
const playerHand = document.getElementById("hand");

function displayCards(){
    let s = "";
    let deck = deck1.deck;
    for(let i in deck){
        s += `<img
            src="imgs/back.png" 
            alt="card" 
            width="100px"
            style="bottom:${.25*i}px;left:${.25*i}px;"
        >`;
    }
    table.innerHTML = s;
    s = "";
    for(let card of hand){
        s += `<img 
            src="imgs/back.png" 
            class="hand-cards"
            data-alt-src="imgs/${card.image}" 
            alt="card" 
            width="100px"
        >`;
    }
    playerHand.innerHTML = s;
    addListeners();
}
displayCards();

const shuffleButton = document.getElementById("shuffle");
shuffleButton.addEventListener("click", function(){
    deck1.shuffle();
    displayCards();
});

const resetButton = document.getElementById("reset");
resetButton.addEventListener("click", function(){
    deck1.reset();
    hand = [];
    displayCards();
});

const dealButton = document.getElementById("deal");
dealButton.addEventListener("click", function(){
    hand.push(deck1.deal());
    displayCards();
});

function addListeners(){
    const cards = document.getElementsByClassName("hand-cards");
    for(let card of cards){
        card.addEventListener("click", function(e){
            let temp = e.target.src;
            e.target.src = e.target.dataset.altSrc;
            e.target.dataset.altSrc = temp;
        });
    }
}