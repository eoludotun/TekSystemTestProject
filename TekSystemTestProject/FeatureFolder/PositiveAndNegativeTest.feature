Feature: PositiveAndNegativeTest
	This will be an attempt to validate some response code 
	


@postive
Scenario: Validate Positive Request response code 
	Given An Endpoint containing USA states
	When User make a Valid GET request to API Endpoint
	Then Validate the response(s) code are 200



@negative
Scenario: Validate negative Request response code 
	Given An API containing invalid endpoint
	When User make an invalid GET request to API Endpoint
	Then Validate the response(s) code are 404