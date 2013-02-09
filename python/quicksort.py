#!/usr/bin/python

import sys

def qsort(array,pivotPos,count):
    i = 0
    j = 0
    pivot = array.pop(pivotPos)
    while j < len(array):
        if array[j] < pivot:
            array[i], array[j] = array[j], array[i]
            i += 1
        j += 1
    array.insert(i,pivot)
    if i > 1:
        array[:i] = qsort(array[:i],0,count)
    if i+1 < len(array):
        array[i+1:] = qsort(array[i+1:],0,count)
    return array


f = open("QuickSort.txt","r")
baseArray = []

for l in f:
    baseArray.append(int(l))

f.close()

count = [0]
qsort(baseArray,0,count)
print baseArray
