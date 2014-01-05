import json
import time 

encoded_object = '{"programPath": "C:/Program Files (x86)/uTorrent/uTorrent.exe", "attr1": "stuff"}'
jdata = json.loads(encoded_object)

for key, value in jdata.iteritems():
    print key, value

raw_input()