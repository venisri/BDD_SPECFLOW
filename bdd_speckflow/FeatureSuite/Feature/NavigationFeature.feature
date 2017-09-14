Feature: NavigationFeature
	Feature to verify the links navigation 

@UI
Scenario: VerifyGermanyLinkNavigation
	Given I have entered the URL of KLM
	And Iam on the Welcomepage of KLM
	When I clicked  on the Germany  Link
	Then I should landed on the Germany Page
	

@UI
Scenario: VerifyNorwayLinkNavigation
	Given I have entered the URL of KLM
	And Iam on the Welcomepage of KLM
	When I clicked  on the Norway  Link
	Then I should landed on the Norway Page


@UI
Scenario: VerifyUKLinkNavigation
	Given I have entered the URL of KLM
	And Iam on the Welcomepage of KLM
	When I clicked  on the UK  Link
	Then I should landed on the UK Page

	@smoketest
Scenario:Search for the Flights
	Given I have entered the URL of KLM
	And Iam on the Welcomepage of KLM
	When I clicked  on the Norway  Link
	Then I should landed on the Norway Page
