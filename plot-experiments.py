import numpy as np
from matplotlib import pyplot as plt;

nmb_to_read_from = 1

data = []
f = open(f"./results/experiments-result-{nmb_to_read_from}.txt", "r")
counter = 0
for x in f:
  counter += 1
  data.append([counter, int(x)])

f = open(f"./results/squaresum-{nmb_to_read_from}.txt", "r")
for x in f:
  squaresum = int(x)

data = np.array(data)
for i in range(100):
  plt.scatter(i, squaresum, color="blue")

x, y = data.T
plt.scatter(x,y, color="red")
plt.show()