import matplotlib.pyplot as plt

def barPlot(names, values, title):
    plt.figure()
    plt.bar(names, values)
    plt.suptitle(title)
    plt.show()

# test
if __name__ == '__main__':
    x = ['10', '9', '8', '7', '6', '5', '4', '3', '2', '1']
    y = [264388, 231085, 305071, 213760, 102473, 48574, 24006, 15165, 10938, 28108]
    barPlot(x, y, "Test")
