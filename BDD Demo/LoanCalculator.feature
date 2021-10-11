Feature: LoanCalculator
	As a user 
	I want all finacial calculators in on place that are easy to use
	So that I can compare loans from different banks and calculate witch one is the best for me

Scenario Outline: Calculate Personal Loan
	Given that the personal loan calculator page is open
	When I enter the loan amount <amount>
	And I enter the interest rate <rate>
	And I enter the insurance rate <insurance>
	And I enter the loan term in years <years>
	And I press the calculate button
	Then the monthly pay is calculated <pay>
Examples: 
	| example description   | amount | rate | insurance | years | pay   |
	| Valid data            | 5000   | 3.4  | 0         | 5     | 90.73 |
	| Amount lower boundary | 1      | 3.4  | 0         | 5     | 0.02  |
	| Rate boundary         | 5000   | 0    | 0         | 5     | 83.33 |

Scenario Outline: Calculate Personal Loan Dynamic data
	Given that the personal loan calculator page is open
	When I enter the loan amount <amount>
	And I enter the interest rate <rate>
	And I enter the loan term in years <years>
	And I press the calculate button
	Then the monthly pay for loan amount interest rate and loan term in years is calculated <amount> <rate> <years> 
Examples: 
	| example description | amount   | rate     | years    |
	| Valid data          | valid    | valid    | valid    |
	| Boundary data       | boundary | boundary | boundary |

Scenario Outline: Calculate Personal Loan with invalid data
	Given that the personal loan calculator page is open
	When I enter the loan amount <amount>
	And I enter the interest rate <rate>
	And I enter the insurance rate <insurance>
	And I enter the loan term in years <years>
	And I press the calculate button
	Then the error message is displayed <error>
Examples: 
	| example description | amount | rate | insurance | years | error                                            |
	| Invalid insurance   | 5000   | 3.4  | -1        | 5     | Please provide a personal loan insurance amount. |
	| Invalid years       | 5000   | 3.4  | 0         | -5    | Please provide a positive loan term year value.  |
	| Invalid rate        | 5000   | -1   | 0         | 5     | Please provide a positive interest rate value.   |
	| Invalid amount      | -1     | 3.4  | 0         | 5     | Please provide a positive loan amount.           |

Scenario Outline: Calculate Auto Loan
	Given that the auto loan calculator page is open
	When I enter the loan amount <amount>
	And I enter the interest rate <rate>
	And I enter the down payment <payment>
	And I enter the trade in value <trade>
	And I press the calculate button
	Then the monthly pay is calculated <pay>
Examples: 
	| example description   | amount | rate | payment | trade | pay   |
	| Valid data            | 5000   | 3.4  | 200     | 5     | 87.01 |
	| Amount lower boundary | 1      | 3.4  | 200     | 5     | -3.70 |
	| Rate boundary         | 5000   | 0    | 200     | 5     | 79.92 |

Scenario Outline: Calculate Auto Loan with invalid data
	Given that the auto loan calculator page is open
	When I enter the loan amount <amount>
	And I enter the interest rate <rate>
	And I enter the down payment <payment>
	And I enter the trade in value <trade>
	And I press the calculate button
	Then the error message is displayed <error>
Examples: 
	| example description | amount | rate | payment | trade | error                                         |
	| Invalid payment     | 5000   | 3.4  | -2      | 5     | Please provide a positive down payment value. |
	| Invalid trade       | 5000   | 3.4  | 200     | -5    | Please provide a positive trade-in value.     |
	| Invalid rate        | 5000   | -1   | 200     | 5     | Please provide a positive interest value.     |
	| Invalid amount      | -1     | 3.4  | 200     | 5     | Please provide a positive auto price.         |