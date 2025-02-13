function convertToItalic(text) {
    return text.replace(/(?<!\*)\*(.*?)\*(?!\*)/g, '<i>$1</i>');
  }
  
  const inputText = "Это *текст* с *курсивом*, но **жирный текст** не должен изменяться.";
  const result = convertToItalic(inputText);
  
  console.log(result);
