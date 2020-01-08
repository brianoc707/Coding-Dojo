function cToF(num){
    
   num = (num * 9/5) + 32
    return num;
}
console.log(cToF(100));

function fibonnacci(n)
{
    let arr = [0, 1];
    var a = 0, b = 1, c = 1;
    for(var i = 2; i <= n; i++)
    {
        c = a + b;
        a = b;
        b = c;
        arr.push(c);
    }
    return arr;
}
console.log(fibonnacci(5))

function countWordsInString(string){
    count = 1;
    for(i = 0; i < string.length; i++)
    {
        if(string[i] === " ")
        {
            count += 1;
        }
        
    }
    return count;
}
console.log(countWordsInString("Hello My Name Is Brian"));

function countWordsInString(string){
    return string.split(" ").length;
}
console.log(countWordsInString("Hello My Name Is Brian"));

function sqroot(arr){
    for(i = 0; i < arr.length; i++)
    {
        arr[i] = Math.sqrt(arr[i]);

        if(Math.sqrt(arr[i]) === NaN)
        {
            arr[i] = 0;
        }

    }
    return arr;
    

}
console.log(sqroot([4,16,32,81]));

function wordSwitch(string)
{
    var result = "";
    var wordArray = string.split(" ");
    for(i = wordArray.length - 1; i >= 0; i--)
    {
        result += wordArray[i] + " ";
    }
    return result;
}
console.log(wordSwitch("hello world man"));

function removeX(arr, x)
{

}

