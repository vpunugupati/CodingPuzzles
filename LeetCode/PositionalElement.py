def PositionalElements(matrix):
    nRows= len(matrix)
    nCount=0  
    for row in matrix:
        for indexCol, element in enumerate(row):    
            if element==min(row) or element==max(row):
                if row.count(element)>1:
                    return -1
                nCount=nCount+1        
            else:
                listColumn=[]
        
                for indexRow in range(0, nRows):
                    listColumn.append(matrix[indexRow][indexCol])
        
                if element==min(listColumn) or element==max(listColumn):
                    if listColumn.count(element)>1:
                        return -1
                    nCount=nCount+1 
    return nCount


matrix = [[1,3,4],[5,2,9],[8,7,6]]
np = PositionalElements(matrix)
print(np)