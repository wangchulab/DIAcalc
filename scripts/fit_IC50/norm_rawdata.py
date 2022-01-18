import sys
import numpy as np
from math import log10
#import matplotlib
#matplotlib.use('TkAgg')
#import matplotlib.pyplot as plt

T = [0.0, 2.0, 5.0, 10.0, 20.0, 25.0, 30.0, 40.0, 50.0]
print(T)
S = ['blue', 'red', 'green']
T0 = 0.0
TN = 100.0

print(T0, TN)

data = []
for fn in sys.argv[1:]:
    d1 = []
    d2 = []
    d3 = []
    d4 = []
    d5 = []
    d6 = []
    d6 = []
    d7 = []
    d8 = []
    d9 = []
    lines = open(fn,'r').readlines()
    for l in lines[1:]:
        es = l.strip().split('\t')
        skip = False
        try:
            t1 = float(es[3])
            t2 = float(es[4])
            t3 = float(es[5])
            t4 = float(es[6])
            t5 = float(es[7])
            t6 = float(es[8])
            t7 = float(es[9])
            t8 = float(es[10])
            t9 = float(es[11])
        except:
            skip = True
        if not skip:
            d1.append(t1)
            d2.append(t2)
            d3.append(t3)
            d4.append(t4)
            d5.append(t5)
            d6.append(t6)
            d7.append(t7)
            d8.append(t8)
            d9.append(t9)
    data.append([])
    data[-1].append(np.mean(d1))
    data[-1].append(np.mean(d2))
    data[-1].append(np.mean(d3))
    data[-1].append(np.mean(d4))
    data[-1].append(np.mean(d5))
    data[-1].append(np.mean(d6))
    data[-1].append(np.mean(d7))
    data[-1].append(np.mean(d8))
    data[-1].append(np.mean(d9))

#for each TMT
print(data)
topI = [x[0] for x in data]
print("TOP:", topI)
x1 = []
y1 = []
for n, dat in enumerate(data):
    x1 = x1 + T
    y1 = y1 + dat

print("LEN:", len(x1), len(y1))
x1 = np.array(x1)
y1 = np.array(y1)

scale = np.ones(y1.shape)
nd = int(y1.shape[0] / len(data))
print("nd:", nd)
skip = []
for i in range(len(data)):
    skip.append(i*nd)
    skip.append((i+1)*nd-1)

#split dataset
for n, dat in enumerate(data):
    xdata = np.array(T)
    ydata = np.array(dat)
    for i in range(nd):
        scale[nd*n+i] = 100.0/dat[i]
    s = scale[nd*n:nd*(n+1)]
    #raw data
    #plt.scatter(xdata, ydata/topI[n]*100, color="", edgecolor=S, s = 100, marker='o', lw=2)
    #scaled data
    #plt.scatter(xdata, ydata*s, s = 20, color=S[n], marker='o')
#plt.show()

print("OUTPUT:")
for n, fn in enumerate(sys.argv[1:]):
    s = scale[nd*n:nd*(n+1)] * topI[n] / 100.0
    print(fn, s)

