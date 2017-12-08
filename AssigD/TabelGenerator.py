import math


def generate_table():
    n = 7157
    b0 = int(math.sqrt(n))
    print(b0)
    b0Patrat=b0*b0 % n
    listB=[]
    listB.append(b0)
    listA=[]
    listA.append(int(math.sqrt(n)))
    listBPatrat=[]
    listX=[]
    listX.append(math.sqrt(n)-int(math.sqrt(n)))
    s='1   '
    for i in range(1,20):

        s+=str(i)+"  "
        print(int(math.sqrt(n)))

        ai=int(1/(listX[i-1]))
        listA.append(ai)
        xi = (1 / listX[i - 1]) - ai
        listX.append(xi)
    for i in range(1,20):
        if(i>=2):
            bi=(listA[i]*listB[i-1]+listB[i-2]) % n
            listB.append(bi)
        else:
            bi=(listA[i]*listB[i-1]+1) % n
            listB.append(bi)


    for i in range(20):
        aux= listB[i]*listB[i] % n
        listBPatrat.append(aux)
    print(s)
    print(listA)
    print(listB)
    print(listBPatrat)
    listBPatratMod=[]
    for e in listBPatrat:
        listBPatratMod.append(e-n)
    print(listBPatratMod)

generate_table()

