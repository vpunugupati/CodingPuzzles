def ZigZagConversion(s,numRows):
    lin = 0
    pl = 1
    outp = [""] * numRows
    for i in range(len(s)):
        outp[lin] += s[i]
        if numRows > 1:
            lin += pl
            if lin == 0 or lin == numRows -1:
                pl *= -1
    outputStr = ""
    for j in range(numRows):
        outputStr += outp[j]
    return outputStr

s = "PAYPALISHIRING"
numRows = 4
res = ZigZagConversion(s,numRows)
print(res)
