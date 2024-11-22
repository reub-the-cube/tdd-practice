# Requirements

The parenting community are demanding that some higly flexible and complex rules for awarding pocket money are built into an application so that they don't have to think too hard. Write some code that calculates how much pocket money is due each week for each individual the parents award pocket money to. There is a base amount that is always recieved, then there is an amount that is given based on chores, and an amount that is given based on behaviour.

- The base amount can be whatever you like.
- A chore amount is given each day if all the chores are done.
- A chore amount is given each week if any given daily chore is done on all days.
- A chore bonus is given each week if all daily chores are done every day.
- A behaviour amount is awarded for each time good behaviour is recognised.
- A behaviour amount is taken away for each time poor behaviour is recognised.
- A behaviour amount does not have to start at 0p at the start of the week.
- The total behaviour amount has a minimum and a maximum amount that it can't exceed when pocket money is due.
- Pocket money for the whole week cannot be less than 0p


## Example 1

Aleya, Bernie, Chloe and Depak are quadruplets and have the same set of rules that reward doing chores and good behaviour. The rules are:
- they receive a base amount of 50p
- they have 4 daily chores
- they receive 10p for each day they complete all their daily chores
- they receive 5p for each daily chore they complete every day of the week
- they receive a 10p bonus for doing all daily chores on all days
- they have no weekly chores
- they start the week with 50p in their behaviour pot but they can't go above that or below 0p

Aleya had a good week. She did all her chores on all days except for Wednesday when she didn't make her bed. She was recognised for good behaviour with 20p but had 15p taken away for poor listening.

Aleya is due £1.75.

**50p** (base) + **60p** (6 days where she did all her chores) + **15p** (3 chores she did every day) + **50p** (50p starting amount plus 20p for good behaviour minus 15p for poor behaviour)

Bernie didn't brush he teeth nicely on three days, and on one of those days he didn't make his bed either. He was a bit unwell but that doesn't excuse his poor behaviour and he had 70p taken off for poor behaviour.

Bernie is due £1.00.

**50p** (base) + **40p** (4 days where he did all his chores) + **10p** (2 chores he did every day) + **0p** (50p starting amount minus 70p for poor behaviour)

Charlie didn't make her bed one day, and on another day she didn't help pack the dishwasher or brush her teeth nicely. She didn't have any behaviour amounts awared or taken away.

Charlie is due £1.55.

**50p** (base) + **50p** (5 days where she did all her chores) + **5p** (1 chore she did every day) + **50p** (50p starting amount)

Depak did all their chores on all days and has a delta of -10p for their behaviour.

Depak is due £1.90.

**50p** (base) + **70p** (7 days where they did all their chores) + **20p** (4 chores they did every day) + **10p** (chore bonus) + **40p** (50p starting amount minus 10p for poor behaviour)

## Example 2

Eddie's pocket-money givers have a lot of chores for him to do but he is handsomely rewarded! He must earn his keep through chores. The rules are:
- he has no base amount
- he has 5 daily chores
- he receives 25p for each day he completes all his chores
- he doesn't receive anything for doing a daily chore every day of the week
- he receives 25p for doing all daily chores every day
- he has 3 weekly chores
- he receives 50p for each weekly chore he completes
- he receives a 50p bonus for completing all of his weekly chores
- he doesn't receive any money based on behaviour

In week one, Eddie got off to a good start doing all his daily chores every day and 2 of his weekly chores.

Eddie is due £3.00.

**0p** (base) + **£1.75** (7 days where he did all his chores) + **25p** (daily chore bonus) + **£1** (2 weekly chores)

In week two, Eddie did 4 of his chores every day but only made his bed once! He did all his weekly chores though.

Eddie is due £2.25.

**0p** (base) + **25p** (1 day where he did all his chores) + **£1.50** (3 weekly chores) + **50p** (weekly chore bonus)

In week three, his rules changes so that he got a 10p bonus for each daily chore he completed each day of the week. He did the same as the previous week.

Eddie is due £2.65.

**£2.25** (same as previous week) + **40p** (4 chores he did every day of the week)

# Additional requirements

- You may want to collect pocket money over different time periods (if it's daily, how can you do weekly bonuses?)
- You may want to have a different number of chores
- You may want to collect different amounts
- You may want to view pocket money totals over time
- You may want to have different rules for different pocket money receivers