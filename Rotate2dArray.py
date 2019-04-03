def rotate90(table):
    size = len(table)
    layer_count = size // 2

    for layer in range(0, layer_count):
        first = layer
        last = size - first - 1

        for element in range(first, last):
            offset = element - first
            temp = table[element][last]                               # right = temp

            table[element][last] = table[first][element]              # top right = top left
            table[first][element] = table[last - offset][first]       # top left = bottom left
            table[last - offset][first] = table[last][last - offset]  # bottom left = bottom right
            table[last][last - offset] = temp                         # bottom right = temp


def print2DArray(array):
    for i in range(len(array)):
        for j in range(len(array[0])):
            print(array[i][j], end=" ")
        print("")


matrix = list()
size = 10

for i in range(size):
    element = list()
    for j in range(size):
        element.append(size*i + j + 1)
    matrix.append(element)


print("Python Implementation")
print('Original')
#print2DArray(matrix)
print("")
print("After Rotation")
rotate90(matrix)
print2DArray(matrix)
