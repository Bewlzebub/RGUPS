const urlRegex = /^(https?:\/\/)?([a-zA-Z0-9]([a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z]{2,}(:\d+)?(\/[^\s]*)?(\?[^\s]*)?(#[^\s]*)?$/;

const testUrls = [
  "http://www.zcontest.ru",
  "http://zcontest.ru", 
  "Just Text",
  "http://a.com",
  "https://example.com:8080/path?query=1#anchor",
  "http://-example.com",
  "http://example_.com",
];

testUrls.forEach(url => {
  console.log(`${url} is valid: ${urlRegex.test(url)}`);
});