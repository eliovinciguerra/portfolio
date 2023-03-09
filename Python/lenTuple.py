#With this script you can get the length (in terms
# of rows) of the csv file referenced by "file".

import numpy as np
import pandas as pd


file="./file.csv"

data = pd.read_csv(file,sep=",",decimal=".")

print(len(np.array(data)))
