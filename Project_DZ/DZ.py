import requests
from datetime import datetime
import telebot
from config import token


def get_data():
    req = requests.get("https://yobit.net/api/3/ticker/btc_usd")
    responce = req.json()
    sell_price = responce["btc_usd"]["sell"]
    print(f"{datetime.now().strftime('%Y-%m-%d %H:%M')}\nSell BTC price: {sell_price}")


def telegram_bot(token):
    bot = telebot.TeleBot(token)

    @bot.message_handler(commands = ["start"])
    def start_message(message):
        bot.send_message(message.chat.id, "Здравствуйте, Елизавета Андреевна")
    
    @bot.message_handler(content_types = ["text"])
    def send_text(message):
        if message.text.lower() == "ты абоба" or message.text.lower() == "нет, ты абоба":
            try:
                bot.send_message(message.chat.id, "Нет, ты абоба" )
            except Exception as ex:
                print(ex)
                bot.send_message(message.chat.id, "Что-то пошло не так")
        else:
            bot.send_message(message.chat.id, "Ты абоба")

    bot.polling()


if __name__ == '__main__':
    #get_data()
    telegram_bot(token)
