# Regex > Applications > Detecting Valid Latitude and Longitude Pairs
# Can you detect the Latitude and Longitude embedded in text snippets, using regular expressions?
#
# https://www.hackerrank.com/challenges/detecting-valid-latitude-and-longitude/problem
# https://www.hackerrank.com/contests/regex-practice-1/challenges/detecting-valid-latitude-and-longitude
# challenge id: 1086
#

import re
import sys

N = int(input())
pattern = '\([-+]?([1-9]\d*\.[0-9]+|[1-9]\d*),\s[-+]?([1-9]\d*\.[0-9]+|[1-9]\d*)\)'
regexp = re.compile(pattern)

for i in range(0, N):
    match = regexp.search(input())
    if match:
        lat = float(match.group(1))
        lon = float(match.group(2))
        if lat >= 0.0 and lat <= 90.0 and lon >= 0.0 and lon <= 180.0:
            print("Valid")
        else:
            print("Invalid")
    else:
        print("Invalid")