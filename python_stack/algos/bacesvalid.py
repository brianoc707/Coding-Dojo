def bracesValid(somestring):
    pcount = 0 
    bcount = 0
    Bcount = 0
    list1 = []
    for x in range (len(somestring)):
        if somestring[x] == "(":
            pcount += 1
            list1.append(x)
        if somestring[x] == ")":
            pcount -= 1
            if list1[len(list1)-1] == '(':
                list1.pop()
        if somestring[x] == "[":
            bcount += 1
            list1.append(x)
        if somestring[x] == "]":
            bcount -= 1
            if list1[len(list1)-1] == '[':
                list1.pop()
        if somestring[x] == "{":
            Bcount += 1
            list1.append(x)
        if somestring[x] == "}":
            Bcount -= 1
            if list1[len(list1)-1] == '{':
                list1.pop()
        
    if list1 == []:
        return True
    else:
        return False

print(bracesValid("A(1)s[0(n]0{t)0}k)"))