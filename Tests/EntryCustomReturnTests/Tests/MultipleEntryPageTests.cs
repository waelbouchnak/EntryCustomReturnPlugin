﻿using NUnit.Framework;

using Xamarin.UITest;
using System.Text;
using EntryCustomReturnSampleApp.Shared;

namespace EntryCustomReturnUITests
{
	public class MultipleEntryPageTests : BaseTest
	{
		public MultipleEntryPageTests(Platform platform) : base(platform)
		{
		}

		public override void TestSetup()
		{
			base.TestSetup();

			OptionSelectionPage.WaitForPageToLoad();
		}

		[TestCase(CustomEntryType.Effects)]
		[TestCase(CustomEntryType.CustomRenderers)]
		[Test]
		public void EnterTextIntoMultipleEntriesUsingReturnButton(CustomEntryType customEntryType)
		{
			//Arrange
			const string enteredText = "Hello World";
			var expectedLabelTextStringBuilder = GetExpectedLabelText(enteredText);


			//Act
			OptionSelectionPage.SetEntryPickerType(customEntryType);
			OptionSelectionPage.TapOpenMultipleEntryPageButton();

			MultipleEntryPage.EnterTextIntoAllEntrysUsingReturnButton(enteredText);

			//Assert
			var retrievedLabelText = MultipleEntryPage.ResultsLabelText;
			Assert.AreEqual(expectedLabelTextStringBuilder, retrievedLabelText);
		}

		[TestCase(CustomEntryType.Effects)]
		[TestCase(CustomEntryType.CustomRenderers)]
		[Test]
		public void EnterTextIntoMultipleEntriesWithoutUsingReturnButton(CustomEntryType customEntryType)
		{
			//Arrange
			const string enteredText = "Hello World";
			var expectedLabelTextStringBuilder = GetExpectedLabelText(enteredText);

			//Act
			OptionSelectionPage.SetEntryPickerType(customEntryType);
			OptionSelectionPage.TapOpenMultipleEntryPageButton();

			MultipleEntryPage.EnterNextReturnTypeEntryText(enteredText);
			MultipleEntryPage.EnterDoneReturnTypeEntryText(enteredText);
			MultipleEntryPage.EnterSendReturnTypeEntryText(enteredText);
			MultipleEntryPage.EnterSearchReturnTypeEntryText(enteredText);
			MultipleEntryPage.EnterGoReturnTypeEntryText(enteredText);

			MultipleEntryPage.TapGoButton();

			//Assert
			var retrievedLabelText = MultipleEntryPage.ResultsLabelText;
			Assert.AreEqual(expectedLabelTextStringBuilder, retrievedLabelText);
		}
		string GetExpectedLabelText(string enteredText)
		{
			var expectedLabelTextStringBuilder = new StringBuilder();
			expectedLabelTextStringBuilder.AppendLine("NextReturnTypeEntryText:");
			expectedLabelTextStringBuilder.AppendLine($"\t{enteredText}");
			expectedLabelTextStringBuilder.AppendLine();

			expectedLabelTextStringBuilder.AppendLine($"DoneReturnTypeEntryText:");
			expectedLabelTextStringBuilder.AppendLine($"\t{enteredText}");
			expectedLabelTextStringBuilder.AppendLine();

			expectedLabelTextStringBuilder.AppendLine($"GoReturnTypeEntryText:");
			expectedLabelTextStringBuilder.AppendLine($"\t{enteredText}");
			expectedLabelTextStringBuilder.AppendLine();

			expectedLabelTextStringBuilder.AppendLine($"SearchReturnTypeEntryText:");
			expectedLabelTextStringBuilder.AppendLine($"\t{enteredText}");
			expectedLabelTextStringBuilder.AppendLine();

			expectedLabelTextStringBuilder.AppendLine($"SendReturnTypeEntryText:");
			expectedLabelTextStringBuilder.AppendLine($"\t{enteredText}");
			expectedLabelTextStringBuilder.AppendLine();

			return expectedLabelTextStringBuilder.ToString();
		}
	}
}
