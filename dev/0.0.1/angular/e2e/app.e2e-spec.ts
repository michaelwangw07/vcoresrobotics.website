import { websiteTemplatePage } from './app.po';

describe('website App', function() {
  let page: websiteTemplatePage;

  beforeEach(() => {
    page = new websiteTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
