Feature: GETMaxState
	In order to pass interview questions, these code must be written

@positiveTest
Scenario: GET Request for a Max State
	Given An Endpoint containing USA states
	When User make a GET API to USA states Endpoint
	Then Validate the max state in the result
