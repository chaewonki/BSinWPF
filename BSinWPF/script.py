import requests
from bs4 import BeautifulSoup

def scrape_news_headlines():
    
    response = requests.get('https://finance.naver.com/news/mainnews.naver')

    if response.status_code == 200:
    
        soup = BeautifulSoup(response.text, 'html.parser')

        headlines = soup.find_all('dd', class_='articleSubject')
        
        my_list = []
        
        for headline in headlines:
            my_list.append(headline.text.strip())
        
        return my_list
            
    else:
        return "Error: {response.status_code}"

