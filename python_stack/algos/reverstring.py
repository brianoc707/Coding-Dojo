def reverse(somestring):
    string = ""
    for x in range(len(somestring)-1, -1, -1):
        string += somestring[x]

    print(string)
    return string

reverse("hello")