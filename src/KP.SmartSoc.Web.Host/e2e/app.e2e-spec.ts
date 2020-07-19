import { SmartSocTemplatePage } from './app.po';

describe('SmartSoc App', function() {
  let page: SmartSocTemplatePage;

  beforeEach(() => {
    page = new SmartSocTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
