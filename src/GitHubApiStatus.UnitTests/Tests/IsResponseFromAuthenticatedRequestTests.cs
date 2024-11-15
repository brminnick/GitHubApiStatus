﻿using System.Net.Http;
using System.Net.Http.Headers;
using NUnit.Framework;

namespace GitHubApiStatus.UnitTests;

class IsAuthenticatedTests : BaseTest
{
	[Test]
	public void IsResponseFromAuthenticatedRequest_ValidHttpResponseHeaders_True()
	{
		//Act
		bool isUserAuthenticated_Actual;

		const int rateLimit = 5000;
		const int rateLimitRemaining = 0;
		const bool isUserAuthenticated_Expected = true;

		var validHttpResponseHeaders = CreateHttpResponseHeaders(rateLimit, DateTimeOffset.UtcNow, rateLimitRemaining, isAuthenticated: isUserAuthenticated_Expected);

		//Act
		isUserAuthenticated_Actual = GitHubApiStatusService.IsResponseFromAuthenticatedRequest(validHttpResponseHeaders);

		//Assert
		Assert.That(isUserAuthenticated_Actual, Is.EqualTo(isUserAuthenticated_Expected));
	}

	[Test]
	public void IsResponseFromAuthenticatedRequest_ValidHttpResponseHeaders_False()
	{
		//Act
		bool isUserAuthenticated_Actual;

		const int rateLimit = 5000;
		const int rateLimitRemaining = 10;
		const bool isUserAuthenticated_Expected = false;

		var validHttpResponseHeaders = CreateHttpResponseHeaders(rateLimit, DateTimeOffset.UtcNow, rateLimitRemaining, isAuthenticated: isUserAuthenticated_Expected);

		//Act
		isUserAuthenticated_Actual = GitHubApiStatusService.IsResponseFromAuthenticatedRequest(validHttpResponseHeaders);

		//Assert
		Assert.That(isUserAuthenticated_Actual, Is.EqualTo(isUserAuthenticated_Expected));
	}

	[Test]
	public void IsResponseFromAuthenticatedRequest_InvalidHttpResponseHeaders()
	{
		//Arrange
		var invalidHttpResponseMessage = new HttpResponseMessage();

		//Act
		var isUserAuthenticated = GitHubApiStatusService.IsResponseFromAuthenticatedRequest(invalidHttpResponseMessage.Headers);

		//Assert
		Assert.That(isUserAuthenticated, Is.False);
	}

	[Test]
	public void IsResponseFromAuthenticatedRequest_NullHttpResponseHeaders()
	{
		//Arrange
		HttpResponseHeaders? nullHttpResponseHeaders = null;

		//Act

		//Assert
#pragma warning disable CS8604 // Possible null reference argument.
		Assert.That(() => GitHubApiStatusService.IsResponseFromAuthenticatedRequest(nullHttpResponseHeaders), Throws.TypeOf<GitHubApiStatusException>());
#pragma warning restore CS8604 // Possible null reference argument.
	}
}




