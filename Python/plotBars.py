#With this script, you can graph elements in 2 colums, correct and wrong

import numpy as np
import pandas as pd
import matplotlib.pyplot as plt


file="./file.csv"

data = pd.read_csv(file,sep=",",decimal=".")
name=[]
valuesCorr=[]
valueWr=[]
lenFile=len(np.array(data))

barWidth = 0.25
fig = plt.subplots(figsize =(12, 8))

# Set position of bar on X axis
br1 = np.arange((lenFile/12))
br2 = [x + barWidth for x in br1]

i = 0
while i < lenFile:
  if(np.array(data["FieldTaken"])[i]==np.array(data["ActualField"])[i]):
    correct+=1
  else:
    wrong+=1

  if(np.array(data["ActualField"])[i])!=np.array(data["ActualField"])[i-1])):
    valuesCorr.append(correct)
    #valuesCorr.append(correct*(100/12))    #percentual
    valueWr.append(wrong)
    #valueWr.append(wrong*(100/12))         #percentual

  i += 1
  name.append(round(i/12))

plt.bar(br1, valuesCorr, color ='g', width = barWidth, edgecolor ='grey', label ='LabelGreen')
plt.bar(br2, valueWr, color ='r', width = barWidth, edgecolor ='grey', label ='LabelRed')

plt.xlabel('x', fontweight ='bold', fontsize = 15)
plt.ylabel('y', fontweight ='bold', fontsize = 15)

plt.xticks([r + barWidth for r in range(int(lenFile/12))], name)

plt.title('Plot', fontweight ='bold', fontsize = 15)
plt.legend()
plt.show()
