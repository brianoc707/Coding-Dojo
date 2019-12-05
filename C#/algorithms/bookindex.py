
def bookindex(arr):
    mystring = ""
    myend = ""
    i = 0
    #iterate through the array
    while i< len(arr):
        mybegin = str(arr[i])
        #if i is not at the last index, then while the current value and the next value are just 1 more, increment i, and append to myend string the next number, until it eventually has the my end value be the last number in the sequence. if there is nothing for myend, then just make mystring have the beginning value and append a comma. Then increment the i and go through while loop again
        if i != len(arr)-1:
            while arr[i+1] == arr[i] +1:
                i += 1
                myend = str(arr[i])
                if i+1 == len(arr):
                    break
        if myend =="":
            mystring += mybegin
        else:
            mystring += mybegin + " - " + myend
        myend = ""
        if i != len(arr)-1:
            mystring += ", "
        i+=1
    return [mystring]


print(bookindex([1,3,4,5,8,9,22]))
