#With this script you can plot the various data you have
# collected into a graph.


import numpy as np
import matplotlib.pyplot as plt
from mpl_toolkits.mplot3d import Axes3D
from scipy import linalg
import pandas as pd
import os
import glob
from scipy.signal import filtfilt
import math


file="./file.csv"

data = pd.read_csv(file,sep=",",decimal=".")
#os.chdir(os.path.dirname(file))

Field1 = data["Field1"]
Field2= data["Field2"]
Field3 = data["Field3"]

x = np.array(Field1)

fig, ax = plt.subplots()

ax.plot(x, np.array(Field2), 'o',label='Field2')
ax.plot(x, np.array(Field3), 'o',label='Field3')
ax.set_xlabel('x')
ax.set_ylabel('y')
ax.set_title("Test")
ax.legend()
plt.show()
fig.savefig("Graph")


print("Completed!")
