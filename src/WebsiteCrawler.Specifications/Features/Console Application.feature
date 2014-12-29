Feature: Console Application
	In order to test all links of a web site
	As a web master
	I want to specify a website to crawl

Scenario: Run console application with valid arguments
	When I run the console application with valid arguments
	Then the web site is crawled
	And the report is created
	And the report lists all internal links

Scenario: Run console application with invalid arguments
	When I run the console application with invalid arguments
	Then the application help is displayed
