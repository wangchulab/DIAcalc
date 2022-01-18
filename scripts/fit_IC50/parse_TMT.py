import sys
from math import exp
import numpy as np
from collections import defaultdict
from scipy.optimize import curve_fit
from scipy.stats import pearsonr
import matplotlib.pyplot as plt

map_pro_dat = defaultdict(list)

#load scale
scale = []
for s in sys.argv[2:]:
    scale.append(float(s))
#sys.exit()

#read data for each protein group
lines = open(sys.argv[1], 'r').readlines()
for l in lines:
    es = l.strip().split('\t')
    dat = []
    skip = False
    for i in [3,4,5,6,7,8,9,10,11]:
        try:
          val = float(es[i]) * scale[i-3]
          dat.append(val)
        except:
          skip = True
    if not skip:
        map_pro_dat[es[0]+":"+es[1]] = dat
#print map_pro_dat

def func(x, a, b, plat):
    return ((1.0-plat)/(1.0+np.exp((x-b)*a) + plat))

x0 = [0.0, 2.0, 5.0, 10.0, 20.0, 25.0, 30.0, 40.0, 50.0]
p0 = [0.1, 40.0, 0.1] #initial guess
b0 = [(0, 1.0, 0.0), (1.0, 60.0, 90.0)]
for p in map_pro_dat.keys(): #for p in ["sp|Q9C0B1|FTO_HUMAN"]:
    xdata = x0
    ydata = map_pro_dat[p]
    ydata = [y/ydata[0] for y in ydata]
    y0 = ydata
    popt, pcov = curve_fit(func, xdata, ydata, p0, bounds=b0) # 
    perr = np.sqrt(np.diag(pcov))
    A = popt[0]
    B = popt[1]
    plat = popt[2]
    IC50_err = perr[1]
    #print("A=", A, "B=", B, "plat=", plat)

    #output
    y_calc0 = [func(i, popt[0], popt[1], popt[2]) for i in x0]
    #print x0, y_calc0, y0
    R2 = np.corrcoef(y0, y_calc0)
    y_calc = [func(i, popt[0], popt[1], popt[2]) for i in xdata]
    #print xdata, y_calc, ydata
    #pR2 = pearsonr(ydata, y_calc)
    #pR2 = pearsonr(y0, y_calc) #same as R2
    if B>50 or IC50_err>10 or R2[0,1]<0.6: continue
    for pname in p.split(';'):
      print(pname, "IC50=", B, "+/-", IC50_err, "Hill=", A, "R2=", R2[0,1]) #,pR2[0]
    #debug
    #continue
    #plt.scatter(ydata, y_calc, c='b')
    #plt.scatter(y0, y_calc0, c='r')
    #plt.scatter(xdata, ydata, c='b')
    #x2 = np.linspace(0.0, 70.0, 71)
    #y2 = [func(i, popt[0], popt[1], popt[2]) for i in x2]
    #plt.plot(x2, y2, 'r')
    #plt.show()
#  except:
#    ydata = map_pro_dat[p]
#    print("debug:", p, ydata)

