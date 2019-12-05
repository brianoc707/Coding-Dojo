def oddoreven(i):
    oddArray = []
    evenArray = []
    for i in range(1, 20, 1):
        if i %2 == 0:
            evenArray.append(i)
        if i %2 != 0:
            oddArray.append(i)
    
    print(oddArray)
    print(evenArray)
print(oddoreven(20))