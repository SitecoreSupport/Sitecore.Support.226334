namespace Sitecore.Support.ContentTesting.Pipelines.GetTests
{
  using Sitecore.ContentTesting.Data;
  using Sitecore.ContentTesting.Inspectors;
  using Sitecore.ContentTesting.Pipelines.GetTests;
  using Sitecore.ContentTesting.Tests;
  using Sitecore.Diagnostics;
  using Sitecore.Layouts;

  public class GetPersonalizationTests : Sitecore.ContentTesting.Pipelines.GetTests.GetPersonalizationTests
  {
    public override void Process(GetTestsArgs args)
    {
      Assert.ArgumentNotNull(args.Item, "args.Item");
      foreach (RenderingDefinition rendering in new TestingRenderingInspector(args.Item, (SitecoreContentTestStore)null)
      {
        InspectionMode = TestingRenderingInspector.Mode.Personalization,
        DeviceId = args.DeviceId,
        EnsureTestIsNotRunning = true
      }.GetRenderings())
      {
        if (string.IsNullOrEmpty(rendering.PersonalizationTest) == false) // This can help to prevent consider as test
        {
          args.AddTest(new PersonalizationTest(rendering, args.Item));
        }
      }
    }
  }
}