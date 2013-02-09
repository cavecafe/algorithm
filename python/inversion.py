import sys

def split_count(count,left):
    count[0]+=len(left)
    return count

def mergesort(array):
    if len(array) < 2:
        return array
    middle = len(array)/2
    left = mergesort(array[:middle])

    right = mergesort(array[middle:])
    return merge(left,right)

def merge(left, right):
    result=[]
    while len(left)>0 or len(right)>0:
        if len(left)>0 and len(right)>0:
            if left[0]<=right[0]:
                result.append(left[0])
                left.pop(0)
            else :
                #count=split_count(count,left)
                result.append(right[0])
                right.pop(0)
        elif len(left)>0:
            result.append(left[0])
            left.pop(0)
        elif len(right)>0:
            result.append(right[0])
            right.pop(0)
    return result

baseArray = []
count = [0]

f = open("IntegerArray.txt","r")
for l in f:
    baseArray.append(int(l))

f.close()

sortedArray = mergesort(baseArray)

print sortedArray
#print "# of inversion found : ",format(count[0],",d")
