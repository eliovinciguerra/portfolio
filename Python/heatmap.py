#This script shows the heatmap of the data referenced by "file" variable.

import pandas as pd
import matplotlib.pyplot as plt
import seaborn as sns
import os

file="./file.csv"

data = pd.read_csv(file)
plt.plot(data[['Field1','Field2','Field3','Field4']])
plt.legend(['Field1','Field2','Field3','Field4'],loc="upper left")
data=data.pivot_table(values='Field4', index='point')
g=plt.figure('Heatmap')
g=sns.heatmap(data)
g.set_title('Heatmap')
g.invert_yaxis()
plt.tight_layout()
plt.show()
