# Recursive in order subset

def rios(string, sub = "", i = 0):
        if i == len(string): 
            return [sub]
        else:
            return rios(string, sub+string[i], i+1) + rios (string, sub, i+1)

print(rios('happy'))