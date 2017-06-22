from __future__ import division, print_function # Makes division and printing work like python 3 (we're using 2)
import os
import numpy as np
import pandas as pd
import csv
from matplotlib import pyplot as plt
import seaborn as sns # Load seaborn with default settings

X = []
Y = []
A = []
B = []
I = []
J = []
with open('susceptible_average.csv', 'rb') as csvfile_s:
	reader_s = csv.reader(csvfile_s)
	i = 0
	for row in reader_s:
		if i == 0:
			i = i + 1
			continue


		X.insert(i, row[0])
		Y.insert(i, row[6])
		i = i + 1

with open('infected_average.csv', 'rb') as csvfile_i:
	reader_i = csv.reader(csvfile_i)
	j = 0
	for row in reader_i:
		if j == 0:
			j = j + 1
			continue

		A.insert(i, row[0])
		B.insert(i, row[6])
		j = j + 1

with open('recovered_average.csv', 'rb') as csvfile_r:
	reader_r = csv.reader(csvfile_r)
	k = 0
	for row in reader_r:
		if k == 0:
			k = k + 1
			continue

		I.insert(i, row[0])
		J.insert(i, row[6])
		k = k + 1
#X = np.linspace(0, 55, 256,endpoint=True) # Evenly spaced numbers over the specified interval

plt.figure(figsize=(8,5))
plt.plot( X, Y, label='Susceptible')
plt.plot(A, B, label='Infected')
plt.plot(I, J, label='Recovered')
plt.legend()
plt.show()