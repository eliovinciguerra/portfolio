#With this script you can read information from all csv you have
# file in your folder, rename the Fields and save in float type.

import numpy as np
import pandas as pd
import glob

all_filenames = [i for i in glob.glob('*.{}'.format('csv'))]
all_filenames = sorted(all_filenames, key=lambda x: (int(x.split('.csv')[0])))
combined_csv=pd.DataFrame()
for f in all_filenames:
    data = pd.read_csv(f,sep=";",decimal=",")
    point=f.strip('.csv')
    df=pd.DataFrame()
    for i in range(len(np.array(data))):
        tmp = {
                    "Field1": float(np.array(data["Name Field1"])[i]),
                    "Field2":[ float(np.array(data["Name Field2"])[i])]
        }
        df=pd.concat([df, pd.DataFrame(tmp)], ignore_index = True, sort = False)
        df.to_csv(f ,index=False, header=True, encoding='utf-8-sig')
