name = "John"
x = 5
y = 3
status = False


#  EXPRESSION 1   AND  EXPRESSION 2
#     TRUE              FLASE

'''
    -- AND -- BOTH CONDITIONS MUST BE TRUE
    EX1     EX2     RESULT
    F       F       F
    T       F       F
    F       T       F
    T       T       T

    -- OR -- ONLY ONE CONDITION MUST BE TRUE
    EX1     EX2     RESULT
    F       F       F
    T       F       T
    F       T       T
    T       T       T
'''
#  [         False        ]
#  [                       TRUE     ]
#  [                                             TRUE  ]
if name == "Joe" and y == 3 or x == 5 and status == True :
    print("Executed...")
else:
    print("Condition not met!")