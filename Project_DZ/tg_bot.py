import datetime
import json
from aiogram import Bot, Dispatcher, types, executor
from aiogram.utils.markdown import hbold, hunderline, hcode, hlink
from aiogram.dispatcher.filters import Text
from config import token
from DZ_v1 import check_news_update


bot = Bot(token = token, parse_mode = types.ParseMode.HTML)
dp = Dispatcher(bot)


@dp.message_handler(commands = "start")
async def get_all_news(message: types.Message):
    start_buttons = ["Все новости", "Последние 5 новостей", "Свежие новости"]
    keyboard = types.ReplyKeyboardMarkup(resize_keyboard = True)
    keyboard.add(*start_buttons)

    await message.answer("Лента новостей", reply_markup = keyboard)


@dp.message_handler(Text(equals="Все новости"))
async def get_all_news(message: types.Message):
    news = []
    with open('news_dict.json', 'r', encoding='utf-8') as file:
        news_dict = json.load(file)

    for k, v in sorted(news_dict.items()):
        news = (f"{hbold(datetime.datetime.fromtimestamp(v['article_date_timestamp']))}\n" \
                f"{hlink(v['article_title'], v['article_url'])}")

        await message.answer(news)



@dp.message_handler(Text(equals="Последние 5 новостей"))
async def get_last_five_news(message: types.Message):
    news = []
    with open('news_dict.json', 'r', encoding='utf-8') as file:
        news_dict = json.load(file)

    for k, v in sorted(news_dict.items())[-5:]:
        news = (f"{hbold(datetime.datetime.fromtimestamp(v['article_date_timestamp']))}\n" \
                f"{hlink(v['article_title'], v['article_url'])}")

        await message.answer(news)


@dp.message_handler(Text(equals="Свежие новости"))
async def get_fresh_news(message: types.Message):

    with open('news_dict.json', 'r', encoding='utf-8') as file:
        news_dict = json.load(file)

    fresh_news = check_news_update()

    if len(fresh_news) >= 1:
        for k, v in sorted(news_dict.items())[-5:]:
            news = f"{hbold(datetime.datetime.fromtimestamp(v['article_date_timestamp']))}\n" \
                f"{hlink(v['article_title'], v['article_url'])}"

            await message.answer(news)
    else:
        await message.answer("Свежих новостей пока что нет(")



if __name__ == '__main__':
    executor.start_polling(dp)