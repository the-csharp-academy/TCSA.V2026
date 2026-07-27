using TCSA.V2026.Data.Models;

namespace TCSA.V2026.Data.Curriculum;

public static class BlogHelper
{
    public static List<Article> GetArticles() =>
    [
            new Article
            {
                Id = 30011,
                Title = "Five Years as a Professional Software Engineer",
                IconUrl = "",
                Slug = "five-years-as-a-professional-software-engineer",
                BannerUrl = "",
                CardImgUrl = "blog6.jpg",
                Description = "Reflections on five years working professionally as a software engineer, the people who made the journey possible, and what comes next.",
                ReleaseDate = new DateTime(2026, 7, 22),
                Area = Area.Blog,
                Blocks = new List<Block>
                {
                    new Block
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "Five years as a professional software engineer. I have reasons to celebrate. During this time probably as a defense mechanism I’ve always had in the back of my mind that I could be fired at any minute. And this sensation that has obviously been intensified in the last couple of years while observing the advancements of AI."
                            },
                            new Paragraph
                            {
                                Body = "But I got there. No matter what happens from now I’ve worked for five years professionally as a dev and nobody can take that away from me or from my resume. It’s still scary to see how far AI got and it still makes me think its future advancements can render us all useless, but that’s a subject for another post."
                            }
                        }
                    },
                    new Block
                    {
                        Title = "Reflection",
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "There’s a lot I can say about these years, but I’m going to keep it simple. There’s no point trying to remember everything and cram into this post. It wouldn’t make justice to the experience. Hopefully I’ll be able to share some experiences in later posts."
                            },
                            new Paragraph
                            {
                                Body = "The most important thing to acknowledge is how lucky I have been. I’ve worked with fantastic people. I’ve had two technical managers and they’re both fantastic in many ways. Extremely knowledgeable, humble, and fair. I never felt micro-managed. I always felt supported. They were stern when needed to but never ever rude, even when I made mistakes. Top-shelf leaders and mentors. Just great people all-around."
                            },
                            new Paragraph
                            {
                                Body = "I’ve also been lucky to work under very intelligent and competent senior devs. I owe everything I know in coding to these guys. They’ve closed witnessed my incompetence by reviewing my code and were very patient with me. A good chunk of my pull-requests in these four years came back with comments for improvements. They were always graceful about it even when my PRs were subpar. Oh, and always approachable and open to questions - and I did ask a lot of stupid ones. From them I’ve not only learned professionalism but how to treat people, especially juniors."
                            },
                            new Paragraph
                            {
                                Body = "Lastly I’ve been lucky to be able to work remotely for four of these five years. While it did present a challenge to my will power and discipline (it’s too easy to go grab another biscuit or make another trip to the kettle), it’s undeniable that I lived a very comfortable life during this time."
                            },
                            new Paragraph
                            {
                                Body = "I absolutely don’t take these things for granted. Particularly after having commuted for three hours daily from Brisbane to the Sunshine Coast in my first year as a dev, and having worked as a cleaner, dance teacher and uber driver for my first six years in Australia."
                            },
                            new Paragraph
                            {
                                Body = "I also hear all the time stories of people working under incompetent or rude bosses or unscrupulous colleagues, or being given impossible deadlines and put under too much pressure, not to mention being underpaid, treated unfairly, commuting daily, the list goes on. I’m aware all of those things could happen to me literally tomorrow."
                            },
                            new Paragraph
                            {
                                Body = "Although I’m ambitious and want to further progress in my career, every day I start my workday thinking to myself how happy I am to be able to do what I do and how I’ll still be happy if I’m doing the exact same thing and working with the same people at 10 YOE."
                            },
                            new Paragraph
                            {
                                Body = "Let’s see what the next five years have in store for me and for The C# Academy!"
                            }
                        }
                    },
                    new Block
                    {
                        Title = "Blogging again?",
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "If you’ve followed the academy from the beginning you’ve seen a few failed attempts to get back to blogging. Every time I started writing I thought it was a self-indulgent exercise. Why on earth would anyone want to read about me and my thoughts? I’ve also thought my time would be better spent doing something else: Enhancing the website, reviewing code, learning more stuff to advance in my career, and so on and so forth."
                            },
                            new Paragraph
                            {
                                Body = "This time I think it’s different. After these years working in enterprise development and mentoring people I genuinely think I have something to say. To some extent I regret not having written more. It would have been great to store those memories when they were fresh. And I think now I’m better equipped and have better systems in place to write regularly again. I missed it a lot."
                            },
                            new Paragraph
                            {
                                Body = "PS: I’m not going to use AI to write or proofread any of these. I want to keep this 100% human. If see any butchering of the English language please let me know."
                            }
                        }
                    }
                }
            },
            new Article
            {
                Id = 30000,
                Title = "Legacy: A Little Bit about Me",
                IconUrl = "",
                Slug = "legacy-a-little-bit-about-me",
                BannerUrl = "",
                CardImgUrl = "blog1.png",
                Description = "The personal story behind a late-career leap into programming, the habits that needed to change, and the ambition that started the journey.",
                ReleaseDate = new DateTime(2019, 10, 1),
                Area = Area.Blog,
                Blocks = new List<Block>
                {
                    new Block
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "My name is Pablo de Souza, I’m 37 years old and I consider myself  very lucky. I was born to a middle-class family in Brazil with enough health, resources and education to live a comfortable life. Even though I lived life on my terms, having a lot of fun and never having any major problems, I feel like at this point there’s something missing. I could write many paragraphs of self-psychoanalysis to try and find the reasons for my current restlessness, but I just feel I have the capacity to tailor the rest of my existence on earth in a better way than I’ve done so far. "
                            }
                        }
                    },
                    new Block
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "I have a reasonably well-paid dance teacher job. I love what I do and my annual income puts me amongst the top 2% better paid people on earth. No, that doesn’t mean I’m rich. You don’t need to earn a lot in a first world country to be top 1%. But I can’t see myself as a dance teacher at 50. I definitely want to keep dancing, but I don’t want to rely on my body to earn a living in an industry that values youthfulness and fitness. Hence the need for a career change."
                            }
                        }
                    },
                    new Block
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "Five years ago I migrated to Australia and I’m about a year away from getting a permanent visa, which would allow me the right to study affordably in this beautiful country. The perspective of going back to university made me think deeply about my possibilities and I had my mind set in the health industry (my father is a doctor, my mother a nurse and I have a degree in Sports Science) . The problem is that working in healthcare means I’m stuck geographically in 99% of the jobs and I can’t stand the idea of not doing a bunch of traveling before I go to the grave."
                            }
                        }
                    },
                    new Block
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "Search engines algorithms must have picked up what I needed and presented me with ads for computer programming schools. I did some reading about it and found it appealing. Especially the possibility of self-teaching. Being a doctor or a nurse requires knowledge and qualifications you can only get with formal education. The fact that I could sit all day in front of a computer and learn all I need by myself was very attractive. I envisioned the good old American style self-made man story starting to materialize. "
                            }
                        }
                    },
                    new Block
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "However, down deep I know that the person I need to become to get there doesn’t exist yet. But that person is very attractive to me. I want to become that guy. Driven, focused, curious, disciplined and organized. I think these characteristics summon what I need to be to achieve the goal of becoming a programmer. Right now If I had to give scores from 0 to 5 to myself in each of those attributes I’d say I’m very curious (5), but I’m lacking all of the rest: not disciplined enough (2), not driven enough (2), not focused enough (2), and dismally disorganized (probably a zero)."
                            }
                        }
                    },
                    new Block
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "Search engines algorithms must have picked up what I needed and presented me with ads for computer programming schools. I did some reading about it and found it appealing. Especially the possibility of self-teaching. Being a doctor or a nurse requires knowledge and qualifications you can only get with formal education. The fact that I could sit all day in front of a computer and learn all I need by myself was very attractive. I envisioned the good old American style self-made man story starting to materialize. "
                            }
                        }
                    },
                    new Block
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "That’s why I’m calling this blog <b>Shut up and Code</b>. I’ve read, researched and talked a lot about the subject since I made the decision to learn to code a couple of months ago, but I haven’t spent many hours actually coding. I do value reads that will improve me as a human and give me the big picture of the programming world, but the fact is that I have to make up for starting late and <b>put in the hours</b>. I have to attack this aggressively or <b>I will fail</b>. This is, by miles, beyond anything I’ve ever accomplished in life and the person I currently am doesn’t stand a chance."
                            }
                        }
                    },
                    new Block
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "Right now this blog is for me only. I do want it to tell a successful story of a 37-year-old that against all odds was able to better himself and change careers and hopefully inspire and help people in the future. But at this stage I want to use this space to clarify my ideas, keep me centered, focused and, above all, maintain discipline. I’ve started many blogs and failed to be consistent every single time. This has to change. <b>Now</b>. I’m running out of time. The grave is growing closer."
                            }
                        }
                    },
                    new Block
                    {
                        Title = "2024 Commentary",
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "Right now this blog is for me only. I do want it to tell a successful story of a 37-year-old that against all odds was able to better himself and change careers and hopefully inspire and help people in the future. But at this stage I want to use this space to clarify my ideas, keep me centered, focused and, above all, maintain discipline. I’ve started many blogs and failed to be consistent every single time. This has to change. <b>Now</b>. I’m running out of time. The grave is growing closer."
                            }
                        }
                    },
                    new Block
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "Also, I’m not sure I’ve mentioned this in other posts, but at the time I started writing this blog, I read a fantastic book for folks trying to teach themselves anything: The Art Of Learning, by Josh Waitzkin."
                            },
                            new Paragraph
                            {
                                IsPicture = true,
                                PictureUrl = "blog/art-of-learning.jpg"
                            },
                        }
                    },
                    new Block
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "Not only he was a chess grand-master, but a pushing-hands (competitive tai-chi) champion. The story of how he migrated from one to the other is absolutely fascinating. It was a key factor in my journey to become a developer. Even if you don’t get the book, you need to check this guy out. <a href='https://open.spotify.com/episode/7nOZbb1S6nIJpvEOx94qlc?si=tuvWPVpkS3q6zhR3FJELpg' target='_blank'>Here’s the podcast where I first learned about him</a>"
                            }
                        }
                    },
                    new Block
                    {
                        Title = "2029 Commentary",
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "I'm leaving this paragraph as a placeholder. I hope I’m a senior dev. I hope I’m not unemployed. 😂"
                            }
                        }
                    },
                }
            },
            new Article
            {
                Id = 30001,
                Title = "Why The Hell Am I Creating a Blog Again?",
                IconUrl = "",
                Slug = "why-the-hell-am-i-creating-a-blog",
                BannerUrl = "",
                CardImgUrl = "blog2.png",
                Description = "Why writing still matters, what this new blog will explore, and the case for sharing an honest journey through software development and life.",
                ReleaseDate = new DateTime(2024, 7, 15),
                Area = Area.Blog,
                Blocks = new List<Block>
                {
                    new Block
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "Because I love writing! It’s just what the world bloody needs, right? 😒Another wanky blog. I’ve had a few blogs before, mostly dedicated to football (aka soccer). The latest one documented my attempt to become a software developer. I loved that blog. I’ll try to bring some of those old posts back to life. But what matters is that I’m back to it. I miss it so much!"
                            }
                        }
                    },
                    new Block
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "There won’t be any writing goals. I’ll write when I feel like it, brainstorming-style, with very little editing. You’re likely to find typos everywhere. Please feel free to let me know so it doesn’t look like I’m (totally) illiterate."
                            }
                        }
                    },
                    new Block
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "I have a vague idea of what I want to write about: Dev things. My intention is to write content that will be useful not only for beginners, but for those who have been learning for a while and still haven’t broken into the industry, and for those who are trying what I’m trying: to become a senior dev."
                            }
                        }
                    },
                    new Block
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "In the day and age of Chat GPT, where a lot of the written stuff feel AI-heavy, I pledge to make this blog HUMAN. Authentic. With as little filters as possible. I hope you enjoy."
                            }
                        }
                    }
                }
            },
            new Article
            {
                Id = 30002,
                Title = "How Can I Possibly do All of These Things?",
                IconUrl = "",
                Slug = "how-can-i-possibly-do-all-of-these-things",
                BannerUrl = "",
                CardImgUrl = "blog3.png",
                Description = "A candid look at juggling software development, university, The C# Academy, fitness and family without losing sight of what matters most.",
                ReleaseDate = new DateTime(2024, 7, 22),
                Area = Area.Blog,
                Blocks = new List<Block>
                {
                    new Block
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "This Monday I’m adding extra weight to my already heavy schedule by starting my second semester at university. If I tell you I have started a blog, an Instagram and a Threads account you’ll have a solid case for taking me to a sanatorium. Besides having a demanding full-time software developer job, these are some of my other current activities: Gym almost every day, sometimes twice; running The C# Academy; <a href='https://thecsharpschool.getlearnworlds.com/subscription/the-c-academy-membership' target='_blank'>creating content for my paid courses</a>; teaching dance once a week; studying at least 1h a day, currently focusing on <a href='https://amzn.to/4dImzTe' target='_blank'>Git</a> and <a href='https://amzn.to/3YK6ZCf' target='_blank'>IOT</a>. Oh and trying to <a href='https://amzn.to/4ckS98x' target='_blank'>learn several languages at the same time</a> (what a fool 😆). And that’s just the tip of my iceberg to-do list. All of that while, of course, spending time with my beautiful wife so she doesn’t divorce me."
                            }
                        }
                    },
                    new Block
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "I consider myself <a href='https://amzn.to/3X2fzLr' target='_blank'>an essentialist</a>. I don’t own a lot of things, I don’t spend time scrolling on my phone and never watch TV (except for the world cup, of course, as a good Brazilian). Some of the things that give me the most pleasure are <a href='https://amzn.to/3X0CVkC' target='_blank'>saying NO</a> to requests for my time and throwing unused stuff in the bin. So why more? It might sound contradictory but I deemed these new activities important for my future and calculated that it’s possible to achieve them as long as I have good systems in place. "
                            }
                        }
                    },
                    new Block
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "The next few months will be a test of my organization and discipline. I have a plan. Now I have to f-ing follow it. The general headquarters of my organization will be <a href='https://calendar.google.com/calendar/u/0/r' target='_blank'>Google Calendar</a>. I think it’s a great tool for having a big picture of one’s schedule. It’s great that I can combine it with <a href='https://play.google.com/store/apps/details?id=com.google.android.apps.tasks&hl=en&gl=US&pli=1' target='_blank'>Google Tasks</a> and drag and drop tasks onto my calendar. <a href='https://amzn.to/4cn6NvP' target='_blank'>I use the Getting Things Done method</a> by the great David Allen. It’s an absolute game changer. To summarize, the idea is to dump every possible thing that’s in your mind into lists organized by topics and priority. When I first tried it, it felt like removing one ton off my back. I no longer had to worry about forgotten tasks that weren’t registered anywhere. Obviously the things I had to do hadn’t disappeared, but they were now accounted for, part of a system. Thank you David, I get much more done because of you."
                            }
                        }
                    },
                    new Block
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "I also use good old Excel and <a href='https://productiveapp.io/' target='_blank'>Productive</a>, a gorgeous habit tracker to log my activities. I have a spreadsheet for logging hours in key activities and another for a “Discipline Log”, where I keep track of the habits I want to avoid or do more frequently. These logs are my first activity every day. I wake up tick the activities of the previous day. I find that the end of the day when I’m tired is way harder."
                            }
                        }
                    },
                    new Block
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "To keep track of my health, I use Fitbit. I have a <a href='https://amzn.to/3N3mKgy' target='_blank'>Charge 5</a> and not only it monitors my sleep and heart rate, but its app has an excellent Food Tracker where I keep track of everything I eat most days. I’m not too hard on myself when I can’t track my food intake since sometimes it’s hard to find out what exactly is in your food, especially when eating out."
                            }
                        }
                    },
                    new Block
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "I know what some of you are thinking. You have two or three kids, a full time job, care for your elderly parents and still study at night. Yes, I totally appreciate that. I had these examples at home too. Mom and dad were absolute hustlers. I concede I have it easier than most. Someone on a minimum wage in Australia is in the top 3% highest income <b>on the planet</b>. No joke. <a href='https://www.washingtonpost.com/graphics/2018/business/global-income-calculator/' target='_blank'>Look it up</a> – by the way, small rant: if you’re in a first world country complaining about life, just shush 😒. Ok, rant over – But it’s my obligation to do as much as I can with these privileges."
                            }
                        }
                    },
                    new Block
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "Speaking of which, time to bloody get back to work. The short-term goal? To succeed in keeping all my metrics moving in the right direction for the duration of this study semester. I’ll post the result in four months, if I’m still alive."
                            }
                        }
                    },
                    new Block
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "Wish me good luck, I’ll need it."
                            }
                        }
                    }
                }
            },
            new Article
            {
                Id = 30003,
                Title = "The Best Book About Self-Discipline I’ve Ever Read",
                IconUrl = "",
                Slug = "legacy-a-little-bit-about-me",
                BannerUrl = "",
                CardImgUrl = "blog4.png",
                Description = "A review of 365 Days With Self-Discipline and the practical lessons it offers for reshaping habits, building resilience and resisting self-sabotage.",
                ReleaseDate = new DateTime(2024, 7, 29),
                Area = Area.Blog,
                Blocks = new List<Block>
                {
                    new Block
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "Last week a friend recommended a fantastic book: <a href='https://amzn.to/438w0r0' target='_blank'>365 Days With Self-Discipline: 365 Life-Altering Thoughts on Self-Control, Mental Resilience, and Success</a>. I find self-control a fascinating topic and I had a spare Audible credit so after finishing my previous book I quickly grabbed it. I’m absolutely hooked. To the point of considering it my new bible."
                            }
                        }
                    },
                    new Block
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "The book is organized in chapters with one aspect of self-discipline per day for 365 days. Each chapter starts with a quote and expands on the quote’s ideas. My first reaction to the book’s narration by John Gagnepain – check out the sample below – was being unimpressed. I initially thought it was  somewhat monotone and nonchalant. A bit “corporate”. After having recently listened to the high-energy narrations of <a href='https://amzn.to/4drFHoH' target='_blank'>Rework by Jason Fried</a> and <a href='https://amzn.to/46KC1vD' target='_blank'>Gary Varneychuk's Crush It</a>, the opening minutes made me think I was in for 10 hours of boredom 🥱."
                            }
                        }
                    },
                    new Block
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "But the unemotional narration style adds a touch of humor and drives the point home better than if it was narrated by a more cheerful voice. <i>“When you start exercising, expect to be ridiculed by your friends, whose only exercise is with the remote control all evening while watching their favorite show”</i>, read dispassionately, made me laugh out loud."
                            }
                        }
                    },
                    new Block
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "My strategy for this book is to listen to a few chapters every day, especially at critical times when my will-power tends to be lower. The post-lunch food fatigue for example often leads to high levels of fruit-consumption or Instagram-flicking. It’s been working so far. I feel more equipped to deal with self-sabotaging thoughts. I’ve read many self-disciple books before but none were as effective in changing my mindset. It teams up really with <a href='https://amzn.to/3WLNqXr' target='_blank'>Atomic Habits</a>, which has the best anecdotes and <a href='https://amzn.to/3PdWPnW' target='_blank'>Tiny Habits</a>, the most actionable."
                            }
                        }
                    },
                    new Block
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "I trust that this approach is better than a traditional binge-read with little reflection and practice. As the book itself says, bad habits were formed throughout many years, sometimes decades. Reading a book in a week is unlikely to shake things up. Only painstaking reconditioning will do the job."
                            }
                        }
                    },
                    new Block
                    {
                        Title = "My Bad Habits",
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "Like everyone else, I could come up with a big list of destructive habits but as I advocate to students and mentees, tackling too many objectives at the same time more often than not leads to frustration. My priority right now is to confront my relationship with food. Although I eat healthier than most and I’m somewhat fit, I struggle with spells of chocolate-fueled debauchery and funnily enough, mind-boggling levels of fruit consumption. Fruit is hard to avoid because it’s easy to justify. It’s rich in nutrients, not processed and has no added sugar. I was brought up on it so it’s deeply wired into my brain. Right now I average four or five daily pieces, generally bananas and apples after having started my day with a bunch of berries. And that’s because I’ve improved <b>a lot</b>. And I still have bouts where I’ll eat twice as much."
                            },
                            new Paragraph
                            {
                                Body = "Working from home, it’s very easy to go downstairs to make another cup of coffee or grab another bite of whatever I can find in the fridge/pantry. My mind inevitably goes there when I’m facing a hard programming problem. That means I’m eating for reasons that have nothing to do with hunger. "
                            },
                            new Paragraph
                            {
                                Body = "The game plan to tame this lion will be two fold: tracking the amount of pieces of fruit I eat and limit its intake to have it only as a dessert, not a meal by itself, unless I’m quickly grabbing a banana before the gym. <i>“What we can measure we can improve”</i>."
                            },
                            new Paragraph
                            {
                                Body = "How about you? What is one bad habit you’d like to tackle? And how do you plan to do it?"
                            },

                        }
                    },
                    new Block
                    {
                        Title = "Follow-up",
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "A quick follow-up <a href='article/30002/how-can-i-possibly-do-all-of-these-things' target='_blank'>from the previous post</a>. Although I painted myself into a corner with too many commitments, I think I did a decent job at prioritizing this week. I was disciplined enough to say no to the temptation of jumping around amongst several tasks and dedicated 27 hours to building the new website for The C# Academy in the last 10 days. What’s driving this surge is the fact that this is a finite project. Getting it out of the way will allow me to go back to spending more time in the ongoing task of creating amazing educational content. I hope to have the new version out within a week 💪🏻."
                            }
                        }
                    },
                }
            },
            new Article
            {
                Id = 30004,
                Title = "Three Years as a Software Engineer (Part 1)",
                IconUrl = "",
                Slug = "three-years-as-a-software-engineer-part1",
                BannerUrl = "",
                CardImgUrl = "blog5.png",
                Description = "Reflections on the luck, timing, people and persistence that made the first three years of a professional software engineering career possible.",
                ReleaseDate = new DateTime(2024, 8, 5),
                Area = Area.Blog,
                Blocks = new List<Block>
                {
                    new Block
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "The 6th of July was the third anniversary of my professional career as a software developer. This is the first of a series of posts with reflections on these three years. In this initial post I’ll talk about some of the circumstances that allowed me to get into the industry in the first place."
                            }
                        }
                    },
                    new Block
                    {
                        Title = "Luck Counts",
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "First I have to acknowledge my luck. If I had started my journey only a few months later I’d probably be looking for jobs right in the middle of the big depression in the job market. It’s hard to know if I would have made it at all. I like to think of myself a resilient “achieve it or die trying” kind of guy but I can’t say for sure I wouldn’t have quit after years of being rejected. "
                            }
                        }
                    },
                    new Block
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "I’m also lucky to have started my career in two companies that have an amazing culture. I’ll be forever grateful to my first manager for providing such a supportive environment for juniors. As one would expect from a starter, I made several mistakes, asked stupid questions and behaved awkwardly, but everyone around me was very understanding and I was never treated poorly. "
                            }
                        }
                    },
                    new Block
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "The same is true for my current company. We’re in a small team where I needed to step up in responsibility looking after large chunks of our product. Again, several mistakes, some affecting the users directly. But my seniors were always supported and trusted my ability to learn from them."
                            }
                        }
                    },
                    new Block
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "This can also be said about geographical circumstances. I probably wouldn’t have gotten a job even during the hiring frenzy had I lived in Europe or in most states in the US. The scarcity of programmers in Australia made my life much easier. "
                            }
                        }
                    },
                    new Block
                    {
                        Title = "The Pandemic",
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "And how about the timing? The pandemic was a hard time for most of us. It created a lot of anxiety, political division, unemployment, hardship. I was secretly having a great time (don’t tell anyone). I had all the time in the world to dedicate to coding. And oh boy did I use it! Besides, I was single, so I was able to sit down and learn for 8+ hours day after day. This period certainly sped um the process of getting my first job."
                            }
                        }
                    },
                    new Block
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "But I think the biggest stroke of luck was the one that actually led me to start coding in the first place. It was just before the pandemic. For whatever reason I started looking for remote jobs. I didn’t even have an Australian permanent visa yet but all of the sudden the idea of a profession that would allow me to work remotely became more appealing. "
                            }
                        }
                    },
                    new Block
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "I remember looking at professions such as personal assistant and Language Teacher. I think I even created a Portuguese teacher profile somewhere. I think I’d have been good a it. However these saturated professions that wouldn’t give me the financial freedom I desired. Then Google’s algorithm must have heard me and starting presenting me with coding courses. I jumped onto the CodeAcademy and was hooked within minutes. Although now I don’t really like the idea of learning to code in the browser, I have to say that again I’m lucky that their web development course is organized in byte-size chapters. That structure made me keep going even when I didn’t know exactly what I was doing."
                            }
                        }
                    },
                    new Block
                    {
                        Title = "Good Samaritan",
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "Then I remember talking to a salsa student of mine and he said I should learn a back-end language. Specifically Java, which he worked with as a senior. I did study it for a couple of months before finally settling for C#, since another student was willing to give me a hand. "
                            }
                        }
                    },
                    new Block
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "This friend was a key player in my initial journey. We met up several times so he could help me when I was stuck. The pair programming sessions we had were crucial. I could see how he thinks about code when he was talking to himself through a problem. I think this is one of the most neglected aspects of learning to code. You’ll learn more sitting for one hour with an experienced engineer than in dozens of hours watching tutorials by yourself."
                            }
                        }
                    },
                    new Block
                    {
                        Title = "So What?",
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "With all this self-indulgent talk about how lucky I am, if you can’t get into the industry right now you must be thinking: “Ok mate, you’re lucky, I get it. Good for you.” And you’re right. It’s ok to get angry, anxious, upset. But it’s important to put yourself into the context of the job market right now. If you don’t love coding, it might be time to look into doing something else. But if you do, keep working hard and when the circumstances improve, you’ll be ahead of the curve to get that coveted job!"
                            }
                        }
                    },
                    new Block
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "I was lucky one day, but my fortune might turn tomorrow and I can get fired. I think about this possibility a lot. And regardless of how tough the job market is, I’d spend every waking moment living and breathing code until I got back into the market. If there’s one thing I can control is the amount of work I put into it. When luck hits you with an opportunity, you have to be ready."
                            }
                        }
                    },
                    new Block
                    {
                        Title = "Outliers",
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "On this topic, <a href='https://amzn.to/3YMPCkb' target='_blank'>I highly recommend the book Outliers</a>, by Martin Meadows. It talks about the importance of one’s environment to their relative success. The example in the book that resonates the most with me is Bill Gates. The set of circumstances that allowed him to achieve greatness is enlightening. As an example, he went to one of the first schools to give students unlimited access to a computer. So he amassed his thousands of hours of programming practice before almost everyone else on the planet! Is he extremely intelligent? Did he work hard? Yes and yes. Would he have impacted the world the way he did if he didn’t go to that school? It’s highly unlikely. "
                            }
                        }
                    },
                }
            },
new Article
        {
            Id = 31000,
            Title = "LEGACY: Changing To A New Address",
            Slug = "changing-to-a-new-address",
            Description = "I’m moving addresses so I can keep all of my content in one place. This blog is now found in my portfolio at : https://cappuccinocoding.com/blog",
            CardImgUrl = "legacy-changing-to-a-new-address.png",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2021/09/12/changing-to-a-new-address/",
            ReleaseDate = new DateTime(2021, 9, 12),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">I&#8217;m moving addresses so I can keep all of my content in one place. This blog is now found in my portfolio at : <a href=\"https://cappuccinocoding.com/blog\">https://cappuccinocoding.com/blog</a></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31001,
            Title = "LEGACY: Two Months As a Junior Developer",
            Slug = "two-months-as-a-junior-developer",
            Description = "It’s been a very busy month at work, but here I am again! I’m ready to reflect a bit on what I’ve learned so far and make plans for the next two months! Lucky First of all, I ha...",
            CardImgUrl = "legacy-two-months-as-a-junior-developer.jpeg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2021/09/06/two-months-as-a-junior-developer/",
            ReleaseDate = new DateTime(2021, 9, 6),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">It&#8217;s been a very busy month at work, but here I am again! I&#8217;m ready to reflect a bit on what I&#8217;ve learned so far and make plans for the next two months!</p>\n\n\n\n<p class=\"wp-block-paragraph\">Lucky</p>\n\n\n\n<p class=\"wp-block-paragraph\">First of all, I have to say how lucky I am for having the opportunity of working with such an amazing team. Everyone is really nice, particularly the senior developers. Despite their immense knowledge and experience, everyone is really helpful. I haven&#8217;t seen a single frown upon my noob questions. I haven&#8217;t seen anyone being arrogant. I&#8217;m extremely lucky and I&#8217;m grateful for that!</p>\n\n\n\n<p class=\"wp-block-paragraph\">Comfortable</p>\n\n\n\n<p class=\"wp-block-paragraph\">I can say I&#8217;m fully climatized to the company&#8217;s domain. I&#8217;m way more comfortable navigating massive domain, creating branches, pull requests, dealing with git and the project management tools. I can quickly dive into the problems themselves because I know where things sit in the domain. That&#8217;s not to mention getting more used to Visual Studio, which I use every day for many hours. </p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;m also a bit more comfortable starting conversations in the office, but there&#8217;s still some more work to do in that regard, specially with the more introverted folks. Let&#8217;s give it some time! .😁</p>\n\n\n\n<p class=\"wp-block-paragraph\">Projects</p>\n\n\n\n<p class=\"wp-block-paragraph\">So far I&#8217;ve worked on the search, products page, checkout, internal systems, feature toggles, both in front end and back end. I&#8217;ve used Vanilla Js, jquery, React, Svelte, Handlebars, MJML ASP.NET MVC. I can&#8217;t say I know any of them very deeply, but I learned I&#8217;m able to make modifications in a project even If I&#8217;m not fluent in that framework/language.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Right now I&#8217;m working in the most exciting project so far. To refurbish all e-mails sent from the ecommerce to the customers. I have to implement the design made by the product owner, using MJML/Handlebars and plugging it into the messaging system, wired by Rebus library. </p>\n\n\n\n<p class=\"wp-block-paragraph\">It took me a week to figure out how to use each of these tools independently and then meshed into the customer project. I was finally able to send the first e-mail, which was a big Eureka moment. The last day was all trying to adjust the project and testing suite to each other, so the project would build successfully in the CI/CD pipeline.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Working with the e-mails is exciting because I&#8217;ll dive into all areas of the domain, which will give me a broad understanding of where everything is and how it ties together. Looks like it will be a great September!!</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Routines</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I have also created very solid routines in the past month. I moved in with my girlfriend and most of my days are very well rehearsed. From Monday to Wednesday I wake up at 430, have a cold shower, make a double expresso for the road and leave at 515. I get to work at 630, where I read and meditate for 20 mins and start at 7.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I have a break from 11-12 where I try to nap in my car in the parking area. I can make better use of this time, as I&#8217;m usually stuck reading the news. It&#8217;s very addictive in times of climate change/Afghan Crisis/Covid. </p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;ve been fasting all morning so I have my first meal (nuts) at 1pm and then my lunch at 345, before leaving at 4. I get back to Sunshine Coast at around 530 and go to the gym, and get home by 7. At night I spend time with my girlfriend, prep for the next day, play video games, work on personal projects, dance, whatever I feel like. </p>\n\n\n\n<p class=\"wp-block-paragraph\">Wednesdays and Thursdays sometimes are slightly different as I try to sleep in Brisbane at a friend&#8217;s place. In that case I can sleep up to 530 and I catch up with friends at night. But I can also do a better job decreasing my procrastination, particularly from 8pm till bed time.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Side Project</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;m working on a very exciting side project, and I&#8217;ll be posting it in the next few days. Life is good!!!! Back to work now 😀</p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31002,
            Title = "LEGACY: Appreciating Life Even More",
            Slug = "appreciating-life-even-more",
            Description = "A few months ago I had a bit of bladder pain when peeing. I didn’t make much of it and eventually the discomfort ceased. A couple of months later the pain started again. It wasn...",
            CardImgUrl = "appreciate.webp",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2021/08/05/appreciating-life-even-more/",
            ReleaseDate = new DateTime(2021, 8, 5),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">A few months ago I had a bit of bladder pain when peeing. I didn&#8217;t make much of it and eventually the discomfort ceased. A couple of months later the pain started again. It wasn&#8217;t intense. But it was always there. </p>\n\n\n\n<p class=\"wp-block-paragraph\">My girlfriend convinced me to see a GP. He asked for some extra tests and in the ultra-sound it was clear there was something in my abdomen that wasn&#8217;t supposed to be there. A 5cm round mass just above the bladder, with a few smaller structures (ascites) spread around the abdomen. Right after that I had a CT done to have a better look. </p>\n\n\n\n<p class=\"wp-block-paragraph\">The differential diagnostics was wide, nobody knew for sure what it was but it wasn&#8217;t very alarming, combined with cancerless blood markers. Nevertheless I was referred to hospital the next day for what It seemed to be emergency surgery. This thing had to be removed. </p>\n\n\n\n<figure class=\"wp-block-image size-large\"><img loading=\"lazy\" width=\"850\" height=\"394\" data-attachment-id=\"555\" data-permalink=\"https://cappuccinocodes.wordpress.com/ultrasound-images-of-the-urinary-bladder-demonstrate-a-cystic-structure-along-its/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/08/ultrasound-images-of-the-urinary-bladder-demonstrate-a-cystic-structure-along-its.png\" data-orig-size=\"850,394\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"ultrasound-images-of-the-urinary-bladder-demonstrate-a-cystic-structure-along-its\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/08/ultrasound-images-of-the-urinary-bladder-demonstrate-a-cystic-structure-along-its.png?w=723\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/08/ultrasound-images-of-the-urinary-bladder-demonstrate-a-cystic-structure-along-its.png?w=850\" alt=\"\" class=\"wp-image-555\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/08/ultrasound-images-of-the-urinary-bladder-demonstrate-a-cystic-structure-along-its.png 850w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/08/ultrasound-images-of-the-urinary-bladder-demonstrate-a-cystic-structure-along-its.png?w=150 150w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/08/ultrasound-images-of-the-urinary-bladder-demonstrate-a-cystic-structure-along-its.png?w=300 300w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/08/ultrasound-images-of-the-urinary-bladder-demonstrate-a-cystic-structure-along-its.png?w=768 768w\" sizes=\"auto, (max-width: 850px) 100vw, 850px\" /><figcaption>Cyst similar to mine</figcaption></figure>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Too Slow</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I don&#8217;t mean to have a dig at the Australian public health system. It&#8217;s very good and I consider myself lucky to have Medicare. I was in hospital for a few hours and the staff decided I didn&#8217;t need emergency surgery as I didn&#8217;t have any symptoms. It was just the tumour. </p>\n\n\n\n<p class=\"wp-block-paragraph\">I was discharged with a referral for an MRI and an appointment with a surgeon in a month. I had to chase those appointments as they weren&#8217;t booked for me and my case seems to have been lost in their systems. </p>\n\n\n\n<p class=\"wp-block-paragraph\">After a month I had the MRI done and finally god the appointment with the surgeon for two weeks later. I&#8217;ve never seen the MRI, just the report, a few days later. And only through my doctor. The access to personal health information is my biggest complaint about the public system. I can&#8217;t see my tests. I couldn&#8217;t send them to my parents, who are health practitioners in Brazil, to help me make a decision. </p>\n\n\n\n<p class=\"wp-block-paragraph\">When I finally saw the surgeon he seemed very surprised with my case and I was under the impression he hadn&#8217;t seen it before. He said it was very complicated and I&#8217;d probably be referred to Brisbane for the surgery. I left the appointment a bit pessimistic about the prospect of having surgery performed in multiple organs. </p>\n\n\n\n<div class=\"wp-block-image\"><figure class=\"aligncenter size-large is-resized\"><img loading=\"lazy\" data-attachment-id=\"557\" data-permalink=\"https://cappuccinocodes.wordpress.com/584254a3da04252b4ca959ea4eb5dc71/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/08/584254a3da04252b4ca959ea4eb5dc71.webp\" data-orig-size=\"862,575\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"584254a3da04252b4ca959ea4eb5dc71\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/08/584254a3da04252b4ca959ea4eb5dc71.webp?w=723\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/08/584254a3da04252b4ca959ea4eb5dc71.webp?w=862\" alt=\"\" class=\"wp-image-557\" width=\"498\" height=\"331\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/08/584254a3da04252b4ca959ea4eb5dc71.webp?w=498 498w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/08/584254a3da04252b4ca959ea4eb5dc71.webp?w=150 150w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/08/584254a3da04252b4ca959ea4eb5dc71.webp?w=300 300w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/08/584254a3da04252b4ca959ea4eb5dc71.webp?w=768 768w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/08/584254a3da04252b4ca959ea4eb5dc71.webp 862w\" sizes=\"auto, (max-width: 498px) 100vw, 498px\" /><figcaption>Sunshine Coast University Hospital</figcaption></figure></div>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Going Private</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Throughout the process a friend who&#8217;s a surgeon suggested I see one of his friends and get everything done private quickly. He insisted I had a laparoscopy from the get go. It&#8217;s a key-hole exploratory surgery to see what&#8217;s going on and potentially remove the tumour if possible. </p>\n\n\n\n<p class=\"wp-block-paragraph\">After that sad appointment I decided to go see Dr. Brian Meade, a specialist in mysterious peritoneal cysts, in Brisbane. He didn&#8217;t have an opinion about it was, but he seemed way more confident about what to do. I spent about 20 minutes with him asking every possible question I could think of and we booked a surgery, which was affordable, for 5 days later. What a difference! </p>\n\n\n\n<div class=\"wp-block-image\"><figure class=\"aligncenter size-large\"><img loading=\"lazy\" width=\"320\" height=\"180\" data-attachment-id=\"559\" data-permalink=\"https://cappuccinocodes.wordpress.com/mqdefault/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/08/mqdefault.jpeg\" data-orig-size=\"320,180\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"mqdefault\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/08/mqdefault.jpeg?w=320\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/08/mqdefault.jpeg?w=320\" alt=\"\" class=\"wp-image-559\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/08/mqdefault.jpeg 320w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/08/mqdefault.jpeg?w=150 150w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/08/mqdefault.jpeg?w=300 300w\" sizes=\"auto, (max-width: 320px) 100vw, 320px\" /><figcaption>Northwest Private Hospital</figcaption></figure></div>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Proposing</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I wanted to propose to my girlfriend in November in a trip we have booked but the prospect of cancer made me expedite things. I bought a ring on Friday, called her parents on Saturday and on Sunday we went to see the sunrise in the morning, after a massive day of work for her. </p>\n\n\n\n<p class=\"wp-block-paragraph\">Luckily It was a beautiful day and she didn&#8217;t mind waking up at 515 in a freezing morning to go to the beach with me on the day before my surgery. We surprisingly found a sofa in the middle of the beach. Totally staged by the universe for that occasion. </p>\n\n\n\n<p class=\"wp-block-paragraph\">I popped the question, she said yes and we had a video conference with our parents and her sister, in England in Brazil. Of course the ring didn&#8217;t fit and we&#8217;ll only get it back from refitting in 10 weeks. But It was a happy day, making the anticipation for surgery way less miserable. </p>\n\n\n\n<div class=\"wp-block-image\"><figure class=\"aligncenter size-large is-resized\"><img loading=\"lazy\" data-attachment-id=\"561\" data-permalink=\"https://cappuccinocodes.wordpress.com/217053907_2041866002618938_1423061608522460093_n/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/08/217053907_2041866002618938_1423061608522460093_n.jpeg\" data-orig-size=\"720,960\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"217053907_2041866002618938_1423061608522460093_n\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/08/217053907_2041866002618938_1423061608522460093_n.jpeg?w=720\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/08/217053907_2041866002618938_1423061608522460093_n.jpeg?w=720\" alt=\"\" class=\"wp-image-561\" width=\"384\" height=\"513\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/08/217053907_2041866002618938_1423061608522460093_n.jpeg?w=384 384w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/08/217053907_2041866002618938_1423061608522460093_n.jpeg?w=113 113w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/08/217053907_2041866002618938_1423061608522460093_n.jpeg?w=225 225w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/08/217053907_2041866002618938_1423061608522460093_n.jpeg 720w\" sizes=\"auto, (max-width: 384px) 100vw, 384px\" /><figcaption>Our view at Kawana Beach right after my proposal</figcaption></figure></div>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Hospital</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">The surgery was booked for Monday afternoon and I still went to work in the morning (it was only my third week at EB Games), as it would be better to have my mind occupied in the morning. I&#8217;d have a lot of free time to think the next day and in the post-op.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I arrived at 230pm but due to complications in one of the surgeries, I was only taken to the operation theatre at 630pm . The surgery happened at 730pm and two hours later I was back in my room under heavy pain killers. Three cysts were removed. Samples were taken for biopsy. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Post-Op</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I woke up several times during the night but I wasn&#8217;t in pain. In the morning I was already walking. And at 11am I was discharged. It felt good during the day and I even went for a short walk to a lake near her place. It was an illusion. </p>\n\n\n\n<p class=\"wp-block-paragraph\">On the next day the pain was much much worse, I couldn&#8217;t stand for more than five minutes, coughing was a nightmare, any movement that involved my core even slightly was very painful. I took paracetamol and an anti-inflammatory but didn&#8217;t want to take a strong opioid they gave me, knowing about its risks. On Friday the results finally came. The tumours showed no sign of malignancy. Phew!</p>\n\n\n\n<p class=\"wp-block-paragraph\">I stayed at my girlfriend&#8217;s for another 5 days until she finally dropped back home. She was the best at looking after me, preparing food, helping me shower, giving me my meds and making sure I only moved the minimum amount possible/necessary. Oh, and I can&#8217;t forget to mention she bought us an Xbox, which meant lots of hours playing Fifa when she was at work and Overcookin&#8217; when she was home. Such a cool little game for couples!</p>\n\n\n\n<p class=\"wp-block-paragraph\">All of this was happening on my third week of work, which I missed. On Wednesday I had tested driving and sitting for a long period so I decided to try and go to work. Fortunately it wasn&#8217;t too bad. It was great to be back. It was a great sensation to be back to work only having to worry about coding and not with a cancerous cloud on top of me. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Outcomes</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I had a lot of time to reflect about life during this big scare. I&#8217;ve always appreciated the small things and I&#8217;m inherently grateful for everything I have. Friends, family, Australia, Meghan, a great job all material things I need. </p>\n\n\n\n<p class=\"wp-block-paragraph\">But thinking about death made appreciate everything even more. Every day when I go out I think about how beautiful everything is. I&#8217;m way less inclined to argue about anything. I have more love and tolerance for people and I want everyone to be well. I want to help others and build community.</p>\n\n\n\n<p class=\"wp-block-paragraph\">And above all, I can definitely be blamed for not being a family man. Family was never a priority. Clearly. I haven&#8217;t seen my parents in seven years. But the experience made me appreciate family again. Not only I got way closer to my parents but I&#8217;ve also spoke to uncles I haven&#8217;t spoken in a long time. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>The Future</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I want to enjoy the opportunity I was given to live on this earth fulfilling my potential as a good son, husband, friend, employee, someone who loves life, people and contributes to society. Life is short. Every day is a blessing. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>OH, AND DON&#8217;T FORGET, GET PRIVATE HEALTH. </strong></p>\n\n\n\n<p class=\"wp-block-paragraph\"></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31003,
            Title = "LEGACY: 2nd Week And Counting!",
            Slug = "2nd-week-and-counting",
            Description = "Last week I felt so much more comfortable working at EB Games! It was my second week and I think I now understand the basics and I’m getting some traction. By the end of the for...",
            CardImgUrl = "legacy-2nd-week-and-counting.png",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2021/07/23/2nd-week-and-counting/",
            ReleaseDate = new DateTime(2021, 7, 23),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">Last week I felt so much more comfortable working at EB Games! It was my second week and I think I now understand the basics and I&#8217;m getting some traction. By the end of the fortnight I had solved seven tickets, which makes me very proud. </p>\n\n\n\n<p class=\"wp-block-paragraph\">I always have the fear of being too slow or not doing a satisfactory job. The thought of being fired on the next day or not being approved after my probation is always on the back of my mind. These thoughts are magnified by some health problems I&#8217;ll address in a later post. But on Friday before leaving I asked for feedback from my manager and he said they&#8217;re happy with my work. That made my weekend before it started!</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Code Review</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Unfortunately I had a couple of tickets that came back from code review and QA. It&#8217;s a bad feeling, but it taught me to check, double check, check however many times necessary to make sure my code works right. Hopefully I won&#8217;t have tickets returning due to lack of attention or testing anymore. But I know it&#8217;s a natural thing for some tickets not to pass, that&#8217;s why we have excellent professionals in Quality Assurance. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Flow of Work</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Now I understand Jira, Bitbucket and Git way better and how they work together in the organisation. I know where the tickets are found and how to track them, how to work with branches, commits, pull requests. In the first week I spent hours just trying to figure that stuff out before starting work in any ticket. </p>\n\n\n\n<p class=\"wp-block-paragraph\">That process is out of my way now, so I can quickly start investigating the actual issues. There are still many parts of the system to install in my machine, though. If a ticket is related to something I still don&#8217;t have, I have to figure out what to install. Last morning I had to install another database and learn how to change to Zing Pop Culture&#8217;s website, which is also maintained by our team.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;ve also gotten way better at debugging, either using Chrome Dev Tools or Visual Studio. I spent countless hours fiddling with debuggers but I still feel it&#8217;s the tip of the debugging iceberg. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Learning Fronts</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Now that I know what technologies are used in the system, I have more clarity about what I have to learn. In order of priority, ASP.NET MVC/Razor, Javascript, CSS/Less, React and Svelte. I&#8217;m doing courses in the first two. I have to complete and gain some fluency in them before moving on to JS frameworks again, I think learning them properly will be way easier having more Vanilla JS experience.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Finishing the courses won&#8217;t be enough, I&#8217;ll have to design my own personal projects so I learn the ins and outs. I find that If I try to implement functionalities imagined by myself I learn way more effectively. </p>\n\n\n\n<p class=\"wp-block-paragraph\">I might create a few small projects, but it&#8217;s even better if I can create a big complex application with many pages and scripts. One of the biggest shocks when I started last week was the sheer size of the systems, there&#8217;s so much going on in every single click of a button. But in the second week it was definitely less overwhelming. Nothing like time and hard work. </p>\n\n\n\n<p class=\"wp-block-paragraph\">Speaking of hard work, <strong>back to it!</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\"></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31004,
            Title = "LEGACY: First week at EB Games!",
            Slug = "first-week-at-eb-games",
            Description = "What an intense week!! It was everything I expected. Exciting, nerve-wrecking and extremely humbling. I initially thought of writing a post a day but the last thing I wanted to...",
            CardImgUrl = "ebgamesfirstweek.webp",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2021/07/12/first-week-at-eb-games/",
            ReleaseDate = new DateTime(2021, 7, 12),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">What an intense week!! It was everything I expected. Exciting, nerve-wrecking and extremely humbling. I initially thought of writing a post a day but the last thing I wanted to do after an entire day in front of the computer was TO BE ON A COMPUTER writing a blog post. So I&#8217;ll try to give a good account of what happened. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Day 1 &#8211; Monday</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">In preparation for the big day I tried to be very organised the night before. I had everything staged and good to go in the morning. I know it&#8217;s a given for folks who have day jobs but I wasn&#8217;t used to that as I haven&#8217;t had to work mornings in a long time. </p>\n\n\n\n<p class=\"wp-block-paragraph\">The initial drive down to Brisbane was a bit scary. I wasn&#8217;t used to the intensity of traffic at peak hours, but after a week it became easier. As always, everything is a matter of adaptation. I arrived at 8, even though I initially thought the job was from 9-5. Later I found out the work hours are flexible, as long as you do a full day. I got introduced to the team, the greetings took less than a minute and everyone dug their heads in their computer again, super busy. </p>\n\n\n\n<p class=\"wp-block-paragraph\">I was shown my desk, which is directly facing the door, which means my screen is always seen by the entire office. Scary! Not that I was planning to use Facebook at work, but now everyone will be able to see my stupid questions on Google (such as &#8220;how to run an update query on SQL&#8221;, or &#8220;what is PDP in ecommerce&#8221;). </p>\n\n\n\n<p class=\"wp-block-paragraph\">Right after that we had our first meeting. There are daily stand-ups, part of the whole AGILE process, and I got to see what it looked like. The meetings are held against a wall with each team&#8217;s AGILE board, where the tickets with issues being solved are displayed. Each person says what they&#8217;ve been doing and what&#8217;s the next step. </p>\n\n\n\n<p class=\"wp-block-paragraph\">Then I finally got access to my computer by the end of the morning. Most of my contact was with my manager and the leader of my team, super nice guys. I got to have lunch with them and asked a bunch of questions. Q: &#8220;What&#8217;s a priority that I should learn?&#8221; A: &#8220;Depends on what you&#8217;re working on&#8221;. Q: &#8220;Am I expected to solve tickets by myself?&#8221; A: &#8220;No&#8221;. And stuff like that.</p>\n\n\n\n<p class=\"wp-block-paragraph\">The afternoon was spent setting up my environment, downloading all the necessary applications along with the databases and code-base. Also learned a bit about some tools the company uses. Slack, Bitbucket, Jira, Team City. </p>\n\n\n\n<p class=\"wp-block-paragraph\">I had to spend some time waiting for things to download or access to be granted and while that happened I started to look at the ASP.NET MVC documentation and tutorials by Microsoft. Looks like everything is based on that, using Razor views. Thank god I learned a bit of Razor a while, or I&#8217;d be completely lost. I wish I had picked ASP.NET MVC for training in my prep week.</p>\n\n\n\n<p class=\"wp-block-paragraph\">By the end of the day, the setup still wasn&#8217;t ready and we left it running over night.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Day 2 &#8211; Tuesday</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Tuesday was a terrifying day. We had planning meeting early in the morning where I understood maybe 1% of what was said, and folks actually gave me the word at the daily stand-up. <strong>&#8220;I don&#8217;t know what to say&#8221;</strong>, I said. Not very impressive. After lunch everything was running well and guess what, my team leader <strong>PICKED UP A TICKET FOR ME</strong>. What??? Haha, what about &#8220;We don&#8217;t expect you to get a ticket&#8221; 24hs ago? Terrifying. But the product owner had separated a backlog of tickets for the new devs so they were supposed to be easier. </p>\n\n\n\n<p class=\"wp-block-paragraph\">Anyways, of course I didn&#8217;t mind and just jumped into it. All I had to do was modify some piece of HTML, really kindergarten stuff, right? Yes, in any application that doesn&#8217;t have 100 layers of code. Ha! It took me the whole afternoon just to find out where the <strong>bloody</strong> piece of HTML was. </p>\n\n\n\n<p class=\"wp-block-paragraph\">Plus I hadn&#8217;t realise that my local database didn&#8217;t have the products I needed so I was pretty much flying blind trying to find things using the production website and comparing it to the code base. </p>\n\n\n\n<p class=\"wp-block-paragraph\">After that I had to learn how to create a branch on Git, I had never used branches, check out, diff, or anything like that, but it was great! By the end of the day I had created my first pull request! Exciting!</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Day 3 &#8211; Wednesday</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">On the Wednesday I had my code approved in the morning and I merged it, also exciting! Also for the first time I said something in a meeting! Hurra! And I picked up a second ticket. This one way trickier because it involved CSS with LESS, which I didn&#8217;t have a lot of exposure to, so after I created a solution I had to use custom breakpoints instead of the global ones in the code base. But another engineer that gave me a hand was happy with it so I pulled it too! Yes! I left feeling really good for the first time. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Day 4 &#8211; Thursday</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">For the third ticket, I literally spent all day just trying to find out what was going on in the codebase. I have to fix a button that isn&#8217;t working properly. It was tricky because I had to replicate a product with properties that had the characteristics I wanted. It took me a few hours just to do that, and only after I asked for some help. We had to manually create such product on the database.</p>\n\n\n\n<p class=\"wp-block-paragraph\">After that I had to figure out how the state is managed in the application, which was WAY above my head. And then find out why the button, which is managed by JS with Jquery making an AJAX call wasn&#8217;t redirecting the user (ASP.NET MVC Routing). And I left without knowing. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Day 5 &#8211; Friday</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">After a day and a half of work I finally found what was going on. A button was sending an AJAX call with jquery and upon receiving a 401 response due to the session being over (which I manufactured), wasn&#8217;t redirecting the user to login. Instead, the modal it was suppose to open lost kept loading forever. Eureka!! </p>\n\n\n\n<p class=\"wp-block-paragraph\">One of the senior developers came to check on what I was doing after he finished a big task and gave me some pointers on how to fix it but I ended up not having time, as I didn&#8217;t work in the afternoon due to a medical appointment.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>The Weekend</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Leaving a ticket open didn&#8217;t make me feel great in the weekend, but I decided to spend time my learning time with Javascript, Ajax and jquery. Initially I kept moving through the JS course I&#8217;m doing, but because it moves at a very slow place (it&#8217;s a very comprehensive course), I went back to good old Traversy for crash courses on Ajax and Jquery. Exactly what I needed! I&#8217;m getting good at understanding new concepts using small sandboxes. Traversy&#8217;s stuff is fantastic for that.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Finally!!!</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">The result?? On Monday morning I finally solved my ticket and after committing the changes to the wrong repo (and hence learning how to revert git changes using the command line), I finally finished my ordeal!! What a fantastic feeling!!! </p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31005,
            Title = "LEGACY: Hello React!",
            Slug = "hello-react",
            Description = "I have been learning React for four days in preparation for my new job. I assumed it would be the most important technology to dive into. I was given a list of items that are us...",
            CardImgUrl = "helloreact.webp",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2021/07/01/hello-react/",
            ReleaseDate = new DateTime(2021, 7, 1),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">I have been learning React for four days in preparation for my new job. I assumed it would be the most important technology to dive into. I was given a list of items that are used in the company but there&#8217;s no order of importance. So I chose something I had no familiarity with. And there are <a href=\"https://www.linkedin.com/jobs/react-jobs/?originalSubdomain=au\">so many React positions out there</a>! So I thought even if everything goes wrong I&#8217;ll be more employable by knowing it. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Lockdown</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Australia is behind everyone else in the developed world due to lack of vaccines, so <a href=\"https://www.bbc.com/news/world-australia-57661144\">we entered lockdown again</a> to contain an outbreak. Queensland is stopping for three days and that gave me a great opportunity to advance in my studies. In the last couple of days I sat studying for over eight hours on each day. I think it&#8217;s good preparation for my new job. I&#8217;ve been coding almost every day for two years, but except for the initial quarantine last year, I didn&#8217;t have many long days. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>The Course</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I have completed 24% of <a href=\"https://pro.academind.com/courses/enrolled/1366761\">Academind&#8217;s React course</a>. It just amazes me how a human being can be so brilliant as Max Schwarzmuller. The dept of his knowledge is just astounding and his communication skills the same. There&#8217;s an energy and flow to his voice that serve as the perfect vehicle for his immense intellect. I&#8217;m glad I joined Academind. I don&#8217;t plan to leave anytime soon. </p>\n\n\n\n<div class=\"wp-block-image\"><figure class=\"aligncenter size-large\"><img loading=\"lazy\" width=\"1024\" height=\"342\" data-attachment-id=\"508\" data-permalink=\"https://cappuccinocodes.wordpress.com/screen-shot-2021-07-01-at-9-19-45-pm/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/07/screen-shot-2021-07-01-at-9.19.45-pm.png\" data-orig-size=\"2706,904\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"screen-shot-2021-07-01-at-9.19.45-pm\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/07/screen-shot-2021-07-01-at-9.19.45-pm.png?w=723\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/07/screen-shot-2021-07-01-at-9.19.45-pm.png?w=1024\" alt=\"\" class=\"wp-image-508\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/07/screen-shot-2021-07-01-at-9.19.45-pm.png?w=1024 1024w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/07/screen-shot-2021-07-01-at-9.19.45-pm.png?w=2048 2048w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/07/screen-shot-2021-07-01-at-9.19.45-pm.png?w=150 150w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/07/screen-shot-2021-07-01-at-9.19.45-pm.png?w=300 300w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/07/screen-shot-2021-07-01-at-9.19.45-pm.png?w=768 768w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/07/screen-shot-2021-07-01-at-9.19.45-pm.png?w=1440 1440w\" sizes=\"auto, (max-width: 1024px) 100vw, 1024px\" /></figure></div>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;m progressing relatively fast because I have an Angular background, but this time I&#8217;m doing every single exercise offered in the course. Most of them are tiny, simple, boring applications and I&#8217;m at least trying (with various degrees of success) to solve everything on my own before looking up the solution and it&#8217;s been super helpful. It&#8217;s so much better for retention to actually think things through in order to build these tiny apps instead of just always coding along. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Second Front</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;ve also added a <a href=\"https://www.youtube.com/watch?v=NemyDIUcC64&amp;t=69s\">smaller tutorial </a>to complement Max&#8217;s gigantic course. It&#8217;s a simple CRUD application with Asp.NET backend using React. The idea is to see a working application in time for Monday. CodeAffection&#8217;s explanations aren&#8217;t so in depth, but his tutorials are very practical and good to quickly connect the dots. It&#8217;s also great that he always works with CRUD, which is such an essential component of most apps. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Anxiety</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I have no idea what to expect of my first day at work. I&#8217;m trusting my managers are experienced in onboarding a new developer. There&#8217;s a mix of good and bad experiences for folks in their first job on Reddit and some of the &#8220;fail&#8221; stories are scary. But the guys I spoke to in my interview seemed great and I&#8217;m optimistic I&#8217;ll at least be treated well. If I&#8217;ll be able to do the job, that&#8217;s a different story. </p>\n\n\n\n<p class=\"wp-block-paragraph\">In the next few days I&#8217;ll go as far as I can in React but I still want to have a look at some more C# stuff. I need to know more about generics and OOP principles and I don&#8217;t think it should wait. </p>\n\n\n\n<p class=\"wp-block-paragraph\">Let&#8217;s see how it goes!</p>\n\n\n\n<p class=\"wp-block-paragraph\"></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31006,
            Title = "LEGACY: One Week To Start My New Job!",
            Slug = "one-week-to-start-my-new-job",
            Description = "At this time next week I’ll be inside an office in a big Australian company working in my first dev job! I’m very scared and I’ll try to use these next seven days to do as much...",
            CardImgUrl = "legacy-one-week-to-start-my-new-job.png",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2021/06/28/one-week-to-start-my-new-job/",
            ReleaseDate = new DateTime(2021, 6, 28),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">At this time next week I&#8217;ll be inside an office in a big Australian company working in my first dev job! I&#8217;m very scared and I&#8217;ll try to use these next seven days to do as much work as I can to be prepared. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Checklist</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Up to this morning I didn&#8217;t have a very good idea about what to study in preparation. I asked my future manager to send me a list of things I could read upon and I finally got it this morning. This is the list, extracted from the e-mail: </p>\n\n\n\n<div class=\"wp-block-image\"><figure class=\"aligncenter size-large is-resized\"><img loading=\"lazy\" data-attachment-id=\"497\" data-permalink=\"https://cappuccinocodes.wordpress.com/screen-shot-2021-06-28-at-2-31-42-pm/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-28-at-2.31.42-pm.png\" data-orig-size=\"1112,338\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"screen-shot-2021-06-28-at-2.31.42-pm\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-28-at-2.31.42-pm.png?w=723\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-28-at-2.31.42-pm.png?w=1024\" alt=\"\" class=\"wp-image-497\" width=\"548\" height=\"166\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-28-at-2.31.42-pm.png?w=1024 1024w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-28-at-2.31.42-pm.png?w=548 548w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-28-at-2.31.42-pm.png?w=1096 1096w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-28-at-2.31.42-pm.png?w=150 150w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-28-at-2.31.42-pm.png?w=300 300w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-28-at-2.31.42-pm.png?w=768 768w\" sizes=\"auto, (max-width: 548px) 100vw, 548px\" /></figure></div>\n\n\n\n<p class=\"wp-block-paragraph\">As you can see it&#8217;s a pretty impressive list that doesn&#8217;t make my life much easier. Each one of these bullets is an universe in itself. Going through the checklist, I have <strong>good knowledge</strong> of .Net Core, Webapis, Html/CSS, Angular 4+ ; I have<strong> little experience</strong> with ASP.NET MVC, .NET Framework and Javascript. I have <strong>zero experience</strong> with React. And I had <strong>never heard</strong> of svelte. </p>\n\n\n\n<p class=\"wp-block-paragraph\">The e-mail also mentions Agile/Scrum and BitBucket. I had heard and read a bit about the first but never heard of the latter. It&#8217;s hard to know exactly what I&#8217;ll be needing when I start next week, so what I&#8217;ll do is attack React and ASP.NET Mvc. I think Javascript knowledge is the base all of these frameworks and there&#8217;s definitely a knowledge gap there so I might also do a crash course, but I&#8217;ll keep that in the reserve, I&#8217;m not sure It&#8217;s a good idea to dive into JS out of context. </p>\n\n\n\n<div class=\"wp-block-image\"><figure class=\"aligncenter size-large is-resized\"><img loading=\"lazy\" data-attachment-id=\"499\" data-permalink=\"https://cappuccinocodes.wordpress.com/screen-shot-2021-06-28-at-3-31-00-pm/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-28-at-3.31.00-pm.png\" data-orig-size=\"644,894\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"screen-shot-2021-06-28-at-3.31.00-pm\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-28-at-3.31.00-pm.png?w=644\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-28-at-3.31.00-pm.png?w=644\" alt=\"\" class=\"wp-image-499\" width=\"398\" height=\"553\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-28-at-3.31.00-pm.png?w=398 398w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-28-at-3.31.00-pm.png?w=108 108w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-28-at-3.31.00-pm.png?w=216 216w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-28-at-3.31.00-pm.png 644w\" sizes=\"auto, (max-width: 398px) 100vw, 398px\" /></figure></div>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Learning </strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I had a look at Pluralsight and there&#8217;s a vast amount of material on all of these subjects, but I&#8217;ve also subscribed to Academind, home of one of my favourite teachers, Maximillian Schwarzmuller. I&#8217;m a fan of his teaching style and I can thank my knowledge of Angular in great part to him. I&#8217;m paying mere 19 USD for such valuable knowledge. </p>\n\n\n\n<p class=\"wp-block-paragraph\">Right now I&#8217;m paying a little under 100 AUD monthly for educational subscriptions (Ionic Academy, Pluralsight and Academind), plus a bit more to maintain the azure services I use for training. I think it&#8217;s totally worth every penny.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Ok, time to dive into it!! No time to waste!</p>\n\n\n\n<p class=\"wp-block-paragraph\"></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31007,
            Title = "LEGACY: I Got My First Software Developer Job!!",
            Slug = "i-got-my-first-software-developer-job",
            Description = "I did it!!! After two years of coding obsession, I got my first programming job! I’m in freaking heaven! So many days working at 4 am, banging my head against the wall feeling s...",
            CardImgUrl = "igotmyfirstjob.webp",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2021/06/24/i-got-my-first-software-developer-job/",
            ReleaseDate = new DateTime(2021, 6, 24),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">I did it!!! After two years of coding obsession, I got my first programming job! I’m in freaking heaven! So many days working at 4 am, banging my head against the wall feeling stuck and hopeless and daydreaming about code, I got my offer!!!! I think this is the second happiest day of my life (getting my Aussie visa at Jun,11 2020 being the first).</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>The Journey</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I was browsing this blog to check on the first few posts and this phrase from two years ago sums up my mindset for the past couple of years. Thinking of code all the time, doing whatever it took to know whatever I had to know.</p>\n\n\n\n<figure class=\"wp-block-image size-large is-resized\"><img loading=\"lazy\" data-attachment-id=\"486\" data-permalink=\"https://cappuccinocodes.wordpress.com/screen-shot-2021-06-24-at-11-04-34-pm-1/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-24-at-11.04.34-pm-1.png\" data-orig-size=\"1726,496\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"screen-shot-2021-06-24-at-11.04.34-pm-1\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-24-at-11.04.34-pm-1.png?w=723\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-24-at-11.04.34-pm-1.png?w=1024\" alt=\"\" class=\"wp-image-486\" width=\"757\" height=\"217\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-24-at-11.04.34-pm-1.png?w=1024 1024w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-24-at-11.04.34-pm-1.png?w=757 757w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-24-at-11.04.34-pm-1.png?w=1514 1514w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-24-at-11.04.34-pm-1.png?w=150 150w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-24-at-11.04.34-pm-1.png?w=300 300w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-24-at-11.04.34-pm-1.png?w=768 768w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-24-at-11.04.34-pm-1.png?w=1440 1440w\" sizes=\"auto, (max-width: 757px) 100vw, 757px\" /><figcaption>The Post From Two Years Ago</figcaption></figure>\n\n\n\n<p class=\"wp-block-paragraph\">I can say I’m lucky that I found something I love so much. That made it easy for me to get out of bed straight to my computer (actually after a cold shower) almost every day to get my coding hours early in the morning before life throws things at me. My passion was the fuel to code in any spare time I had. And change my habits and routines to carve out as much time as possible to code. I always knew that the only way to get to where I wanted was to have my butt on the chair and put in the time.&nbsp;</p>\n\n\n\n<p class=\"wp-block-paragraph\">During this time I had a couple of relationships that were pretty much ruined because I didn’t want to dedicate much time to them. Lovely, valuable, incredible women. But for the most part I just wanted to code. I’m lucky that I could quit my dancing job and drive an Uber (with all the flexibility it allows), otherwise I would probably have problems keeping my current girlfriend. And she’s THE ONE. I want to spend the rest of my life with her.&nbsp;</p>\n\n\n\n<p class=\"wp-block-paragraph\">Quitting was the best thing I could have possibly done. It wasn’t hard work per se, but the nature of the job requires a lot of preparation, training, researching and just good old thinking about it. In Uber I do long hours, but there’s none of the extra stuff. And even when I’m driving I can do coding exercises, think about programming, listen to podcasts about it and so on. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Getting the Job</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Another crucial realisation was that in order to get a job I&#8217;d need to focus <a href=\"https://cappuccinocoding.com/\">on a portfolio</a>. That was super important because it made me focus on completing projects. And all it took was ONE SINGLE full stack application for my recruiters to shortlist me for the job. </p>\n\n\n\n<p class=\"wp-block-paragraph\">I had tons of accumulated knowledge from my previous semi-publishable jobs. The projects that were portfolio ready were only WordPress websites and <a href=\"https://cappuccinocoding.com/\">one HTML, CSS, Bootstrap, JS website </a>that doesn&#8217;t even look that good but that made me proud because it was a first.</p>\n\n\n\n<p class=\"wp-block-paragraph\">So with the help of Ionic Academy and my previous C# knowledge I created a <a href=\"http://cappuccinoshifts.azurewebsites.net/\">Shift Tracker </a>that has the whole full-stack lot: Ionic in the front end, C# in the back end, Azure for hosting and database and Firebase for authentication. </p>\n\n\n\n<p class=\"wp-block-paragraph\">When that was done I applied for eight jobs and only one responded. I wasn&#8217;t expecting it at all. I thought I would need way more work on my portfolio.  Everything happened very quickly. I was sent a coding exercise, that was quite complex to me. I had to look up a few things to solve it. I thought for sure I wasn&#8217;t going to pass. But I did and got an interview. Again I thought I had no chance but I guess my enthusiasm and the fact that I communicate reasonably well due to being a teacher were enough to get me through the door. </p>\n\n\n\n<figure class=\"wp-block-image size-large\"><img loading=\"lazy\" width=\"1024\" height=\"174\" data-attachment-id=\"490\" data-permalink=\"https://cappuccinocodes.wordpress.com/screen-shot-2021-06-24-at-11-20-24-pm/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-24-at-11.20.24-pm.png\" data-orig-size=\"1526,260\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"screen-shot-2021-06-24-at-11.20.24-pm\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-24-at-11.20.24-pm.png?w=723\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-24-at-11.20.24-pm.png?w=1024\" alt=\"\" class=\"wp-image-490\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-24-at-11.20.24-pm.png?w=1024 1024w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-24-at-11.20.24-pm.png?w=150 150w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-24-at-11.20.24-pm.png?w=300 300w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-24-at-11.20.24-pm.png?w=768 768w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-24-at-11.20.24-pm.png?w=1440 1440w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-24-at-11.20.24-pm.png 1526w\" sizes=\"auto, (max-width: 1024px) 100vw, 1024px\" /><figcaption>The offer!!</figcaption></figure>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Advice</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Some people might be on the same journey as I am, so if I could give advice on how to get there, here are a few:</p>\n\n\n\n<ul class=\"wp-block-list\"><li><strong>Build stuff</strong>. This is important on so many levels! We’re training to be engineers, so building stuff is the ultimate goal. The feeling of completing a working application is just incredible. And it will provide the confidence boost that self-taught folks out there need so much not to quit. Oh, and of course, completed apps will populate your portfolio, which is absolutely essential to get even considered for a job.&nbsp;</li></ul>\n\n\n\n<ul class=\"wp-block-list\"><li><strong>Find the time</strong>. If you work full time as I do, you’ll either have to wake up early or code after work. I would choose doing it early. I remember listening to a podcast about someone that studied every day from 4 to 8 for 9 months and got a Ruby job. That stuck with me. If you study every single day (or close) for 4 hours there’s just no way you won’t have some solid knowledge by the end of that time. Of course you’ll need some course corrections, but there’s nothing like putting in the time.</li></ul>\n\n\n\n<ul class=\"wp-block-list\"><li><strong>Stick with stuff:</strong> For each problem you’ll need to solve there are dozens of options on how to do it and which tool to use. The first couple of questions will be: Which language to learn and which front-end framework to use. It really doesn’t matter. Pick one and stick to it. The principles are the same and once you’ll learn one you’ll be able to pick others up when needed. I’ll have to learn React from scratch for my new job and I’m confident that my knowledge with ASP.NET MVC and Angular will help. After all, it’s just moving data around!</li></ul>\n\n\n\n<ul class=\"wp-block-list\"><li><strong>Read, read and read</strong>. Even though you’ll stick with a few technologies, don’t ever stop reading. I read literally thousands of articles about all the hundreds of questions that came up during my journey. Dive into Reddit, make it your poop time read. Read it every single day, there’s amazing advice over there. I promise 100% of your questions for your 10 first years as a developer have already been answered online. </li></ul>\n\n\n\n<ul class=\"wp-block-list\"><li><strong>Get a mentor</strong>: Find someone that knows more than you and can help you. I had the luck to have a close friend that’s a C# and Angular Developer that got me unstuck a few times. I’ve also learned a lot just watching him code and observing his thought process. And of course I spent countless hours on <a href=\"https://stackoverflow.com/users/11659311/pablo-aguirre-de-souza\">stack overflow</a>. Those are my indirect mentors along with the teachers I mention in the resources below.</li></ul>\n\n\n\n<ul class=\"wp-block-list\"><li><strong>Don’t think you can’t fix a problem</strong>: I got stuck for weeks with a few problems, but I knew for sure: It has been done before, I’m not building the most complex application in the world. Mankind can control a god damn robot in Mars FROM EARTH, why wouldn’t I be able to do implement some stupid feature in a simple app? Stick to it and YOU WILL SOLVE IT.</li></ul>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>The Resources</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I’ll try to enumerate all resources I used throughout these two years. They were all valuable in their own capacity and some were absolutely essential.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><a href=\"https://www.codecademy.com/\">Codeacademy:</a> My first online resource ever. I took a front end course, very well organised and explained. Super beginner friendly. I breezed through the html part because I had learned it years ago. Then I learned the CSS part but I finished the AJAX and JS parts without understanding them too well. I didn’t continue with them because everything they did was in an embedded IDE so I wasn’t actually building anything, but just rendering code in their IDE. It probably suits most people to learn that way, but I missed actually building something, so I only learned from them for a month or so.&nbsp;</p>\n\n\n\n<p class=\"wp-block-paragraph\"><a href=\"https://www.youtube.com/channel/UC29ju8bIPH5as8OGnQzwJyA\">Traversy Media</a>: This absolute legend of a guy taught me so much! His laid-back, no-fluff, to the point style was exactly what I needed. I learned the basics of many technologies with him. Bootstrap, Javascript, NodeJS, Angular. He’s got excellent material for beginners, building stuff from scratch. He was the one responsible for my first few websites. It’s not a coincidence he has such a massive audience on Youtube.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><a href=\"https://www.udemy.com/user/maximilian-schwarzmuller/\">Maximilian Schwarzmuler:</a> Not long after learning basic JS I realised there was this thing called “framework”, and that’s what everyone uses professionally. My coding mentor uses Angular so that was a natural choice for me, but he warned the learning curve would be steep. And it is, I’m still learning to this day, but I absolutely love Angular. There’s something about how its code is organised and it’s aesthetics that deeply resonates with me.&nbsp;&nbsp;</p>\n\n\n\n<p class=\"wp-block-paragraph\">Learning it was so much easier with the help of this fantastic teacher. His courses are incredible, explaining every little component in detail. I love that not only he teaches aspects of Angular in the context of a project, but also isolates these subjects and teaches them separately, which makes them so much easier to learn! I’ve also taken his Ionic and Angular Material courses and they’re equally great.&nbsp;</p>\n\n\n\n<p class=\"wp-block-paragraph\"><a href=\"https://codegym.cc/\">CodeGym</a>: I also learned pretty quickly that to build the stuff I wanted to build I would need a back-end language. Also influenced by a couple of friends I picked Java and bought a CodeGym subscription. It has the same pros and cons as CoderAcademy. The way the course is put together is super friendly, progressive and with TONS (I mean ridiculous amounts) of exercises, which I love.&nbsp;</p>\n\n\n\n<p class=\"wp-block-paragraph\">But I disconnected a bit from the course after a few months because I was learning advanced topics of programming without building stuff, which was frustrating to me. I remember spending weeks learning about multithreading, and don’t get me wrong, it was super valuable, but I need to build stuff to really understand something.&nbsp;</p>\n\n\n\n<p class=\"wp-block-paragraph\">I think I’m way better at learning isolated from building now, but that’s because having built a few applications I can actually visualise where the new knowledge will be useful. Back then, it just didn’t do it for me.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><a href=\"https://www.udemy.com/user/neil-cummings-2/\">Neil Cummings:</a></p>\n\n\n\n<p class=\"wp-block-paragraph\">When I finally pivoted to C#, due to it being the language my mentor uses in the back end of his free-lance projects, I started learning from Neil Cummings. It was probably not a good idea to start with him because I thought I would understand C# easily after learning basic Java, but I still needed to lay down some foundations. His course is heavy in design patterns and libraries and it isn’t beneficial to learn this stuff without learning the basics first.&nbsp;</p>\n\n\n\n<p class=\"wp-block-paragraph\">Having said that, after building more solid C# skills, his course on Angular + Asp.NET C# was great. Through him I was first exposed to: Entity Framework, Repository Pattern, Specification Patterns, Swagger, DTOs, Automapper and much more. Oh, and it’s impossible not to like his thick British accent.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><a href=\"https://www.udemy.com/user/abdullah-almusawi-3/\">Musavi Abdullah</a></p>\n\n\n\n<p class=\"wp-block-paragraph\">After realising I need to learn proper C# I got a beginner course from Musavi. Super funny teacher and very enthusiastic about coding. He organises his course building several little applications, using windows forms, from a super simple clock to a data table. I loved working with Forms but too bad those days are over. I’d have loved to be a programmer in the 2000s working with desktop applications.&nbsp;</p>\n\n\n\n<p class=\"wp-block-paragraph\"><a href=\"http://ionicacademy.com/\">Ionic Academy</a></p>\n\n\n\n<p class=\"wp-block-paragraph\">Loving Angular of course I would love Ionic too and Simon Grimm does a fantastic job covering all topics in both with super interesting projects, updating his Ionic Academy every week. Along with Pluralsight it’s the other subscription resource I pay for and I don’t plan to stop anytime soon. I’ll still learn so much from him. Oh, and funny guy too.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><a href=\"https://www.youtube.com/channel/UCvzlnZbePin9kH-1JCKBt8Q\">Code Affection</a></p>\n\n\n\n<p class=\"wp-block-paragraph\">Absolutely to the point Youtuber teaching full stack webdev with Angular and Material + Asp.NET. I built my first few full stack CRUD applications due to this great teacher. No fluff, just code. And code that works. Oh, and all free!</p>\n\n\n\n<p class=\"wp-block-paragraph\"><a href=\"https://www.youtube.com/user/IAmTimCorey\">Tim Corey</a></p>\n\n\n\n<p class=\"wp-block-paragraph\">Everyone who learns ASP.NET probably knows Tim Corey, but if you don’t, check him out, NOW. Fantastic teacher, helps you figure out what’s actually important in this vast ocean that is ASP.NET. He was my latest finding and I owe him a big thanks for preparing me for the coding challenge I was given in the selection for this job.&nbsp;</p>\n\n\n\n<p class=\"wp-block-paragraph\"><a href=\"https://www.pluralsight.com/\">Pluralsight</a></p>\n\n\n\n<p class=\"wp-block-paragraph\">By far the most valuable resource. I pay around 40AUD a month for their content and I can say I owe them my salary, so if you haven’t started paying for something as cheap and as valuable as Pluralsight, don’t think again. You don’t know what you’re missing. They have everything you need. Front-end, back-end, SQL, Cloud, Unit testing, CI/CD, tons of theory about OOP, design patterns and general computer science stuff. It’s just amazing.&nbsp;</p>\n\n\n\n<p class=\"wp-block-paragraph\">I honestly love all teachers at Plural sight, but some deserve special mention:&nbsp;</p>\n\n\n\n<ul class=\"wp-block-list\"><li><a href=\"https://www.pluralsight.com/authors/scott-allen?aid=701j0000001heIrAAI&amp;promo=&amp;utm_source=non_branded&amp;utm_medium=digital_paid_search_google&amp;utm_campaign=APAC_Dynamic&amp;utm_content=&amp;cq_cmp=179446758&amp;gclid=Cj0KCQjw2tCGBhCLARIsABJGmZ6q1m8SP6NRoieDE6MYVdycttG2nICUlIqS2CTT5nfhQxqITl0Dx8MaAiO2EALw_wcB\">Scott Allen</a> (RIP). I’ll never forget his powerful voice and teaching style. I can’t thank him enough for his contribution with basic C# and Linq.</li></ul>\n\n\n\n<ul class=\"wp-block-list\"><li><a href=\"https://app.pluralsight.com/profile/author/kevin-dockx\">Kevin Dockx</a>. This is the API master. I’ve done four of his courses on Restful APIs. I promise you’ll learn everything you know about building APIs if you’re a beginner.</li></ul>\n\n\n\n<ul class=\"wp-block-list\"><li><a href=\"https://app.pluralsight.com/profile/author/deborah-kurata\">Deborah Kuratah</a>. I could listen to her voice for hours. It’s like listening to a children’s book. Absolute natural teacher. I did her Object Oriented courses and I’m not sure I can convey how well she explains things.&nbsp;</li></ul>\n\n\n\n<ul class=\"wp-block-list\"><li>Alex Wolf, Gill Cleeren, Shawn Wildermuth, Julie Lerman, Filip Ekberg, Jason Roberts, Paul Sheriff, Thomas Claudius Huber, each contributing with a fundamental piece of this immense puzzle.</li></ul>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Books</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">To finalize this huge post, I can’t forget to mention a few other resources that have helped me so much since 2018 when I first listened to a podcast.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><a href=\"https://jockopodcast.com/\"><strong>Jocko Willink’s Podcast</strong></a><strong> </strong>&#8211; Probably saved my life on many levels. I listened to about 200 of his episodes about war and darkness. Listen to his stuff from episode one and you’ll never complain about anything ever again. You’ll get all the grit you need to accomplish anything you want. DO IT.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><a href=\"https://tim.blog/podcast/\"><strong>Tim Ferriss</strong></a> &#8211; Due to Jocko I got in touch with Tim Ferriss Podcast. I can say he’s the person that influenced my life the most. The way he talks, the way he thinks and his obsession with growing have had a deep impact in my life. Amazing guy, he has interviews with people from all backgrounds, masters of the universe kind of people. Tony Robbins, Schwarzenegger, Richard Branson, Hugh Jackman, Jamie Foxx, Brene Brown, Ray Dalio, Lebron James just to name the most famous.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Books </strong>&#8211; I know some people have trouble reading and I don’t even have time myself but with Audible, there are just no excuses anymore. Just play it on your headphones as you go about your business, don’t find an excuse. If your excuse is just: “I don’t like books”, so fucking start liking it! Why wouldn’t you want to have cheap condensed knowledge from years of other people’s experiences? Do you know it all? Books are ACTUALLY impactful and have the power to change the trajectory of your life.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I’ll just name the ones related to my coding journey:&nbsp;</p>\n\n\n\n<p class=\"wp-block-paragraph\"><a href=\"https://www.goodreads.com/book/show/13589182-mastery\"><strong>Mastery</strong></a> &#8211; Amazing stories about folks that became masters in their field. Learn what it was like in their humble beginning.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><a href=\"https://www.amazon.com/Good-They-Cant-Ignore-You/dp/1455509124\"><strong>So Good They Can’t Ignore You</strong> </a>&#8211; Pretty self-explanatory title.&nbsp;</p>\n\n\n\n<p class=\"wp-block-paragraph\"><a href=\"https://www.goodreads.com/book/show/11084145-steve-jobs\"><strong>Steve Jobs</strong></a> &#8211; If Steve Job’s passion doesn’t inspire you (in despite of the way he treated people), I’ll give you a dollar. Read it, now!</p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31008,
            Title = "LEGACY: Back to the Basics",
            Slug = "back-to-the-basics",
            Description = "I’m currently in the middle of a selection for developer job . I haven’t been writing about it because I want the process to be over before I say anything else. Let’s just say t...",
            CardImgUrl = "backtothebasics.webp",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2021/06/23/back-to-the-basics/",
            ReleaseDate = new DateTime(2021, 6, 23),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">I’m currently in the middle of a <a href=\"https://cappuccinocodes.wordpress.com/2021/06/11/first-time-on-a-shortlist-for-a-developer-job/\">selection for developer job</a> . I haven’t been writing about it because I want the process to be over before I say anything else. Let’s just say that I’m very anxious about the results, even almost being certain I won’t get it. 😔</p>\n\n\n\n<p class=\"wp-block-paragraph\">I had to study a few things for the selection and I realised I have a lot of gaps to close in my understanding of C#. Then I realised since I last looked into the beginner courses at Pluralsight, they have released new ones. All the courses in the C# Fundamentals pathway have been released since April, so the contents are absolutely up to date.&nbsp;</p>\n\n\n\n<p class=\"wp-block-paragraph\">I have just watched <a href=\"https://app.pluralsight.com/library/courses/c-sharp-getting-started\">C# Getting Started</a>, with Paolo Perrotta and <a href=\"https://app.pluralsight.com/library/courses/controlling-program-flow-c-sharp\">Controlling Program Flow in C#</a> with Alex Wolf. The level of instruction is excellent, university level as usual with Pluralsight. I miss <a href=\"https://www.google.com/search?q=scott+allen+c%23&amp;rlz=1C5CHFA_enAU917AU917&amp;sxsrf=ALeKk01pD7VgSoRHPT52KGtOTNN6esCdFA%3A1624407444700&amp;ei=lH3SYPmZKpTHrQGMyKDYBg&amp;oq=scott+allen+&amp;gs_lcp=Cgdnd3Mtd2l6EAEYADIECAAQQzICCAAyAggAMgIIADICCAAyBQgAEMkDMgIIADICCC4yAggAMgIIADoECCMQJzoFCAAQkQI6BQguEJECOgcILhCxAxBDOgQILhBDOgUILhCxAzoICAAQsQMQgwE6CAguEMcBEK8BOgQIABAKSgQIQRgAUPgJWP8VYPglaABwAHgBgAHDA4gB6xaSAQkwLjEuNy4yLjGYAQCgAQGqAQdnd3Mtd2l6wAEB&amp;sclient=gws-wiz\">Scott Allen</a> but these guys deliver!</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>C# Getting Started</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Paolo’s course is super basic, very good for absolute beginners and explains everything from how to build a solution, a project inside a solution, the importance of namespaces, tips for refactoring, debugging, and a bit about types. And of course I always learn something new from these basic courses. For the first time I realised I can add <strong>conditional debugging</strong>. 😱</p>\n\n\n\n<div class=\"wp-block-image\"><figure class=\"aligncenter size-large is-resized\"><img loading=\"lazy\" data-attachment-id=\"266\" data-permalink=\"https://cappuccinocodes.wordpress.com/screen-shot-2021-06-23-at-10-36-09-am/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-23-at-10.36.09-am.png\" data-orig-size=\"412,381\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"screen-shot-2021-06-23-at-10.36.09-am\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-23-at-10.36.09-am.png?w=412\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-23-at-10.36.09-am.png?w=412\" alt=\"\" class=\"wp-image-266\" width=\"411\" height=\"380\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-23-at-10.36.09-am.png?w=411 411w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-23-at-10.36.09-am.png?w=150 150w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-23-at-10.36.09-am.png?w=300 300w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-23-at-10.36.09-am.png 412w\" sizes=\"auto, (max-width: 411px) 100vw, 411px\" /><figcaption>The add comment button (right top) in Visual Studio</figcaption></figure></div>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Controlling Program Flow</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Alex Wolf’s course goes a bit further and talks about expressions, basic statements, iterations, branching, everything that’s at the core of any language. He also touches briefly on refactoring, input/output with files and many cool tips for Visual Studio. I’ve only realised there are buttons for comments and for formatting!! Haha. I like Visual Studio way more after these findings.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Notes</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I’ve been using Roam Research for my notes. I haven’t fully explored all functionalities yet such as the ability to create diagrams linking between files, mainly because of lack of Research, but I’m loving it. The ease with which I can find any reference without having to browse through files is fascinating. It will be a very important tool when I start uni and for my next job.</p>\n\n\n\n<div class=\"wp-block-image\"><figure class=\"aligncenter size-large is-resized\"><img loading=\"lazy\" data-attachment-id=\"268\" data-permalink=\"https://cappuccinocodes.wordpress.com/screen-shot-2021-06-23-at-10-35-51-am/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-23-at-10.35.51-am.png\" data-orig-size=\"805,734\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"screen-shot-2021-06-23-at-10.35.51-am\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-23-at-10.35.51-am.png?w=723\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-23-at-10.35.51-am.png?w=805\" alt=\"\" class=\"wp-image-268\" width=\"496\" height=\"451\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-23-at-10.35.51-am.png?w=496 496w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-23-at-10.35.51-am.png?w=150 150w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-23-at-10.35.51-am.png?w=300 300w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-23-at-10.35.51-am.png?w=768 768w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-23-at-10.35.51-am.png 805w\" sizes=\"auto, (max-width: 496px) 100vw, 496px\" /><figcaption>My notes for Paolo Perrotta&#8217;s course, one of them expanded</figcaption></figure></div>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Next Course</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">The next stage will be <a href=\"https://app.pluralsight.com/course-player?clipId=161a8d06-1fc2-4198-a738-aa254ea5e614\">revisiting the Type system</a> with Gill Cleeren. I’ve already watched the intro videos and it looks promising. It appears not to be limited to just talking about types but also to go into object oriented matters, something I’m increasingly fascinated about.&nbsp;</p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31009,
            Title = "LEGACY: The Linq Saga!",
            Slug = "the-linq-saga",
            Description = "Blog The last couple of weeks of my journey were tough! I went through one of those times every self-taught developer knows well: feeling absolutely stuck. The problem I had gai...",
            CardImgUrl = "linqsaga.webp",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2021/06/16/the-linq-saga/",
            ReleaseDate = new DateTime(2021, 6, 16),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\"><strong>Blog</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">The last couple of weeks of my journey were tough! I went through one of those times every self-taught developer knows well: feeling absolutely stuck.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>The problem</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I had gained some momentum building <strong><a href=\"http://cappuccinoshifts.azurewebsites.net/\">my first app</a></strong>. Day after day I was just building, tweaking, implementing new features, without much trouble. My creative juices were flowing seamlessly. Pure coding bliss.</p>\n\n\n\n<p class=\"wp-block-paragraph\">There&#8217;s still a bunch of stuff to fix on that app, but I decided to start my second. After all, I do need some volume in my portfolio. In the processing of developing it, I wanted to implement a report system. Nothing too crazy I have an SQL table of <strong>events</strong> that have a <strong>type</strong> and a <strong>date</strong>. Then I wanted to display the count of events per date or in any other way I wanted.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>The journey</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I naively thought it would take me a couple of hours to figure it how to implement the report. I started trying to do it with typescript in the front-end. Something like generating a map with the dates and an object with the type and count as properties.&nbsp;</p>\n\n\n\n<p class=\"wp-block-paragraph\">It turned out to be more laborious than I thought so after half a day I decided to try to do it in the backend, using the power of C#. After another couple of hours banging my head against the wall with Linq, I posted a <a href=\"https://stackoverflow.com/questions/67739721/filtering-and-counting-simultaneously-in-c-sharp/67755573#67755573\">question on Stackoverflow</a>.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>The realisation</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I got bad reputation for the question, which made me realise I don&#8217;t know much of Linq and SQL in the first place. The replies on my post were close to unreadable to me. The chain of Linq queries was way above my knowledge and they didn’t work because the solutions didn’t use Linq against Entity framework. I spent three hours trying to adjust the reply to use entity framework but it just wouldn’t work.</p>\n\n\n\n<p class=\"wp-block-paragraph\">At that point I was already very tired and I had even skipped my lunch time Uber shift and my afternoon workout to try to fix it. So the frustration was kicking in. I jumped into Pluralsight to watch some videos about Linq but suddenly I realised what the problem is. I just didn&#8217;t know enough SQL. Even if I used Linq I feel like I’d be cheating, after all the database is the app&#8217;s brain and SQL is the nerve impulses. </p>\n\n\n\n<figure class=\"wp-block-image size-large\"><img loading=\"lazy\" width=\"1024\" height=\"393\" data-attachment-id=\"260\" data-permalink=\"https://cappuccinocodes.wordpress.com/screen-shot-2021-06-16-at-6-56-26-pm/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-16-at-6.56.26-pm.png\" data-orig-size=\"1654,636\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"screen-shot-2021-06-16-at-6.56.26-pm\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-16-at-6.56.26-pm.png?w=723\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-16-at-6.56.26-pm.png?w=1024\" alt=\"\" class=\"wp-image-260\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-16-at-6.56.26-pm.png?w=1024 1024w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-16-at-6.56.26-pm.png?w=150 150w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-16-at-6.56.26-pm.png?w=300 300w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-16-at-6.56.26-pm.png?w=768 768w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-16-at-6.56.26-pm.png?w=1440 1440w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-16-at-6.56.26-pm.png 1654w\" sizes=\"auto, (max-width: 1024px) 100vw, 1024px\" /><figcaption>The beautiful SQL query to pivot a table dynamically</figcaption></figure>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>The change</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">So after two days of feeling helpless I decided to embrace my ignorance and go back to the beginning. Revisiting SQL from scratch Pluralsight, this time running all sorts of queries , as simple as a SELECT and directly into SQLite. Then I decided to move to MS SQL Server because SQLite didn&#8217;t offer good support for Datetimeoffset, which I use in my program. Instead of going back and forth using Windows Parallels I used SQL Server in a Docker Container.</p>\n\n\n\n<p class=\"wp-block-paragraph\">It’s amazing that in two years of training I have neglected talking directly with databases, which is what I love the most. Starting to finally understand SQL in a deeper level was like finally being able to communicate after being lost in a new country.&nbsp;</p>\n\n\n\n<p class=\"wp-block-paragraph\">I’ve also realised I can combine raw SQL with Linq using the rawsql query, which could be helpful in cases where Linq shows limitations.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Eureka! </strong></p>\n\n\n\n<div class=\"wp-block-image\"><figure class=\"aligncenter size-large is-resized\"><img loading=\"lazy\" data-attachment-id=\"258\" data-permalink=\"https://cappuccinocodes.wordpress.com/screen-shot-2021-06-16-at-6-59-04-pm/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-16-at-6.59.04-pm.png\" data-orig-size=\"890,1026\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"screen-shot-2021-06-16-at-6.59.04-pm\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-16-at-6.59.04-pm.png?w=723\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-16-at-6.59.04-pm.png?w=888\" alt=\"\" class=\"wp-image-258\" width=\"351\" height=\"404\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-16-at-6.59.04-pm.png?w=351 351w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-16-at-6.59.04-pm.png?w=702 702w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-16-at-6.59.04-pm.png?w=130 130w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-16-at-6.59.04-pm.png?w=260 260w\" sizes=\"auto, (max-width: 351px) 100vw, 351px\" /><figcaption>The Result! Pivoted Data!</figcaption></figure></div>\n\n\n\n<p class=\"wp-block-paragraph\">After almost three weeks and a LOT of studying, I finally did it! I can implement any type of report I want. This will unlock the power to create many apps in a short amount of time. Some of the things I&#8217;ve learned in the process.</p>\n\n\n\n<ul class=\"wp-block-list\"><li>Entity Framework has limitations. Apparently it&#8217;s well known that &#8220;Group By&#8221; can face some issues against EF.</li><li>String Concatenation in C#! So much better than plus sign!</li><li>Basic SQL, pivoting tables statically and dynamically, creating stored procedures</li><li>Basic Linq, anonymous objects and reporting the equivalent to a pivoted table</li><li><a href=\"https://stackoverflow.com/questions/67994851/error-accessing-nested-array-of-objects-in-typescript/67994888?noredirect=1#comment120180476_67994888\">Javascript is case sensitive</a>! The Final Hurdle in the front-end. Wasted about five hours on this one. </li></ul>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31010,
            Title = "LEGACY: First Time On a Shortlist For a Developer Job!",
            Slug = "first-time-on-a-shortlist-for-a-developer-job",
            Description = "This was a great week of coding! On Monday I got an e-mail from a big company saying my application was progressed to a shortlist of candidates they wanted to follow up with. Fa...",
            CardImgUrl = "firstimeshortlisted.webp",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2021/06/11/first-time-on-a-shortlist-for-a-developer-job/",
            ReleaseDate = new DateTime(2021, 6, 11),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">This was a great week of coding! On Monday I got an e-mail from a big company saying my application was progressed to a shortlist of candidates they wanted to follow up with. Fantastic! I’ve applied for 9 jobs so far and haven’t heard back from anyone, so it was a great feeling!</p>\n\n\n\n<p class=\"wp-block-paragraph\">Not because I think I have any chance to actually get the job, but that means what I’m doing isn’t complete rubbish, and I might be navigating these muddy self-taught waters in the right direction. </p>\n\n\n\n<p class=\"wp-block-paragraph\">When you don’t hear back from anyone, it’s very hard to know what you’re doing wrong. I got great feedback from a <a href=\"https://www.reddit.com/r/dotnet/comments/nhk164/i_just_created_my_first_fullstack_web_app_for_my/\">Reddit post</a> where folks looked at <a href=\"http://cappuccinoshifts.azurewebsites.net/\">my first app</a> and my <a href=\"https://cappuccinocoding.com/\">portfolio</a> and that was super helpful. But to have my stuff seen by a hiring manager in a big company and actually be considered for the job is a huge boost in my confidence.</p>\n\n\n\n<div class=\"wp-block-image\"><figure class=\"aligncenter is-resized\"><img src=\"https://lh6.googleusercontent.com/XKe5-CwMlBsHQSCivrpoLKui7lfXL2buP4M0fTJI3jAejRxu0lu6Y1hmJGDgqgNmHeTSr-g72n5i5S5Pn8BqZ2Mj8NR-XiGlMtpLZnkEwwQock7h3lv8LszV7A6vU9Db2KHjusLZ\" alt=\"\" width=\"-172\" height=\"-63\" /></figure></div>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>The process</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Although I was very excited with the e-mail, I knew from the get go I was in trouble. I was sent a programming exercise to solve and send back to them by the end of the week. I had to consume data from a mock repo and show it using a front-end of my choice. And I had to use the <a href=\"https://dotnettutorials.net/lesson/introduction-to-inversion-of-control/\">Inversion of Control</a> (IoC) pattern to get it done. </p>\n\n\n\n<p class=\"wp-block-paragraph\">It seemed quite straight-forward at first glance.&nbsp; But I knew I’d be busy with things that were time sensitive and I wouldn’t be able to reschedule.</p>\n\n\n\n<p class=\"wp-block-paragraph\">On Tuesday I was sent the exercise and in the next couple of days while doing my Uber Eats shifts I would look at the exercise and try to solve it mentally whenever I had the chance. I also looked up videos that used the IoC pattern in C#, the only thing in the exercise I had never seen before.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Getting it done</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">So after three days I could finally sit down and start doing it. I sat down just after midnight on Thursday. I would have to pull an allnighter because I wanted to send it back early in the morning. I don’t think the hiring manager would be impressed with something sent any later than that.&nbsp;</p>\n\n\n\n<p class=\"wp-block-paragraph\">I used <a href=\"https://www.youtube.com/watch?v=mCUNrRtVVWY\">this video</a> by Tim Corey to learn IoC and happily after an hour I could get my dependencies injected with Autofac. What a relief. I knew I still had a bunch of work ahead of me but nothing I hadn’t done before. I knew I was going to get it done.</p>\n\n\n\n<div class=\"wp-block-image\"><figure class=\"aligncenter size-large is-resized\"><img loading=\"lazy\" data-attachment-id=\"248\" data-permalink=\"https://cappuccinocodes.wordpress.com/screen-shot-2021-06-11-at-1-44-43-pm/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-11-at-1.44.43-pm.png\" data-orig-size=\"495,143\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"screen-shot-2021-06-11-at-1.44.43-pm\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-11-at-1.44.43-pm.png?w=495\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-11-at-1.44.43-pm.png?w=495\" alt=\"\" class=\"wp-image-248\" width=\"492\" height=\"142\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-11-at-1.44.43-pm.png?w=492 492w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-11-at-1.44.43-pm.png?w=150 150w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-11-at-1.44.43-pm.png?w=300 300w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/screen-shot-2021-06-11-at-1.44.43-pm.png 495w\" sizes=\"auto, (max-width: 492px) 100vw, 492px\" /></figure></div>\n\n\n\n<p class=\"wp-block-paragraph\">Seven hours and six shots of coffee later, not without some hiccups along the way (namely working with anonymous objects coming from the API to be consumed by Angular), I handed it in. I was tired but relieved. I still don’t think I have any chance to get the job but I did it. I solved the challenge.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>The aftermath</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">After a few hours of sleep I woke up thinking of the things I could have done better and I need to think about for the future.&nbsp;</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>The first one</strong> is to do a better job in the front end. I literally presented the data using the same template I’ve used in my previous apps. I can definitely build something more interesting next time.&nbsp;</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>The second</strong> is to include unit tests. I’m still learning about it but I think it has the potential to impress employers. Once I learn it, I’ll include it in the apps in my portfolio too.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>And finally</strong>, error handling. I don’t have any try and catch blocks in my code and I’m sure this is a deal breaker. Basically I haven’t learned any error handling since doing my first Java Course 18 months ago. I think this is the easiest and fastest skill to add to my arsenal so I’m jumping right into it next time I sit down to code.</p>\n\n\n\n<p class=\"wp-block-paragraph\">My first tech job is coming, I can feel it!&nbsp;</p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31011,
            Title = "LEGACY: My first app!!",
            Slug = "my-first-app",
            Description = "I posted a while ago when I first created a resemblance of an application. From that point I started calling myself a full-stack developer. I knew how to put together an app wit...",
            CardImgUrl = "myfirstapp.webp",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2021/05/21/my-first-app/",
            ReleaseDate = new DateTime(2021, 5, 21),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">I <a href=\"https://cappuccinocodes.wordpress.com/2020/11/16/im-a-full-stack-developer/\">posted a while ago</a> when I first created a resemblance of an application. From that point I started calling myself a full-stack developer. I knew how to put together an app with the front-end, back-end and data access. It was a simple crud application without much use in anyone’s life.</p>\n\n\n\n<p class=\"wp-block-paragraph\">This time it’s different. I created a <a href=\"http://cappuccinoshifts.azurewebsites.net/\">web app</a> for my girlfriend, who is a nurse, to track her shifts. The front-end is in Ionic/Angular, the authentication is with Firebase and the database and hosting are in Azure. It’s not super complex but I told her to be a demanding customer so I can feel the pressure of a real project and constantly having to deal with the flow of patching up, testing, deploying and maintaining the application.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Every day we think of a functionality that could be interesting for the app and I try to implement it. I’m learning to stream line my tests and the development flow to spend as little time as possible on trivial repetitive tasks as possible. </p>\n\n\n\n<p class=\"wp-block-paragraph\">But I definitely need to learn more about unit testing and end to end testing for APIs so I can quickly test all my functions and not waste my time doing everything manually. One example was when I fixed the time picker and got it to show my time zone but that messed with the input of the times. It took me a couple of hours to figure out that I had to change the time zone of my Azure App Service to get it finally fixed. I just love the feeling of solving these types of problems.</p>\n\n\n\n<div class=\"wp-block-image\"><figure class=\"aligncenter size-large is-resized\"><img loading=\"lazy\" data-attachment-id=\"241\" data-permalink=\"https://cappuccinocodes.wordpress.com/screen-shot-2021-05-21-at-10-36-27-am/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/05/screen-shot-2021-05-21-at-10.36.27-am.png\" data-orig-size=\"884,1472\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"screen-shot-2021-05-21-at-10.36.27-am\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/05/screen-shot-2021-05-21-at-10.36.27-am.png?w=615\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/05/screen-shot-2021-05-21-at-10.36.27-am.png?w=615\" alt=\"\" class=\"wp-image-241\" width=\"294\" height=\"490\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/05/screen-shot-2021-05-21-at-10.36.27-am.png?w=294 294w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/05/screen-shot-2021-05-21-at-10.36.27-am.png?w=588 588w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/05/screen-shot-2021-05-21-at-10.36.27-am.png?w=90 90w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/05/screen-shot-2021-05-21-at-10.36.27-am.png?w=180 180w\" sizes=\"auto, (max-width: 294px) 100vw, 294px\" /></figure></div>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Next Steps</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">The next few things in my list of things to learn are:</p>\n\n\n\n<ul class=\"wp-block-list\"><li>Ionic Storage so I can build apps without depending on an external database</li><li>Role-based authentication with Firebase, which will open up all sorts of possibilities to create apps for multiple users</li><li>Using Cordova and capacitor to create apps that use cameras features. I’m particularly interested in voice-recognition </li></ul>\n\n\n\n<p class=\"wp-block-paragraph\">Ok, enough chit chat&#8230; back to work!! 🤓</p>\n\n\n\n<p class=\"wp-block-paragraph\"></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31012,
            Title = "LEGACY: Free to Code",
            Slug = "free-to-code",
            Description = "Last Saturday I had my last commitment in my time as a dance teacher. I might still do the odd workshop or covering for someone when needed, but I’m not longer teaching to suppo...",
            CardImgUrl = "freetocode.webp",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2021/05/03/free-to-code/",
            ReleaseDate = new DateTime(2021, 5, 3),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">Last Saturday I had my last commitment in my time as a dance teacher. I might still do the odd workshop or covering for someone when needed, but I’m not longer teaching to support myself. And it feeeels greeeeat!</p>\n\n\n\n<figure class=\"wp-block-image size-large\"><img loading=\"lazy\" width=\"1024\" height=\"768\" data-attachment-id=\"233\" data-permalink=\"https://cappuccinocodes.wordpress.com/img_6922/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/05/img_6922.jpg\" data-orig-size=\"1440,1080\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"img_6922\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/05/img_6922.jpg?w=723\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/05/img_6922.jpg?w=1024\" alt=\"\" class=\"wp-image-233\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/05/img_6922.jpg?w=1024 1024w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/05/img_6922.jpg?w=150 150w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/05/img_6922.jpg?w=300 300w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/05/img_6922.jpg?w=768 768w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/05/img_6922.jpg 1440w\" sizes=\"auto, (max-width: 1024px) 100vw, 1024px\" /><figcaption>One of my highlights as a salsa teacher</figcaption></figure>\n\n\n\n<p class=\"wp-block-paragraph\">For the first time since I can remember I can do whatever I want , whenever I want to do it. Obviously I still have to work a lot, but not at any given time. It’s a great feeling. </p>\n\n\n\n<p class=\"wp-block-paragraph\">In my first few days of freedom I haven’t worked much, enjoying the holiday watching  beautiful Queenslander sunsets with my girl. I was also able to add a small movie database app to <a href=\"https://cappuccinocoding.com/\">my portfolio</a>. It’s built with Ionic and a third party api and was created from a tutorial at the great <a href=\"https://ionicacademy.com/\">Ionic Academy</a>. I love Simon’s videos and I plan to spend a long time working through his material.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I won’t expand on it too much at the moment because I want to have a few more apps under my belt to start sending CVs again. But as soon as I have two or three more, I’ll go back and add extra functionalities I have in mind. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Strategy </strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">The idea of creating apps from tutorials and then improving them seems work really well. It’s good to start from a template so I’m not completely lost, but then expanding on the app and tweaking with more complex functionalities drives home the knowledge. There’s nothing better than sitting for hours trying to move data around inside an app to cement my learning. </p>\n\n\n\n<p class=\"wp-block-paragraph\">Now <strong>back to work</strong>! 🤓</p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31013,
            Title = "LEGACY: Build, build, build",
            Slug = "build-build-build",
            Description = "The most consistent piece of advice I’ve got amongst the many comments in my Reddit post about going to Uni was: “Work on your portfolio. That’s the number one thing recruiters...",
            CardImgUrl = "buildbuildbuild.webp",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2021/04/20/build-build-build/",
            ReleaseDate = new DateTime(2021, 4, 20),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">The most consistent piece of advice I’ve got amongst the many comments in my <a href=\"https://www.reddit.com/r/learnprogramming/comments/mn8mnm/at_39_im_quitting_my_job_and_going_back_to_uni/\">Reddit post about going to Uni</a> was: “Work on your portfolio. That’s the number one thing recruiters look at when assessing resumes for entry level positions&#8221;. </p>\n\n\n\n<p class=\"wp-block-paragraph\">Many people went so far as saying that a college degree isn’t necessary at all, if I work on my portfolio. They might be right, but I still wouldn’t pass on the opportunity to study cheaply to be the best engineer I can be. I know it&#8217;s three years of hard work and that can potentially hinder my short term capability to get into the tech industry, but I really don&#8217;t care. I&#8217;m sure in the long run having a degree is better than not. </p>\n\n\n\n<p class=\"wp-block-paragraph\">So this is my number one goal in life right now. To build a solid portfolio. I have an income goal, fitness goals and relationship goals, but these are all secondary right now. Build, build, build, that&#8217;s all I think about. I have to be so good and develop a portfolio that people just won&#8217;t be able to ignore. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>What to build?</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">My idea is to create several full stack apps that showcase my ability to put an UI together with Angular/Ionic and a back-end with ASP.NET, with the help of Firebase and Azure for data, hosting and authentication. </p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;ll create apps from scratch but also use ideas from tutorials that I&#8217;ll follow and then tweak to add functionalities. I can&#8217;t overthink it. I&#8217;m a wanna be engineer. Engineers build stuff. And that&#8217;s what I have to do. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Building Knowledge</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Obviously I can&#8217;t just build. I have to create detailed checklists and manuals for myself so I don&#8217;t have to reinvent the wheel every time I start. For that I&#8217;ll be using &#8220;Roam Research&#8221;, the best notetaker I&#8217;ve ever found, where my notes can easily be cross-referenced so I can build a body of knowledge. I&#8217;ve tried making notes on Evernote and Google Docs, and they&#8217;re good apps, but they hierarchical way in which they&#8217;re organised limits the cross flow of notes and ideas. <a href=\"https://roamresearch.com/\">Roam Research</a> is built with that in mind and I highly recommend it. </p>\n\n\n\n<figure class=\"wp-block-image size-large\"><img loading=\"lazy\" width=\"1024\" height=\"653\" data-attachment-id=\"226\" data-permalink=\"https://cappuccinocodes.wordpress.com/screen-shot-2021-04-20-at-11-39-48-am/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/04/screen-shot-2021-04-20-at-11.39.48-am.png\" data-orig-size=\"2084,1330\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"screen-shot-2021-04-20-at-11.39.48-am\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/04/screen-shot-2021-04-20-at-11.39.48-am.png?w=723\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/04/screen-shot-2021-04-20-at-11.39.48-am.png?w=1024\" alt=\"\" class=\"wp-image-226\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/04/screen-shot-2021-04-20-at-11.39.48-am.png?w=1024 1024w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/04/screen-shot-2021-04-20-at-11.39.48-am.png?w=2048 2048w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/04/screen-shot-2021-04-20-at-11.39.48-am.png?w=150 150w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/04/screen-shot-2021-04-20-at-11.39.48-am.png?w=300 300w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/04/screen-shot-2021-04-20-at-11.39.48-am.png?w=768 768w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/04/screen-shot-2021-04-20-at-11.39.48-am.png?w=1440 1440w\" sizes=\"auto, (max-width: 1024px) 100vw, 1024px\" /><figcaption>Example of note taken with Roam Research</figcaption></figure>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31014,
            Title = "LEGACY: Choosing Computer Science vs Information Technology",
            Slug = "choosing-computer-science-vs-information-technology",
            Description = "After much consideration I’ve made up my mind last night and decided to pursue Computer Science instead of Information Technology. That was always my intention but the course is...",
            CardImgUrl = "chosingcsvsit.webp",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2021/04/18/choosing-computer-science-vs-information-technology/",
            ReleaseDate = new DateTime(2021, 4, 18),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">After much consideration I’ve made up my mind last night and decided to pursue Computer Science instead of Information Technology. That was always my intention but the course is only offered on Semester 2, so I decided to apply for IT without much hope of getting in, but fortunately I was underestimating my chances. </p>\n\n\n\n<p class=\"wp-block-paragraph\">It seemed clear to me that the future can be bright whatever my choice was, so I decided based on a combination of circumstance and personal preference. Computer Science has stuff that I find super interesting such as Machine Learning and Wearables.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Information technology would be the easy way. The course isn’t Maths intensive and that would make my life much easier, considering I haven’t done any Maths in probably 20 years. </p>\n\n\n\n<p class=\"wp-block-paragraph\">I’ll be doing three subjects that are common to Computer Science plus an intro to Calculus, which will serve as the Maths prerequisite I need to get into CS.</p>\n\n\n\n<p class=\"wp-block-paragraph\">It’s still surreal to me I will have the chance to study in an Australian University and I want to make the most of it. I’ll aim to get maximum grades and impress all my teachers. There’s no excuse for me not to annihilate every single subject I encounter. Not only I’m better equipped with study techniques and mindset but I also love everything I’ll be studying. </p>\n\n\n\n<p class=\"wp-block-paragraph\">Here’s the course program for IT and CS for comparison:</p>\n\n\n\n<figure class=\"wp-block-image size-large\"><img loading=\"lazy\" width=\"473\" height=\"1023\" data-attachment-id=\"218\" data-permalink=\"https://cappuccinocodes.wordpress.com/2021/04/18/choosing-computer-science-vs-information-technology/img_7009/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/04/img_7009.png\" data-orig-size=\"1284,2778\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"img_7009\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/04/img_7009.png?w=473\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/04/img_7009.png?w=473\" alt=\"\" class=\"wp-image-218\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/04/img_7009.png?w=473 473w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/04/img_7009.png?w=946 946w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/04/img_7009.png?w=69 69w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/04/img_7009.png?w=139 139w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/04/img_7009.png?w=768 768w\" sizes=\"auto, (max-width: 473px) 100vw, 473px\" /><figcaption>Computer Science Program</figcaption></figure>\n\n\n\n<figure class=\"wp-block-image size-large\"><img loading=\"lazy\" width=\"473\" height=\"1023\" data-attachment-id=\"219\" data-permalink=\"https://cappuccinocodes.wordpress.com/2021/04/18/choosing-computer-science-vs-information-technology/img_7010/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/04/img_7010.png\" data-orig-size=\"1284,2778\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"img_7010\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/04/img_7010.png?w=473\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/04/img_7010.png?w=473\" alt=\"\" class=\"wp-image-219\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/04/img_7010.png?w=473 473w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/04/img_7010.png?w=946 946w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/04/img_7010.png?w=69 69w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/04/img_7010.png?w=139 139w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/04/img_7010.png?w=768 768w\" sizes=\"auto, (max-width: 473px) 100vw, 473px\" /><figcaption>IT Program</figcaption></figure>\n		<div id=\"geo-post-220\" class=\"geo geo-post\" style=\"display: none\">\n			<span class=\"latitude\">-26.652744</span>\n			<span class=\"longitude\">153.088979</span>\n		</div>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31015,
            Title = "LEGACY: Back to School!!!",
            Slug = "back-to-school",
            Description = "I’m feeling fantastic. I have just received my offer to study Information Technology at the University of Sunshine Coast, in Australia. My commitment to get into the tech indust...",
            CardImgUrl = "legacy-back-to-school.jpeg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2021/04/09/back-to-school/",
            ReleaseDate = new DateTime(2021, 4, 9),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">I’m feeling fantastic. I have just received my offer to study Information Technology at the University of Sunshine Coast, in Australia. My commitment to get into the tech industry and do what I love the most feels more real than never now. The last time I had a feeling like this was when I got my permanent residency. Feels great, baby!  <strong>And the next???</strong> It will be when I get my first tech job offer. It&#8217;s coming! <strong>I CAN FEEL IT.</strong> 😎</p>\n\n\n\n<figure class=\"wp-block-image size-large\"><img loading=\"lazy\" width=\"1024\" height=\"255\" data-attachment-id=\"213\" data-permalink=\"https://cappuccinocodes.wordpress.com/2021/04/09/back-to-school/screen-shot-2021-04-09-at-8-19-20-pm/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/04/screen-shot-2021-04-09-at-8.19.20-pm.png\" data-orig-size=\"1974,492\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"Screen Shot 2021-04-09 at 8.19.20 pm\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/04/screen-shot-2021-04-09-at-8.19.20-pm.png?w=723\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/04/screen-shot-2021-04-09-at-8.19.20-pm.png?w=1024\" alt=\"\" class=\"wp-image-213\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/04/screen-shot-2021-04-09-at-8.19.20-pm.png?w=1024 1024w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/04/screen-shot-2021-04-09-at-8.19.20-pm.png?w=150 150w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/04/screen-shot-2021-04-09-at-8.19.20-pm.png?w=300 300w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/04/screen-shot-2021-04-09-at-8.19.20-pm.png?w=768 768w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/04/screen-shot-2021-04-09-at-8.19.20-pm.png?w=1440 1440w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/04/screen-shot-2021-04-09-at-8.19.20-pm.png 1974w\" sizes=\"auto, (max-width: 1024px) 100vw, 1024px\" /></figure>\n\n\n\n<p class=\"wp-block-paragraph\">The timing couldn&#8217;t have been better. About two weeks ago I told my boss I was quitting in a month. She was shocked because students love me and I&#8217;m a passionate teacher but I just felt so relieved I could dedicate all of my bandwith to learning to code. </p>\n\n\n\n<p class=\"wp-block-paragraph\">This is what life looks like, most days, in the next three months, in preparation for Uni: </p>\n\n\n\n<p class=\"wp-block-paragraph\"><em>6am: Wake Up &#8211; Study/Code</em></p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>11am: Uber</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\"><em>3pm: Gym, Nap</em></p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>5pm: Uber</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\"><em>9pm: Study/Code</em></p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>11pm: Sleep</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\"></p>\n\n\n\n<figure class=\"wp-block-image size-large\"><img loading=\"lazy\" width=\"1024\" height=\"683\" data-attachment-id=\"214\" data-permalink=\"https://cappuccinocodes.wordpress.com/2021/04/09/back-to-school/15585559931_a1644ccd3a_b/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/04/15585559931_a1644ccd3a_b.jpeg\" data-orig-size=\"1024,683\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"15585559931_a1644ccd3a_b\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/04/15585559931_a1644ccd3a_b.jpeg?w=723\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/04/15585559931_a1644ccd3a_b.jpeg?w=1024\" alt=\"\" class=\"wp-image-214\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/04/15585559931_a1644ccd3a_b.jpeg 1024w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/04/15585559931_a1644ccd3a_b.jpeg?w=150 150w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/04/15585559931_a1644ccd3a_b.jpeg?w=300 300w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/04/15585559931_a1644ccd3a_b.jpeg?w=768 768w\" sizes=\"auto, (max-width: 1024px) 100vw, 1024px\" /></figure>\n\n\n\n<p class=\"wp-block-paragraph\">Oh and of course, spend time with my girlfriend 😍 when she&#8217;s not working her ass off too. She&#8217;s a gorgeous British nurse that will dump me really quickly If I don&#8217;t find time for her. 😜 But she&#8217;s very understanding. She was in the same position a few years ago when she was studying and still trying residency in Australia. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Reddit</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I <a href=\"https://www.reddit.com/r/learnprogramming/comments/mn8mnm/at_39_im_quitting_my_job_and_going_back_to_uni/\">made a post on Reddit</a> about my plans and in less than four hours I got close to 500 upvotes 😱. I don&#8217;t really care about being internet famous, but this makes me realise there are so many people doing or thinking of doing the same thing. When I&#8217;m finally successful in this industry I&#8217;ll definitely find ways to help people that are on the same path. 👊👊👊</p>\n\n\n\n<p class=\"wp-block-paragraph\"></p>\n\n\n\n<p class=\"wp-block-paragraph\"></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31016,
            Title = "LEGACY: Course: Building a Webapp with Shawn Wildermuth",
            Slug = "course-building-a-webapp-with-shawn-wildermuth",
            Description = "Yesterday I started my latest Pluralsight course: Building a Web App with ASP.NET Core, MVC, Entity Framework Core, Bootstrap, and Angular with Shawn Wildermuth. I’m still half...",
            CardImgUrl = "legacy-course-building-a-webapp-with-shawn-wildermuth.jpeg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2021/03/26/course-building-a-webapp-with-shawn-wildermuth/",
            ReleaseDate = new DateTime(2021, 3, 26),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">Yesterday I started my latest Pluralsight course: <a href=\"https://app.pluralsight.com/library/courses/aspnetcore-mvc-efcore-bootstrap-angular-web/table-of-contents\">Building a Web App with ASP.NET Core, MVC, Entity Framework Core, Bootstrap, and Angular</a> with Shawn Wildermuth.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I’m still half way through it but I’ll tell you. This course is a beast! It covers so much ground: HTML, CSS, JavaScript, Jquery, MVC with Razor Pages, Entity Framework, SQL, Bootstrap, Angular, the whole shebang.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I <strong>highly</strong> recommend this course for beginners and intermediate learners out there because it can be quite confusing learning these technologies isolated from one another. Shawn does a terrific job connecting the dots so far. In the course, a &#8220;Dutch Art&#8221; online shop is set up from zero, slowly adding up the components and functionalities as a vehicle for teaching. </p>\n\n\n\n<div class=\"wp-block-image\"><figure class=\"aligncenter size-large\"><img loading=\"lazy\" width=\"513\" height=\"534\" data-attachment-id=\"201\" data-permalink=\"https://cappuccinocodes.wordpress.com/2021/03/26/course-building-a-webapp-with-shawn-wildermuth/screen-shot-2021-04-02-at-7-31-11-am/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/03/screen-shot-2021-04-02-at-7.31.11-am.png\" data-orig-size=\"513,534\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"Screen Shot 2021-04-02 at 7.31.11 am\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/03/screen-shot-2021-04-02-at-7.31.11-am.png?w=513\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/03/screen-shot-2021-04-02-at-7.31.11-am.png?w=513\" alt=\"\" class=\"wp-image-201\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/03/screen-shot-2021-04-02-at-7.31.11-am.png 513w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/03/screen-shot-2021-04-02-at-7.31.11-am.png?w=144 144w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/03/screen-shot-2021-04-02-at-7.31.11-am.png?w=288 288w\" sizes=\"auto, (max-width: 513px) 100vw, 513px\" /><figcaption>The &#8220;Dutch Shop&#8221; in its early stages</figcaption></figure></div>\n\n\n\n<p class=\"wp-block-paragraph\">Up to now I’ve put together applications using MVC principles with Angular and Asp.Net (and that’s what I was looking for with this particular course) but I’ve never actually used the scaffold provided by Microsoft with their views. That’s mainly because I love Angular 😍.</p>\n\n\n\n<p class=\"wp-block-paragraph\">But I’m not passing the opportunity to learn a bit of the Microsoft way of doing things. I’m definitely not diving deep into MVC in the future but it doesn’t hurt to know a bit about it. </p>\n\n\n\n<p class=\"wp-block-paragraph\">Another great thing about this course is that Shawn provides excellent support. If you’ve got questions he <strong>will reply</strong> in the comments. I think that’s a huge plus to an online course as it’s almost sure questions will arise. It’s great to have an instructor that will actually help. </p>\n\n\n\n<div class=\"wp-block-image\"><figure class=\"aligncenter size-large\"><img loading=\"lazy\" width=\"508\" height=\"262\" data-attachment-id=\"202\" data-permalink=\"https://cappuccinocodes.wordpress.com/2021/03/26/course-building-a-webapp-with-shawn-wildermuth/screen-shot-2021-04-02-at-7-34-22-am/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/03/screen-shot-2021-04-02-at-7.34.22-am.png\" data-orig-size=\"508,262\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"Screen Shot 2021-04-02 at 7.34.22 am\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/03/screen-shot-2021-04-02-at-7.34.22-am.png?w=508\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/03/screen-shot-2021-04-02-at-7.34.22-am.png?w=508\" alt=\"\" class=\"wp-image-202\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/03/screen-shot-2021-04-02-at-7.34.22-am.png 508w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/03/screen-shot-2021-04-02-at-7.34.22-am.png?w=150 150w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/03/screen-shot-2021-04-02-at-7.34.22-am.png?w=300 300w\" sizes=\"auto, (max-width: 508px) 100vw, 508px\" /><figcaption>My first time working with ASP.NET&#8217;s MVC</figcaption></figure></div>\n\n\n\n<p class=\"wp-block-paragraph\">The course was originally published in 2017 and it has just been updated. I don’t think doing a course that’s a few years old is a bad idea. Learning the not-so-new of doing things is great because I understand a big part of a developers job is to maintain legacy code or upgrade it to the latest technology. </p>\n\n\n\n<p class=\"wp-block-paragraph\">I can&#8217;t wait to finish this course and have the result in my portfolio! 😍</p>\n\n\n\n<p class=\"wp-block-paragraph\"></p>\n\n\n\n<p class=\"wp-block-paragraph\"></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31017,
            Title = "LEGACY: And The Quest to Find a Tech Job Begins",
            Slug = "and-the-quest-to-find-a-tech-job-begins",
            Description = "I had a very eventful month. Some significant changes are ahead, always in pursuit of my ultimate goal: Getting into the tech industry. Applying for Jobs Two days ago I started...",
            CardImgUrl = "legacy-and-the-quest-to-find-a-tech-job-begins.jpeg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2021/03/26/and-the-quest-to-find-a-tech-job-begins/",
            ReleaseDate = new DateTime(2021, 3, 26),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">I had a very eventful month. Some significant changes are ahead, always in pursuit of my ultimate goal: Getting into the tech industry.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Applying for Jobs</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Two days ago I started sending CVs. It feels good. I know it’s unlikely I’ll get a job soon but just the process of getting started already accomplished a few things.</p>\n\n\n\n<p class=\"wp-block-paragraph\">First it made me look at my CV and my portfolio. Even though I feel confident in my capacity of learning and helping my future employer, I don’t have much to show. I have many scattered projects on my GitHub account but not many finished, portfolio ready applications. I’ll be fixing that in the next few days, showcasing my skills in Angular and Asp.net C#, the stuff I know the most.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I’ll keep a count of the number of jobs I apply for. It will be an interesting number to show other folks who are in the same journey as me. I expect it will be hundreds before I even get an interview so I better move my butt. 😬</p>\n\n\n\n<p class=\"wp-block-paragraph\">So far the count is three applications with zero replies.  All of them for positions in Sunshine Coast. I&#8217;ll expand that to Brisbane </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Painful Week</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">For a week in February I suffered with very painful haemorrhoids. In the first couple of days, before accepting my girlfriend’s suggestion to take Ibuprofen, I couldn’t do anything. The pain was too much, in any position, at any time of the day. It went from mild symptoms on a Sunday night to excruciating pain on Tuesday morning.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I was panicking. All I wanted was the pain to go away. After taking the miraculous pills I had some relief but I was on Ibuprofen non-stop for five days before the condition reached its peak and started to subside. </p>\n\n\n\n<p class=\"wp-block-paragraph\">I don’t have constipation, I eat well, I drink a bunch of water. So I don’t know what happened. Haemorrhoids run in the family but I haven’t had problems with it for at least 15 years. </p>\n\n\n\n<p class=\"wp-block-paragraph\">So what have I learned? Well. The first take is&#8230; life is fragile, such as well-being. In a couple of days my priorities shifted from the daily preoccupations of healthy people to just being able to walk and sit painlessly. </p>\n\n\n\n<p class=\"wp-block-paragraph\">The second&#8230;. chia seeds. It&#8217;s super rich in fiber and although I didn’t have much problem pooping before, it improved my bowel movement significantly. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><em>Ok&#8230; back to work&#8230; I&#8217;ve got some big news in my next post!</em></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31018,
            Title = "LEGACY: Cleaning My Schedule",
            Slug = "cleaning-my-schedule-2",
            Description = "The end of February will be time for me to clean up my schedule. Last Sunday I had a meeting with my boss in Brisbane in which I resigned from the company I’ve been with for the...",
            CardImgUrl = "legacy-cleaning-my-schedule-2.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2021/02/23/cleaning-my-schedule-2/",
            ReleaseDate = new DateTime(2021, 2, 23),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\" id=\"block-55ad1a00-6468-446e-a928-a77fa19e8db6\">The end of February will be time for me to clean up my schedule. Last Sunday I had a meeting with my boss in Brisbane in which I resigned from the company I’ve been with for the past 5 years. I still had some doubts on my way there but the commute took two hours instead of the usual 1h30 due to a crash and my decision was made easier.&nbsp;</p>\n\n\n\n<p class=\"wp-block-paragraph\" id=\"block-816b16aa-ce43-4e6f-be54-63da68cffdf0\">I’ve also quit a mambo choreography in Brisbane that I was doing for professional development and fun but that meant 1h a week of rehearsals plus extra solo training and worrying. And that’s not to count other work projects I’ve been saying no to. It’s clean up time baby!</p>\n\n\n\n<p class=\"wp-block-paragraph\" id=\"block-8a96e5a8-c850-4209-af0a-aa6410571e94\">Now that I’m driving for a living, the last thing I want is to have to spend 4 hours on the road on a Sunday to get to a job I love doing but pays very close to what I’d make if I just did Uber up in Sunshine Coast. And that saves me a bunch of time.</p>\n\n\n\n<p class=\"wp-block-paragraph\" id=\"block-e8ec7b7c-1232-4062-b4e2-d22e6c0fb4ab\"><strong>My Goal</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\" id=\"block-349cdd15-a7d9-4090-b211-79f4202d980a\">Time is my most precious asset in my quest to get a developer job. Upon a lot of consideration, I’ve realised my sole goal in life right now has to be to one. Everything else I do in life has to support my efforts to reach that goal.</p>\n\n\n\n<p class=\"wp-block-paragraph\" id=\"block-2fd4b686-80b4-4548-a07d-2f9058ba676e\">Right now I’m making very good money in comparison to the rest of the world (A little more than minimum wage in Australia), but I’m doing work that is not only unreliable but also tends to disappear in the long run. Teaching dance can vanish overnight if Covid hits again. Regulation and driver’s migration can ruin Uber in the Sunshine Coast. So I can’t count on either of those to carry me on professionally through life.</p>\n\n\n\n<p class=\"wp-block-paragraph\" id=\"block-a53ac665-c1f5-491a-b859-37650594d431\">That leads to my goal. Every bone of my body has to work towards the ultimate end result: Getting a developer job. Another important step is figuring out what hours are more profitable doing Uber so I can do less hours to achieve the same financial result I set myself to achieve. Lunch and dinner hours, weekends, and some random “boost” hours are highly profitable. Right now I can code from 7-10 am every morning and still maintain the same pay from the other jobs, which is a true blessing.&nbsp;</p>\n\n\n\n<p class=\"wp-block-paragraph\" id=\"block-4773595d-8b4d-40d7-9ca7-ff40cf49c335\"><strong>WordPress</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\" id=\"block-f1e75309-5783-4833-8b10-cdab471b3f39\">I’ve decided to give it a go and apply for some junior WordPress positions I found for Brisbane. I have a small body work I can show in my portfolio and that won’t eat time from my priority, which is Angular + ASP.NET CRUD Applications. I’m in the middle of building a “shift tracker” for my girlfriend that is challenging me to learn a lot about the two. That will go straight into my portfolio, help my girlfriend and add to my skills.</p>\n\n\n\n<p class=\"wp-block-paragraph\" id=\"block-7dd447d4-f0db-47c6-9252-1882aceba002\">PS: I just broke a tooth as I was writing this and having dinner, which means I’ll probably have to work a bit more than I wished in the next couple of weeks, as I just started to build a savings cushion. Oh well. Time to soldier on!!</p>\n\n\n\n<p class=\"wp-block-paragraph\" id=\"block-78e1c42c-f289-418d-ba12-a0f960706be1\">PS2: I did 9h15&#8242; of coding last week. I&#8217;m back!!!</p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31019,
            Title = "LEGACY: Back to Coding!",
            Slug = "back-to-coding",
            Description = "In the past few days I’ve been slowly getting back into studying. I haven’t done any coding yet. Yeah, I know, there’s no use talking about coding, reading about it, thinking ab...",
            CardImgUrl = "legacy-back-to-coding.jpeg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2021/02/19/back-to-coding/",
            ReleaseDate = new DateTime(2021, 2, 19),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">In the past few days I’ve been slowly getting back into studying. I haven’t done any coding yet. Yeah, I know, there’s no use talking about coding, reading about it, thinking about it, if I’m not actually WRITING code. But I decided to invest my next few study hours into getting a certification. I decided to go for <a href=\"https://docs.microsoft.com/en-gb/learn/certifications/azure-data-fundamentals/\">Azure Data Fundamentals DP-900</a>. It seems easy enough not to break my balls but hard enough to challenge me and make me grow. </p>\n\n\n\n<p class=\"wp-block-paragraph\">Also now that I’m making a bit more money the fee is affordable so there are no more excuses not to have an official certification in my CV. I love the stuff I’m studying. I love working with data and databases. I have to go down that road. There isn’t a lot of hype around learning SQL or NoSQL but this stuff lies in the core of any application. Plus, have I said I love it? Sounds like a great idea to become a specialist in databases.&nbsp;</p>\n\n\n\n<p class=\"wp-block-paragraph\">Oh and I’m on track to reach the 7hs goal established in the last post. Go me!&nbsp;</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>New Mouse</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">My previous mouse, a concoction from J. Burrows, which I got from my boss during quarantine for work, was giving me a lot of grief. It’s a nightmare to have your flow disrupted by constant disconnections. I was literally disconnected every minute. To the point where I started using the frustration as a character building exercise. Anger management course 101. I’m very happy that in all these months I contained the throw it against the wall. Many times I imagined the pleasure I’d get from shattering it to pieces.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Hopefully those days are gone. I just got a <a href=\"https://www.logitech.com/en-au/products/mice/m350-pebble-wireless-mouse.910-005602.html\">Logitech Pebble M350</a>. I was aiming for something with a cord to avoid being hostage of any sort of technology subject to interference but it seems like cords are no longer a thing. Let’s hope I won’t be throwing mouses around anytime soon. </p>\n\n\n\n<figure class=\"wp-block-image size-large\"><img loading=\"lazy\" width=\"930\" height=\"523\" data-attachment-id=\"177\" data-permalink=\"https://cappuccinocodes.wordpress.com/logitech-pebble-m350/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/02/logitech-pebble-m350.jpg\" data-orig-size=\"930,523\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"logitech-pebble-m350\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/02/logitech-pebble-m350.jpg?w=723\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/02/logitech-pebble-m350.jpg?w=930\" alt=\"\" class=\"wp-image-177\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/02/logitech-pebble-m350.jpg 930w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/02/logitech-pebble-m350.jpg?w=150 150w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/02/logitech-pebble-m350.jpg?w=300 300w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/02/logitech-pebble-m350.jpg?w=768 768w\" sizes=\"auto, (max-width: 930px) 100vw, 930px\" /><figcaption>Logitech Pebble M350</figcaption></figure>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>New iPhone</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I don’t need a new phone. Mine serves the purpose. But inspired by <a href=\"https://www.amazon.com/Steve-Jobs-Walter-Isaacson/dp/1451648537\">Steve Jobs’ Biography</a> and my desire to keep my computer attachment (yes we’re cyborgs and phones are our computer extensions) up-to-date, I acquired the new iPhone. Don’t get me wrong, I didn’t buy it. Or at least not directly. I just increase my phone bill in 10$ and now I have a brand new<a href=\"https://www.apple.com/au/iphone-12-pro/?afid=p238%7CsezcgkXv1-dc_mtid_20925zaz40371_pcrid_479603910868_pgrid_112732242473_&amp;cid=wwa-au-kwgo-iphone--slid---product-----\"> iPhone 12 Pro Max</a>, whatever that is. I’m not a device fanatic but I’m willing to learn a bit more about them to share my experiences in this blog. I want to see how it will enhance my life: Driving an Uber, studying, communicating, tracking all of my data and whatever other uses I find for it. </p>\n\n\n\n<p class=\"wp-block-paragraph\">I always felt like I’ve underused my phones for sheer lack of curiosity to know what they’re capable of. I’ve only started using Siri a few months ago and it’s super useful when I’m driving an Uber. Let’s see what else I’ll learn about it in the next few days!</p>\n\n\n\n<p class=\"wp-block-paragraph\">Now shut up and back to work, Pablo!</p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31020,
            Title = "LEGACY: How to Find Time to Learn to Code",
            Slug = "how-to-find-time-to-learn-to-code",
            Description = "I’ve been doing Uber Eats for a couple of weeks now. The money is very good for someone that’s not well-established in a career in Australia and the work is easy. But to make en...",
            CardImgUrl = "legacy-how-to-find-time-to-learn-to-code.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2021/02/14/how-to-find-time-to-learn-to-code/",
            ReleaseDate = new DateTime(2021, 2, 14),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">I’ve been doing Uber Eats for a couple of weeks now. The money is very good for someone that’s not well-established in a career in Australia and the work is easy. But to make enough to pay the bills and save for University I have been doing pretty big shifts. When combined with my dance teaching classes at night, my total amount of weekly work hours skyrocketed: 63hs last week and 45 in the week ending today. I also have a girlfriend that I will lose if I don’t consistently dedicate time to her.&nbsp;</p>\n\n\n\n<p class=\"wp-block-paragraph\">And the challenge is presented: How to find enough hours to become a good enough programmer to get into the industry?. This is what I’ll find out this week. I won’t shoot for the stars just yet. I haven’t done any coding for 19 days now so I’ll ease back into it. I still need to work around 50hs this week and I definitely can’t code late at night. It requires a sharp morning brain for any meaningful work to get done. So I made a schedule that seems realistic: </p>\n\n\n\n<figure class=\"wp-block-image size-large\"><img loading=\"lazy\" width=\"1024\" height=\"713\" data-attachment-id=\"172\" data-permalink=\"https://cappuccinocodes.wordpress.com/2021/02/14/how-to-find-time-to-learn-to-code/screen-shot-2021-02-14-at-1-23-34-pm/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/02/screen-shot-2021-02-14-at-1.23.34-pm.png\" data-orig-size=\"1630,1136\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"Screen Shot 2021-02-14 at 1.23.34 pm\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/02/screen-shot-2021-02-14-at-1.23.34-pm.png?w=723\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/02/screen-shot-2021-02-14-at-1.23.34-pm.png?w=1024\" alt=\"\" class=\"wp-image-172\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/02/screen-shot-2021-02-14-at-1.23.34-pm.png?w=1024 1024w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/02/screen-shot-2021-02-14-at-1.23.34-pm.png?w=150 150w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/02/screen-shot-2021-02-14-at-1.23.34-pm.png?w=300 300w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/02/screen-shot-2021-02-14-at-1.23.34-pm.png?w=768 768w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/02/screen-shot-2021-02-14-at-1.23.34-pm.png?w=1440 1440w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/02/screen-shot-2021-02-14-at-1.23.34-pm.png 1630w\" sizes=\"auto, (max-width: 1024px) 100vw, 1024px\" /></figure>\n\n\n\n<p class=\"wp-block-paragraph\">I’m aiming for seven hours this week. This time will be divided between studying for my first <a href=\"https://docs.microsoft.com/en-us/learn/certifications/azure-fundamentals/\">Microsoft Certification</a>: I have enough money to pay for certification tests, so there are no more excuses. I have to go for it. So that’s it! Plain and simple. 7 hours of coding, no distractions, no bullshit.</p>\n\n\n\n<p class=\"wp-block-paragraph\">In the past month I’ve been reading <a href=\"https://www.amazon.com/Steve-Jobs-Walter-Isaacson/dp/1451648537\">Steve Job’s Biography by Walter Isaacson and </a>I want to implement a few principles I learned from his inspiring journey: </p>\n\n\n\n<p class=\"wp-block-paragraph\">. Simplicity: Keep things simple, from design, to UX, to goals, everything. I have to remember that when my mind starts telling me to do anything other than Angular.&nbsp;</p>\n\n\n\n<p class=\"wp-block-paragraph\">. Product, product, product: Basically the end goal of anyone in our industry should be to design amazing things for our users. It’s something so important that can serve as a compass for me at all times when making design choices.</p>\n\n\n\n<p class=\"wp-block-paragraph\">. High standards: Self-explanatory, but paying attention to the smallest detail, not compromising on anything in the pursuit of awesomeness.&nbsp;</p>\n\n\n\n<p class=\"wp-block-paragraph\">I’m excited! Ready to start tomorrow morning. Can’t wait to write code again.&nbsp;</p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31021,
            Title = "LEGACY: January",
            Slug = "january",
            Description = "It’s been more than a month!! I haven’t been posting, but my life has completely changed in these busy 4-5 weeks. So let’s get to it. I miss writing! The Beginning So my year st...",
            CardImgUrl = "legacy-january.png",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2021/01/29/january/",
            ReleaseDate = new DateTime(2021, 1, 29),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">It&#8217;s been more than a month!! I haven&#8217;t been posting, but my life has completely changed in these busy 4-5 weeks. So let&#8217;s get to it. I miss writing!</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>The Beginning</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">So my year started on the 28th of December. My weeks start on Monday so I couldn&#8217;t possibly start my year on Friday the 1st. I started tracking lot of activities, even water and food consumption, but I quickly let go of those early on. Happens almost every year. It&#8217;s easier to track those when we have the time. But when we&#8217;re busy rushing around it&#8217;s just not feasible.</p>\n\n\n\n<p class=\"wp-block-paragraph\">In terms of coding, I took a little step back from building in my first few days to take an object oriented programming course with Deborah Kurata at Pluralsight. What a fantastic course! Not only the contents are great and helped me to fill some gaps in my knowledge, but I also loved her teaching style. The explanations were crystal clear. Can&#8217;t recommend it enough for beginners.</p>\n\n\n\n<p class=\"wp-block-paragraph\">After that I went down a little rabbit hole. I wanted to create a super simple app to serve as a &#8220;first&#8221; in a &#8220;build your first c# app&#8221; in minutes kind of tutorial. I found out that the easiest way to achieve this without some complex scaffolding is with Razor Pages. It&#8217;s indeed easy to get it running with the intimately related c# class behind it. But to create anything minimally presentable I had to dive into Razor Pages tutorials and it turns out to be way more complex. </p>\n\n\n\n<p class=\"wp-block-paragraph\">I tried to create a little quiz that a beginner could show to their friends, something that I think it&#8217;s really important in someone&#8217;s learning path. But that involves having questions in a simple data service, then rendering the questions in a dropdown list, then validating the users answers against the correct answers in the database and then updating the page accordingly. The expectation of having it done quickly turned into a frustration. I didn&#8217;t want to be doing any of that. Every day I spent on it meant one less day spent in the thing I like the most: Angular. Essentialism, Pablo, don&#8217;t forget! But of course it&#8217;s easier said than done. Sunk cost fallacy is a powerful mental trap and it took me a few days to get rid of Razor.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Proper Computer Science</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">In the first few weeks I went down another little rabbit hole. I started watching a lecture at Berkeley University. SICP: Structure and Interpretation of Computer Programs. Again it started very well but I started going into a functional programming pathway that I understand is super important for a programmer to have and considering the following events that I&#8217;ll explain soon I didn&#8217;t have the time to continue. </p>\n\n\n\n<p class=\"wp-block-paragraph\">My idea is to go over some books from this super interesting article on <a href=\"https://teachyourselfcs.com/\">how to study computer science by yourself</a>: It&#8217;s an article that provides a lifetime of learning and the books are thick tomes with advanced computer science and mathematics. Of course my brain wants me to devour all of them. So I started it. I picked the functional programming course because it was recommended as a great foundation by many. </p>\n\n\n\n<p class=\"wp-block-paragraph\">The course is tightly coupled with the <a href=\"https://mitpress.mit.edu/sites/default/files/sicp/full-text/book/book.html\">book of the same name </a>and I started listening to the lectures and doing some of the exercises. Fascinating stuff. It was great to get in touch with heavy Maths again. I put the whole thing aside for a minute but I&#8217;m definitely getting back to it at some point.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>First Books</strong> </p>\n\n\n\n<p class=\"wp-block-paragraph\">My interest in diving deeper into computer science was fuelled in part by my first book of the year: <a href=\"https://www.amazon.com/Surely-Youre-Joking-Mr-Feynman-ebook/dp/B003V1WXKU\">&#8220;Surely You&#8217;re Joking Mr. Feynman&#8221;,</a> a fascinating read about one of the most important American professors of all time. He&#8217;s famous for having participated in the team that produced the atomic bomb. The book is a series of tales narrated by himself. Imagine taking a sneak peek into a brilliant scientist&#8217;s mind. That&#8217;s what it provides. The anecdotes aren&#8217;t only about science, but range from his school days, nerdy advice to approach women and interesting takes in many aspects of life.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Then I jumped into <a href=\"https://www.amazon.com/Open-Autobiography-Andre-Agassi/dp/0307388409\">Andre Agassi&#8217;s &#8220;Open&#8221;</a>. Also narrated by himself, it&#8217;s impossible not to get fired up and motivated during this read. I&#8217;m not a tennis aficionado, but have watched my fair share of games, specially during my betting years, and learned to appreciate the nature of the game. His accounts of his early years are unforgettable. He says he hates tennis because of how much his dad made him practice. &#8220;If you hit a million balls a year you&#8217;ll be the best in the world&#8221;, his dad would say. The man built a tennis court and a ball-spitting machine in his court yard with his bare hands. What&#8217;s my excuse? It&#8217;s particularly impressive to have a couple of behemoths like Djokovic, Nadal, Federer, Agassi, Becker, Sampras at the top for so many years in a such a competitive sport. These people have to be studied. </p>\n\n\n\n<p class=\"wp-block-paragraph\">Right now I&#8217;m reading (listening) to Steve Job&#8217;s biography. Endlessly fascinating but I&#8217;ll talk about it when it&#8217;s over. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>End Then Everything Changed</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">It&#8217;s interesting where life takes us and how it does it. A little more than two weeks ago my landlord said she wanted me to leave. She has helped me in the last 6 months undercharging me and I&#8217;m super appreciative of it but she wanted to make proper money out of her spare room and I totally understood her request. </p>\n\n\n\n<p class=\"wp-block-paragraph\">So I started searching for a place and stumbled across a room online and went to see it. It was above what I had initially wanted to pay but why not have a look. It&#8217;s a great room in a big house in a complex in Mooloolaba, Sunshine Coast. At first the house looked messy because there are renovations going on and the owner is clearly not a minimalist. Too many objects. But who cares? The room seemed cosy, there&#8217;s a nice swimming pool in the complex. So why not? It seems right now it was a fantastic decision, even though it&#8217;s very expensive. First because I hate decision fatigue. I could have spent weeks in inspections trying to find the right place but I&#8217;m not into that. So I just said in 10 minutes: Where do I sign?</p>\n\n\n\n<p class=\"wp-block-paragraph\">Well it turns out one of my housemates is an Uber Eats driver and when I moved in we started talking about it. I decided to give it a try and applied for an account and after sending all the documents I was approved within six days. I started driving on the next day and after three days I made an average of 100$ a day (approx. 21$/h) . Plus it&#8217;s fun!! I get to see the city, see what people&#8217;s lives and homes are like, I can drive while listening to great music and podcasts/audio books in the aircon, seeing beautiful landscapes and architecture and don&#8217;t even have to deal with shitty people!!</p>\n\n\n\n<p class=\"wp-block-paragraph\">It&#8217;s definitely not a fantastic pay but considering my current circumstance it&#8217;s absolutely perfect. It&#8217;s flexible work. I can work at any hours from 7am to 12am (and in weekends probably even during the night), which means I can keep teaching. Also, I&#8217;ll post later about my plan of going into a Computer Science course, which means I&#8217;ll need some serious cash. And driving an Uber provides the money just at the right time. I won&#8217;t go crazy driving 12hs a day but I can even do that If needed. I think the max I could make a day would be 300$ in a 12h shift. Not bad at all. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Plans</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">So that&#8217;s where I stand right now. New place in a new city, new job, enough money coming in to make plans. My coding time has been affected by the lack of a consistent routine (I&#8217;ll publish all my carefully tracked times in the next few posts), but I feel like January was about building the foundations. In February I&#8217;ll be able to have a routine that I&#8217;m used to. When moving homes, even knowing where things are is hard, which affects the flow of things. </p>\n\n\n\n<p class=\"wp-block-paragraph\">So my goals for February: To make 100$ a day with Uber; To finalise my current coding project; To apply for University studies.</p>\n\n\n\n<p class=\"wp-block-paragraph\">From what I researched I&#8217;ll have to do an english + maths bridging course at the University of Sunshine Coast before getting into actual Uni but I&#8217;m extremely motivated regardless. I&#8217;ve never been so well-equiped for studying and I want to smash it when I&#8217;m back to it. </p>\n\n\n\n<p class=\"wp-block-paragraph\">What a big post! </p>\n\n\n\n<p class=\"wp-block-paragraph\">Back soon, I hope. </p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31022,
            Title = "LEGACY: The Art of Computer Programming",
            Slug = "the-art-of-computer-programming",
            Description = "I’m writing at 530pm on Saturday and I’m only 30 hours away from the new year. The new year for me starts on the first day of the week, which this time means Monday, December th...",
            CardImgUrl = "legacy-the-art-of-computer-programming.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/12/26/the-art-of-computer-programming/",
            ReleaseDate = new DateTime(2020, 12, 26),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">I’m writing at 530pm on Saturday and I’m only 30 hours away from the new year. The new year for me starts on the first day of the week, which this time means Monday, December the 28th.&nbsp;</p>\n\n\n\n<p class=\"wp-block-paragraph\">It was a productive day, testing the systems I plan to use in the new year and with some advance in coding, both on the building and on the studying sides. I’ve also made progress in the “life admin” department, getting a Costco card, for cheaper petrol and wholesale products and a Fly Buys card, the affiliate system used by Coles and Kmart in Australia. I use those two stores a lot, so it’s a good idea to accumulate points that can be later exchanged.</p>\n\n\n\n<div class=\"wp-block-image\"><figure class=\"aligncenter size-large is-resized\"><img loading=\"lazy\" data-attachment-id=\"152\" data-permalink=\"https://cappuccinocodes.wordpress.com/12771637461022/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/12771637461022.jpg\" data-orig-size=\"740,740\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;1&quot;}\" data-image-title=\"12771637461022\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/12771637461022.jpg?w=723\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/12771637461022.jpg?w=740\" alt=\"\" class=\"wp-image-152\" width=\"310\" height=\"310\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/12771637461022.jpg?w=310 310w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/12771637461022.jpg?w=620 620w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/12771637461022.jpg?w=150 150w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/12771637461022.jpg?w=300 300w\" sizes=\"auto, (max-width: 310px) 100vw, 310px\" /></figure></div>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>The Book</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I’ve started studying my new book , “<a href=\"https://www.amazon.com/Computer-Programming-Volumes-1-4A-Boxed/dp/0321751043/ref=cm_cr_arp_d_product_top?ie=UTF8\">The Art of Computer Programming</a>”, today. The first chapter is about the fundamentals of algorithms, with explanations going all the way back to the first mathematicians. Fantastic stuff to read.&nbsp;</p>\n\n\n\n<p class=\"wp-block-paragraph\">Very early on I stumbled upon the first evidence of my mathematical ineptitude. I couldn’t figure out how the remainder of 119/544 was 119 and I was almost writing a question about it on stackexchange/maths when I decided to do my due diligence better and search it properly. Of course it was easy to find. I presume there are infinite resources for mathematics online and I’ll be using those a lot. It’s a super dense book, but as I said yesterday, I’ve got to come out of it smarter, and better at programming.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I’m using “mind mapping” for better study and retention of the book. I’ll be discussing this subject intensely in this blog. I’ve been delving into mnemonics and can’t wait to apply my new learnings in my studies.&nbsp;</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Ionic </strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I’ve also gained ground in my Ionic App. So many cool components! I’m almost finishing the front-end and can’t wait to jump into the user input and dealing with data, always my favourite part in any app.</p>\n\n\n\n<div class=\"wp-block-image\"><figure class=\"aligncenter size-large is-resized\"><img loading=\"lazy\" data-attachment-id=\"154\" data-permalink=\"https://cappuccinocodes.wordpress.com/screen-shot-2020-12-26-at-5-54-57-pm/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-26-at-5.54.57-pm.png\" data-orig-size=\"366,802\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"screen-shot-2020-12-26-at-5.54.57-pm\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-26-at-5.54.57-pm.png?w=366\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-26-at-5.54.57-pm.png?w=366\" alt=\"\" class=\"wp-image-154\" width=\"182\" height=\"399\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-26-at-5.54.57-pm.png?w=182 182w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-26-at-5.54.57-pm.png?w=364 364w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-26-at-5.54.57-pm.png?w=68 68w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-26-at-5.54.57-pm.png?w=137 137w\" sizes=\"auto, (max-width: 182px) 100vw, 182px\" /></figure></div>\n\n\n\n<p class=\"wp-block-paragraph\">Two more sleeps and the new year is here for me!!&nbsp;</p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31023,
            Title = "LEGACY: 2021 Prep",
            Slug = "2021-prep",
            Description = "The new year starts on Monday for me. My mind operates on a weekly basis and given that my week starts on Mondays, I can’t start my Week 1 on Friday the 1st of January. That wou...",
            CardImgUrl = "legacy-2021-prep.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/12/25/2021-prep/",
            ReleaseDate = new DateTime(2020, 12, 25),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">The new year starts on Monday for me. My mind operates on a weekly basis and given that my week starts on Mondays, I can’t start my Week 1 on Friday the 1st of January. That would mess with my slightly OCD way of tracking goals, habits and budget and it wouldn’t be a good way to start the year.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Prepping</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I fought off a two-hour period when I just wanted to do nothing and wait for Monday to come, but luckily I’ve decided to treat the next three days (I’m writing on Friday at 830pm) as a “Week 0” period. In these final three days I’ll have an exceptional amount of free time for a weekend, so I’ll use it to prepare my systems for 2021.&nbsp;</p>\n\n\n\n<p class=\"wp-block-paragraph\">I’m going to try to track my time again in the new year, but If I can’t that’s fine. I can’t expect to track every hour of 365 days. But I’d like to track some activities consistently: Coding, Sleeping, Gym, Work, Social Life. I won’t care so much about maintenance activities: Food, admin, organising, cleaning, hygiene, prepping, commuting. I will still try to track those but if I ultimately can’t, that’s fine.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I consider myself an Essentialist, so I will have coding as my absolute priority. Everything else has to gravitate towards that. I’ve organised my days so I can avoid any activities before 1230. It will be purely dedicated to code. I will have a daily session of dance training with my dance partner during weekdays at 1pm. The reason being, I can’t deny the role dance plays in my life and I’d like to be the best I can at it. I think there’s room for growth if we’re organised about it. If I’m doing something, I might as well do it well. Also, dance is still my bread and butter, so it still competes with coding as a priority. Dance will ultimately be the means to achieve my coding goals.&nbsp;</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Quality</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">One of the things I want to pursue&nbsp; in 2021 is quality. I don’t want to do anything thoughtlessly, just going with the flow. I’ve been good at it in 2020, but there’s a lot of room for improvement. Here are some situations where I find myself in a sub-optimal (to say the least) quality state. It happens more often in the second part of the day, particularly if I didn’t have a nap. I have to fight for my afternoon nap to avoid being too tired. The more tired, the less will power I have to behave optimally.</p>\n\n\n\n<p class=\"wp-block-paragraph\">The same relates to food. I’ve grown accustomed to eating the lowest possible quality of food, with the minimal amount of preparation, but a couple of friends have recently opened my eyes (mouth) to what I’ve been missing. Following the same rationale as before, If I have to eat around five times a day, I might as well eat good stuff. I won’t treat this as a priority, but I definitely want to get better at cooking in 2021.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>On Eating Mindfully</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I’m still not prepared to let myself eat mindfully. I need to watch something when I’m eating. I’ve recently found a couple of very good Youtube Channels about technology that are very stimulating and I’ll probably dive into those. The last thing I want to do is sit to eat and brainlessly scroll social media.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Systems</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">All of the above relates to “winning the day”. I love this idea. It’s about treating each life unit (aka day) as a little battle that can be won or lost. And winning most days relies on solid systems. There are things I’ll be doing consistently throughout the year and having systems for each of them will increase the likelihood of winning the day and hence achieving the ultimate goals: Get a computer science job, which leads to the ultimate of the ultimate goals: happiness.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Tracking My Coding Time</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Something I realised I have to start doing is tracking my coding time. There are many sub-activities that can be done related to coding and I think it will be beneficial to have them timed so I can see where it’s going. The bulk of my time still needs to go to <strong>Building.</strong> If I don’t build I feel I have little impact in the world, so it has to be a priority. However the quality of what I build relies on the depth of my knowledge. A web developer spends a tiny fraction of work time with algorithms. At least that’s the case for me, maybe because I’m learning.&nbsp;</p>\n\n\n\n<p class=\"wp-block-paragraph\">So what I’ll do to mitigate that lack of algorithm-producing time is work on coding challenges and exercises, and on a deeper level, dive into pure mathematics and computer logic. Anyone can write code these days, but Mathematics is still a challenge for many, so it will be another way to stand out.</p>\n\n\n\n<p class=\"wp-block-paragraph\">For that, today I’ve started to study the very intimidating “<a href=\"https://www.amazon.com/Computer-Programming-Volumes-1-4A-Boxed/dp/0321751043/ref=cm_cr_arp_d_product_top?ie=UTF8\">The Art of Computer Programming</a>”, by Donald E. Knuth. Hardcore math applied to computer science. I’ve never read anything like it back to back but there’s no way I’ll come out of it worse than I started. But this post is getting massive, so I’ll write more about the book on my next blog.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Back to work!!</p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31024,
            Title = "LEGACY: Five-Day Break",
            Slug = "five-day-break",
            Description = "I had a big break from Wednesday to Sunday last week. I don’t think I had such a long time without any coding since I’ve started last year. It was a great opportunity to recharg...",
            CardImgUrl = "legacy-five-day-break.png",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/12/22/five-day-break/",
            ReleaseDate = new DateTime(2020, 12, 22),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">I had a big break from Wednesday to Sunday last week. I don&#8217;t think I had such a long time without any coding since I&#8217;ve started last year. It was a great opportunity to recharge my programming batteries. </p>\n\n\n\n<p class=\"wp-block-paragraph\">I didn&#8217;t miss it that much because I felt accomplished. Looking back, my journey so far has been a lot of fun, I&#8217;ve learned a lot and created a bunch of stuff. I&#8217;m proud of myself. I think I&#8217;ve paved my way to grow immensely in 2021. I&#8217;m confident I&#8217;ll get a job in the year to come. The foundations have been laid out. </p>\n\n\n\n<div class=\"wp-block-image\"><figure class=\"aligncenter size-large is-resized\"><img data-attachment-id=\"141\" data-permalink=\"https://cappuccinocodes.wordpress.com/coffs-harbour-lawyers-with-barristers/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/coffs-harbour-lawyers-with-barristers.jpg\" data-orig-size=\"640,480\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;9&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;NEX-5T&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;1409829024&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;33&quot;,&quot;iso&quot;:&quot;100&quot;,&quot;shutter_speed&quot;:&quot;0.005&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;1&quot;}\" data-image-title=\"coffs-harbour-lawyers-with-barristers\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/coffs-harbour-lawyers-with-barristers.jpg?w=640\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/coffs-harbour-lawyers-with-barristers.jpg?w=640\" alt=\"\" class=\"wp-image-141\" width=\"-72\" height=\"-54\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/coffs-harbour-lawyers-with-barristers.jpg 640w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/coffs-harbour-lawyers-with-barristers.jpg?w=150 150w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/coffs-harbour-lawyers-with-barristers.jpg?w=300 300w\" sizes=\"(max-width: 640px) 100vw, 640px\" /><figcaption>Coffs Harbour, NSW</figcaption></figure></div>\n\n\n\n<p class=\"wp-block-paragraph\">Of course recharging was a consequence of a work trip. I went down to Coffs Harbour, in the North of New South Wales, to teach Salsa, Bachata and Zouk. It&#8217;s a cosy, charming town and I&#8217;ve met wonderful people who have a lot of passion for dance. I woke up on the return day with the news I needed a pass to get back to Brisbane and I even started looking for accomodation in Tweed Heads, just South of the border. Thankfully there were no hard borders and I managed to get back.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Back to Work</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Of course taking a break is great but getting back to work is even better. So far I pulled off a couple of four-hour days, not without some struggle. It&#8217;s taking me a while to get back into coding shape. </p>\n\n\n\n<div class=\"wp-block-image\"><figure class=\"aligncenter size-large is-resized\"><img loading=\"lazy\" data-attachment-id=\"139\" data-permalink=\"https://cappuccinocodes.wordpress.com/screen-shot-2020-12-22-at-5-07-20-pm/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-22-at-5.07.20-pm.png\" data-orig-size=\"652,982\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"screen-shot-2020-12-22-at-5.07.20-pm\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-22-at-5.07.20-pm.png?w=652\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-22-at-5.07.20-pm.png?w=652\" alt=\"\" class=\"wp-image-139\" width=\"349\" height=\"526\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-22-at-5.07.20-pm.png?w=349 349w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-22-at-5.07.20-pm.png?w=100 100w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-22-at-5.07.20-pm.png?w=199 199w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-22-at-5.07.20-pm.png 652w\" sizes=\"auto, (max-width: 349px) 100vw, 349px\" /><figcaption>Ionic App</figcaption></figure></div>\n\n\n\n<p class=\"wp-block-paragraph\">Now that I have the bulk of my portfolio out of my way, I&#8217;m working on my first intermediate level Ionic App. It&#8217;s an Airbnb style app created in an Udemy Course and it will serve the double purpose of learning more advanced concepts in Ionic and it will look great in my CV. </p>\n\n\n\n<p class=\"wp-block-paragraph\">I have tons of ideas popping-up in my mind, but I won&#8217;t start any of them until I finish this one. Having had a fair bit of experience in Angular is making me cruise through this tutorial but I expect things to get more challenging, let&#8217;s see! I&#8217;m aiming to finish it by the end of the year so I can polish my portfolio to start looking for a job. I don&#8217;t think it will hurt to start applying for jobs from January.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Now back to work!</p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31025,
            Title = "LEGACY: I Have a Portfolio!",
            Slug = "i-have-a-portfolio",
            Description = "In the last few days I’ve only worked on my Portfolio. I have a work trip for four days and there will be little time for coding, so it was great to get the portfolio out there...",
            CardImgUrl = "legacy-i-have-a-portfolio.png",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/12/17/i-have-a-portfolio/",
            ReleaseDate = new DateTime(2020, 12, 17),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">In the last few days I’ve only worked on my Portfolio. I have a work trip for four days and there will be little time for coding, so it was great to get the portfolio out there with at least a half-decent design.&nbsp; That means that in my trip the thought of something incomplete won’t be buggering me in the back of my mind.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I decided to create the portfolio on WordPress just to get it done quickly, but I do plan to have a coded website once I have more projects displayed in it. Plus I have to admit I love working with Elementor and I’ll probably have many side projects using this amazing tool in 2021. But yeah, it’s not great for a self-proclaimed full stack developer not to have a coded portfolio. </p>\n\n\n\n<figure class=\"wp-block-image size-large\"><img loading=\"lazy\" width=\"900\" height=\"432\" data-attachment-id=\"128\" data-permalink=\"https://cappuccinocodes.wordpress.com/2020/12/17/i-have-a-portfolio/screen-shot-2020-12-17-at-7-02-22-am/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-17-at-7.02.22-am.png\" data-orig-size=\"900,432\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"Screen Shot 2020-12-17 at 7.02.22 am\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-17-at-7.02.22-am.png?w=723\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-17-at-7.02.22-am.png?w=900\" alt=\"\" class=\"wp-image-128\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-17-at-7.02.22-am.png 900w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-17-at-7.02.22-am.png?w=150 150w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-17-at-7.02.22-am.png?w=300 300w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-17-at-7.02.22-am.png?w=768 768w\" sizes=\"auto, (max-width: 900px) 100vw, 900px\" /><figcaption>Portfolio&#8217;s Banner</figcaption></figure>\n\n\n\n<p class=\"wp-block-paragraph\">I started the portfolio with just three projects but I already have a few more under my belt to display. I’ll keep enhancing it in the next few days and on Monday I’ll create a thread on Reddit with the following title: “Please tear my portfolio apart”. It will be interesting to put myself out there and I know the criticism will be harsh, but it will be great to have a reality check.</p>\n\n\n\n<p class=\"wp-block-paragraph\">But I miss coding!! All this work in WordPress means I haven’t written many lines of code (except for a bit of CSS), and I miss it so much! That reassures me about being In the right career pursuit.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Getting Organised</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Freedom!!! Finally!</p>\n\n\n\n<p class=\"wp-block-paragraph\">Exactly six months after getting my Australian visa I got my Australian Open Driver’s License. I can barely convey the feeling of driving again after 20 months of being back into the public transportation system.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I don’t think Queensland has a bad transportation system. It’s pretty reliable. I’m sure it depends on where you are comparing it with but I don’t have many complaints. And I could always study on the train and work on the bus. It was fun, unforgettable times. But the comfort and flexibility a car provides are just immense.</p>\n\n\n\n<p class=\"wp-block-paragraph\">It’s already impacting everything in my life. I can eat better because it’s easier to plan and stock the foods I need. My fitness will improve because I don’t dread the walk to the gym when I’m tired and my social life will skyrocket because I can easily get anywhere in my schedule gaps for a coffee catch up.&nbsp;</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Putting Systems in Place</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I’ve always known the importance of preparation, but in the past few years the idea of preparing ahead as a general principle has gained space in my life. Jocko Willink talks about it all the time in his podcast and recently two guests on Tim Ferriss’ podcast sealed the deal for me: Matthew McConaughey, talking about why he’s always relaxed in the set &#8211; “That’s because I’m a preparer”, and specially Steven Rinella, a specialist in wilderness exploration and survival skills.&nbsp;</p>\n\n\n\n<p class=\"wp-block-paragraph\">It’s funny that I don’t have any interest in being in the wilderness and exposing myself to all sorts of danger. I mean, I have to admit it’s fun, but I don’t like the trade-off between fun and death so yeah, I’ll be in cities for the rest of my life. So I didn’t think a podcast would have such an impact. But the way he talks about his preparation, and the mindset that you need to put the thinking and the effort into putting systems in place so “you don’t need survival skills”, are just fascinating. According to him, he’s not a survival specialist, but a specialist in avoiding survival situations. Because if you’re trying to survive, the systems you put (or didn’t put) in place failed.</p>\n\n\n\n<figure class=\"wp-block-image size-large\"><img loading=\"lazy\" width=\"1024\" height=\"682\" data-attachment-id=\"129\" data-permalink=\"https://cappuccinocodes.wordpress.com/rinellastevenrinella_2_e1550324322743-0/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/rinellastevenrinella_2_e1550324322743.0.jpg\" data-orig-size=\"1200,800\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"rinellastevenrinella_2_e1550324322743.0\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/rinellastevenrinella_2_e1550324322743.0.jpg?w=723\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/rinellastevenrinella_2_e1550324322743.0.jpg?w=1024\" alt=\"\" class=\"wp-image-129\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/rinellastevenrinella_2_e1550324322743.0.jpg?w=1024 1024w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/rinellastevenrinella_2_e1550324322743.0.jpg?w=150 150w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/rinellastevenrinella_2_e1550324322743.0.jpg?w=300 300w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/rinellastevenrinella_2_e1550324322743.0.jpg?w=768 768w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/rinellastevenrinella_2_e1550324322743.0.jpg 1200w\" sizes=\"auto, (max-width: 1024px) 100vw, 1024px\" /><figcaption>Steve Rinella</figcaption></figure>\n\n\n\n<p class=\"wp-block-paragraph\">So now that I have a car I’m trying to implement those ideas. I’ve had many problems with cars before so I’ll try to avoid them by thinking ahead. I just got comprehensive insurance, which gives me a bit of tranquility for my road trip, but I still don’t have Roadside Assistance and a good spare tyre. Unfortunately December has been a bad month financially so I’ll have to keep working on my systems in January.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Some of the things I plan to do to avoid catastrophes:&nbsp;</p>\n\n\n\n<ul class=\"wp-block-list\"><li>Having a couple of sets of spare keys distributed in strategic locations</li><li>Having a tracker attached to my important objects</li><li>Having money in my savings account (there’s none now 🤣) and having a contingencies account so I don’t need to touch it.&nbsp;</li><li>Having a bag with clean clothes ready to go in both my work places and in my car</li></ul>\n\n\n\n<p class=\"wp-block-paragraph\">Recently I’ve implemented Apple Pay, connecting my Mastercard to my phone and it’s already paid off when I forgot my wallet and had to pay for something in the shopping centre. Very handy little piece of technology!!</p>\n\n\n\n<p class=\"wp-block-paragraph\">Ok, that’s it for now, back to work!!</p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31026,
            Title = "LEGACY: Apple Developer Program",
            Slug = "apple-developer-program",
            Description = "This week I’ve been working with two main goals. The first is to develop a landing page on WordPress for a friend. She’s running workshops and wants a simple page for her client...",
            CardImgUrl = "legacy-apple-developer-program.png",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/12/10/apple-developer-program/",
            ReleaseDate = new DateTime(2020, 12, 10),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">This week I’ve been working with two main goals. The first is to develop a landing page on WordPress for a friend. She’s running workshops and wants a simple page for her clients to understand what she wants and purchase a pass. As much as I don’t love working with front-end, this project serves a few purposes. First, to help a friend that helped me enormously in my Australian journey. Second, it’s yet another project I can include on my Portfolio, and last but not least, it forces me to think of pure design, front-end developing and UX/UI. I’ve been spending most of my hours working with back-end stuff so this project helps me become a more well-rounded developer.</p>\n\n\n\n<figure class=\"wp-block-image size-large\"><img loading=\"lazy\" width=\"1024\" height=\"767\" data-attachment-id=\"118\" data-permalink=\"https://cappuccinocodes.wordpress.com/2020/12/10/apple-developer-program/screen-shot-2020-12-10-at-11-59-01-am/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-10-at-11.59.01-am.png\" data-orig-size=\"1774,1330\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"Screen Shot 2020-12-10 at 11.59.01 am\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-10-at-11.59.01-am.png?w=723\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-10-at-11.59.01-am.png?w=1024\" alt=\"\" class=\"wp-image-118\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-10-at-11.59.01-am.png?w=1024 1024w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-10-at-11.59.01-am.png?w=150 150w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-10-at-11.59.01-am.png?w=300 300w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-10-at-11.59.01-am.png?w=768 768w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-10-at-11.59.01-am.png?w=1440 1440w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-10-at-11.59.01-am.png 1774w\" sizes=\"auto, (max-width: 1024px) 100vw, 1024px\" /></figure>\n\n\n\n<p class=\"wp-block-paragraph\">And to be honest, I really like working with WordPress and Elementor. Elementor makes it easy for anyone to create a fancy website without any coding. The learning curve isn’t steep at all and there are plenty of good tutorials out there. It’s such a good tool that it makes me want to branch out that way, but then again ANYONE can create a good front-end with these tools so I think the profits in this area will be increasingly diluted. But I’ll probably use it to create the first version of my portfolio, as I plan to get it out in the world before Xmas. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>iOS Development</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">The second goal is to create a small app with real life importance for my salsa students. Basically it’s a small gallery of salsa moves with the name, description and a small video. It’s a very simple app and I created a prototype in less than 48hs first starting with Ionic. The next stage is to release it to a few people and get them to download and use it on Android and iPhone devices. I’ll use the “Ad-Hoc” deployment, which allows me to distribute it to a hundred users.</p>\n\n\n\n<figure class=\"wp-block-image size-large\"><img loading=\"lazy\" width=\"1024\" height=\"423\" data-attachment-id=\"116\" data-permalink=\"https://cappuccinocodes.wordpress.com/2020/12/10/apple-developer-program/screen-shot-2020-12-10-at-11-57-55-am/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-10-at-11.57.55-am.png\" data-orig-size=\"2372,982\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"Screen Shot 2020-12-10 at 11.57.55 am\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-10-at-11.57.55-am.png?w=723\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-10-at-11.57.55-am.png?w=1024\" alt=\"\" class=\"wp-image-116\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-10-at-11.57.55-am.png?w=1024 1024w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-10-at-11.57.55-am.png?w=2048 2048w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-10-at-11.57.55-am.png?w=150 150w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-10-at-11.57.55-am.png?w=300 300w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-10-at-11.57.55-am.png?w=768 768w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-10-at-11.57.55-am.png?w=1440 1440w\" sizes=\"auto, (max-width: 1024px) 100vw, 1024px\" /></figure>\n\n\n\n<p class=\"wp-block-paragraph\">For that I had to enrol in Apple Developer Program for 150AUD, which is a fortune right now but it’s totally worth it. As I said in my last blog, I think branching into app development is a good idea and I should do it before it becomes as easy to create an app as it is to create a website right now.</p>\n\n\n\n<p class=\"wp-block-paragraph\">So that is it for now!! Back to coding! There’s a ton of stuff to be done before the year ends. </p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31027,
            Title = "LEGACY: Building Mobile Apps!",
            Slug = "building-mobile-apps",
            Description = "After writing my last post I started an tutorial on Ionic. I can’t quite remember what dragged me into it but after doing a quick Youtube research I jumped into Udemy and found...",
            CardImgUrl = "legacy-building-mobile-apps.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/12/07/building-mobile-apps/",
            ReleaseDate = new DateTime(2020, 12, 7),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">After writing my last post I started an tutorial on Ionic. I can’t quite remember what dragged me into it but after doing a quick Youtube research I jumped into Udemy and found out my favourite teacher (Max Such) had a tutorial!! His teaching style suits my needs so I decided to purchase the course. It was a great 12$ investment. </p>\n\n\n\n<p class=\"wp-block-paragraph\">Coming from an Angular background it took me only one day to put together my first app, a tiny, simple, straightforward recipes application running on an emulator. I have to buy a cable to run it on my phone and that will have to wait due to budget constraints. But definitely by January I’ll have my first app running on iOS and Android. If I thought Angular was fun, Ionic is even more!!!</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Differential</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Focusing on apps is a tiny course correction that goes a long way for two reasons. First, the code base is almost identical to running web apps, so one skill won’t prevent me from getting better in the other. Second, these days anyone can build a website, but only developers can build apps. If I can build decent apps I can start approaching businesses straight away, the way website developers would do ten years ago when it wasn’t so easy to build a website. </p>\n\n\n\n<p class=\"wp-block-paragraph\">Having said that, I’m pretty sure in a couple of years there will be an equivalent to WordPress for building apps, so any child will be able to make an app. There might even be something like that already, but I’m writing this blog post without doing any research on the subject.</p>\n\n\n\n<div class=\"wp-block-image\"><figure class=\"aligncenter size-large\"><img loading=\"lazy\" width=\"650\" height=\"433\" data-attachment-id=\"111\" data-permalink=\"https://cappuccinocodes.wordpress.com/2020/12/07/building-mobile-apps/1800ss_thinkstock_rf_man_napping_on_bench/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/1800ss_thinkstock_rf_man_napping_on_bench.jpg\" data-orig-size=\"650,433\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"1800ss_thinkstock_rf_man_napping_on_bench\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/1800ss_thinkstock_rf_man_napping_on_bench.jpg?w=650\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/1800ss_thinkstock_rf_man_napping_on_bench.jpg?w=650\" alt=\"\" class=\"wp-image-111\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/1800ss_thinkstock_rf_man_napping_on_bench.jpg 650w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/1800ss_thinkstock_rf_man_napping_on_bench.jpg?w=150 150w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/1800ss_thinkstock_rf_man_napping_on_bench.jpg?w=300 300w\" sizes=\"auto, (max-width: 650px) 100vw, 650px\" /></figure></div>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Strategies For Life</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I love discussing hacks and strategies for life and if there’s one thing that I have recently implemented and that improved my life a lot is napping in the middle of the day. I’ve napped before and even had consistent spells but for the first time I’m taking it as an absolute necessity in life management. It’s simple. If I nap, the second half of my day is way more pleasant and productive than If I don’t. </p>\n\n\n\n<p class=\"wp-block-paragraph\">If I skip napping for whatever reason, by 4 or 5 PM I’m already yawning and struggling to focus. I absolutely hate feeling tired. That’s not to mention the struggle that it is to stay awake later at night. Yesterday I didn’t have time to nap and at night I was catching up with a friend and I was so tired I was almost falling asleep mid-conversation. What a horrible feeling. </p>\n\n\n\n<p class=\"wp-block-paragraph\">The good thing is that I’ve developed the ability to nap anywhere, even in a light room. All I have to do is find time to lay down and cover my eyes with some cloth or a shirt and I’ll fall asleep. And it doesn’t have to be long either. I’ve had five minutes naps that already recharged me. But if the room is really quiet and dark, a thirty minute nap will energise me until it’s time to sleep. </p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31028,
            Title = "LEGACY: Avalanche of Ideas",
            Slug = "avalanche-of-ideas",
            Description = "Since starting Cappuccino Codes my coding journey improved ten-fold. I wish I had this clarity from the beginning and I’ll make sure to use what I learned from my mistakes and t...",
            CardImgUrl = "legacy-avalanche-of-ideas.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/12/03/avalanche-of-ideas/",
            ReleaseDate = new DateTime(2020, 12, 3),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">Since starting Cappuccino Codes my coding journey improved ten-fold. I wish I had this clarity from the beginning and I’ll make sure to use what I learned from my mistakes and to point others in the same direction. Obviously I’m far from successful as I still didn’t land a developer job, but I’ve never been so productive and I can attribute that to a shift in my mindset. </p>\n\n\n\n<p class=\"wp-block-paragraph\">The main idea with Cappuccino Codes is to create an one-stop-shop where I’ll have the blog, educational resources, my portfolio, my CV and my projects. Having a brand with a vision and a mission statement provides a clear and narrow locus in my mind, where everything related to my coding activities go to. It doesn’t stop me from having broad interests and cultivate new thoughts and processes, but it gives me a mental safe harbour, a compass. And, most importantly, it makes decisions about time allocation easier. When I sit down in my allocated time for coding I know exactly what to do and how long to do it for.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Without much more beating around the bushes, the main thing right now is to have a portfolio with 12 items in the end of 2021. I’ve been listing the stuff I’ve already built and I realised I already 5 items. Three of them are real websites with real purposes and two of them are apps I created for training. I’m currently working on my sixth and it will definitely be ready by the end of the month. If I reach the 12 apps goal early, I’ll just work on improving their looks and functionality. I think depth is as important as width when building an entry-level portfolio and attention to detail will impress recruiters.</p>\n\n\n\n<p class=\"wp-block-paragraph\"></p>\n\n\n\n<figure class=\"wp-block-image size-large\"><img loading=\"lazy\" width=\"900\" height=\"461\" data-attachment-id=\"104\" data-permalink=\"https://cappuccinocodes.wordpress.com/2020/12/03/avalanche-of-ideas/azure-certifications-new1/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/azure-certifications-new1.jpg\" data-orig-size=\"900,461\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"Azure-Certifications-NEW1\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/azure-certifications-new1.jpg?w=723\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/azure-certifications-new1.jpg?w=900\" alt=\"\" class=\"wp-image-104\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/azure-certifications-new1.jpg 900w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/azure-certifications-new1.jpg?w=150 150w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/azure-certifications-new1.jpg?w=300 300w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/azure-certifications-new1.jpg?w=768 768w\" sizes=\"auto, (max-width: 900px) 100vw, 900px\" /></figure>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Some Ideas</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Some of the things that I’ve been researching and considering:</p>\n\n\n\n<ol class=\"wp-block-list\"><li><strong>Getting an Azure Certification</strong>: Apparently Microsoft retired the <a href=\"http://ASP.NET\">ASP.NET</a>&nbsp;certification to push people onto the cloud. It seems like this is where things are heading and I want to be part of it. So I’ll definitely look into getting the AZ-900:&nbsp;<a href=\"https://docs.microsoft.com/en-us/learn/certifications/azure-fundamentals\">https://docs.microsoft.com/en-us/learn/certifications/azure-fundamentals</a></li></ol>\n\n\n\n<ol class=\"wp-block-list\" start=\"2\"><li><strong>Internet of Things</strong>: I’ve already started looking into projects that involve IoT (Internet of Things), which is the ability to connect the physical world with the internet. A theoretical example would be having a water bottle with a sensor that sends a tick to a database every time you finish drinking so you can automatically measure your water drinking habits. Telemetry has always fascinated me and I want to dive into it.</li></ol>\n\n\n\n<ol class=\"wp-block-list\" start=\"3\"><li><strong>120 hours in December</strong>: In the past week I stopped tracking every minute of my life and ended up coding way less than necessary. Also having to allocate time to deal with getting a car and a license contributed to that. So now I’ve decided I need to get back on track and code for 120hs in December. It’s not that hard considering the life I’ve crafted for myself but it does require some discipline.&nbsp;</li></ol>\n\n\n\n<ol class=\"wp-block-list\" start=\"4\"><li><strong>Personal Life Management App:</strong> One of my portfolio ideas is obviously a mobile app. As far as I know I’ll have to use a technology called Xamarin Forms to create it. And I want to have an app that serves as headquarters for the stuff I want to track in my life. I’ll start with simple things like sleep and a budget, with unified database, but eventually I want it to have the ability to track other aspects of my existence.</li></ol>\n\n\n\n<figure class=\"wp-block-image size-large\"><img loading=\"lazy\" width=\"1024\" height=\"405\" data-attachment-id=\"106\" data-permalink=\"https://cappuccinocodes.wordpress.com/2020/12/03/avalanche-of-ideas/screen-shot-2020-12-03-at-6-33-18-pm-2/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-03-at-6.33.18-pm-1.png\" data-orig-size=\"2504,992\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"Screen Shot 2020-12-03 at 6.33.18 pm\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-03-at-6.33.18-pm-1.png?w=723\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-03-at-6.33.18-pm-1.png?w=1024\" alt=\"\" class=\"wp-image-106\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-03-at-6.33.18-pm-1.png?w=1024 1024w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-03-at-6.33.18-pm-1.png?w=2048 2048w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-03-at-6.33.18-pm-1.png?w=150 150w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-03-at-6.33.18-pm-1.png?w=300 300w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-03-at-6.33.18-pm-1.png?w=768 768w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/12/screen-shot-2020-12-03-at-6.33.18-pm-1.png?w=1440 1440w\" sizes=\"auto, (max-width: 1024px) 100vw, 1024px\" /></figure>\n\n\n\n<ol class=\"wp-block-list\" start=\"5\"><li><strong>Using Reddit</strong>: Using reddit in my coding journey will serve many purposes. First to just get help with general questions I might have. They will be questions about the big picture, architecture and paths to follow and not specific coding-related. Those will always go to stack overflow. They do a good job at keeping opinion-based discussions out of there so it’s predominantly technical. Not a lot of “why”, but a lot of “how to”. Second, it will fulfil my need to help others. There are many beginners in those forums with the same questions I had when I started and often times their questions are left unanswered or answered poorly. Third, it will help me to see what’s going on, what are the trends and what other more qualified and advanced professionals are doing.&nbsp;</li></ol>\n\n\n\n<p class=\"wp-block-paragraph\">So that’s it for now, there’s much more in my mind but I’ll try to keep these posts somewhat short. Right now I want to prioritise consistency over depth.</p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31029,
            Title = "LEGACY: Back To Adult Life!",
            Slug = "back-to-adult-life",
            Description = "And I have finally completed my second portfolio project!! It’s an application to manage an archive for an insurance company. It’s very exciting because the final version of thi...",
            CardImgUrl = "legacy-back-to-adult-life.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/11/29/back-to-adult-life/",
            ReleaseDate = new DateTime(2020, 11, 29),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\" id=\"block-fee8cdba-14ba-4219-903c-220f0339d3b7\">And I have finally completed my second portfolio project!! It’s an application to manage an archive for an insurance company. It’s very exciting because the final version of this application has a chance of actually being deployed for real use of real costumers in a real company. And in England! Which adds some gravitas to the whole thing.&nbsp;</p>\n\n\n\n<p class=\"wp-block-paragraph\" id=\"block-d9095756-bd93-4c09-8e47-42ea6f154e1b\">I sent the code to my mentor and I’m sure it will be tore apart and have to be completely rewritten. But it does everything it’s supposed to do and it’s a great step toward completing the production-ready app.&nbsp;</p>\n\n\n\n<p class=\"wp-block-paragraph\" id=\"block-1d92ff5b-7a98-4469-923f-a0a53839b866\">The next step is to get more comfortable with Azure. My idea is to have a separate Azure Web App for each of the projects in my portfolio so they never die, as it’s often the case in portfolio projects. I might start mixing Firebase and AWS for the server stuff to add technologies to my CV as well but that will only happen when I’m absolutely comfortable with Azure. Not only I need to be able to create resources seamlessly but also with the minimum possible cost. I’m currently paying around 35$ a month for Azure and I don’t want any costs added to that.</p>\n\n\n\n<p class=\"wp-block-paragraph\" id=\"block-14389579-4733-4f1b-809c-c4bd208ad31c\"><strong>Crossroads</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\" id=\"block-50e51b44-fa98-42ba-a07d-e177f304cbe9\">Public transportation days are almost over!! 😅Pablomobile (Mazda 3 2007) has already been acquired, now all I have to do Is get my license (hopefully on the 11th) and hit the roads!</p>\n\n\n\n<p class=\"wp-block-paragraph\" id=\"block-a725d1f2-3f7c-457d-b6c9-e965994f3d74\">After getting stopped by the police in March 2019, I haven’t been able to use a car. I had no problem figuring out Queensland’s public transportation system and pushing through, always using my commute type to study or work. But it’s hard to deny that a car-less life is just more difficult.&nbsp;</p>\n\n\n\n<p class=\"wp-block-paragraph\" id=\"block-213d381c-d60e-49d7-bdea-d46cfcb7bef2\">Three aspects of my life were severely affected. The first was my social life. While I was just in Brisbane, it wasn’t very hard to catch up with my friends but when I started commuting several times a week to the Sunshine Coast, the time for my coffee catch ups just disappeared.&nbsp;</p>\n\n\n\n<p class=\"wp-block-paragraph\" id=\"block-e5f4bd04-d653-4fd3-b366-d94efff94407\">Then there’s dancing. I’ve been thriving as a teacher in my new job but the ability to go social dancing, which is a very important component of this trade, was severely hindered. The parties usually finish late, which means that going to a party affects my sleep and the entire flow of my next day, which is too costly.</p>\n\n\n\n<p class=\"wp-block-paragraph\" id=\"block-ca49c1b5-0415-4185-8099-10c485291b69\">And the last one is the ability to stock food so I don’t have to go to the supermarket almost every day. It’s time consuming and I end up &nbsp;not eating as well as I could because there’s always something missing. Having a car I can just buy all the tuna and beans I need for a month, so meal prep becomes easy and so does keeping food intake discipline</p>\n\n\n\n<p class=\"wp-block-paragraph\" id=\"block-54decca9-b931-47f0-9f8e-207342e91d8b\"><strong>Fortnight Challenge</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\" id=\"block-951626be-4cee-4da8-8931-12aac3e9f8cc\">Now that I finally have a couple of apps completed I feel I can create more time for writing in this space. So I’m creating a challenge where I’ll be posting seven times during the next 14 days. 😁 But now…. Back to coding!&nbsp;</p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31030,
            Title = "LEGACY: I’m a Full Stack Developer!",
            Slug = "im-a-full-stack-developer",
            Description = "So much has happened in the last few weeks! So much to write about. But I’ll concentrate on the most important thing. For the first time I’ve created and published a full-stack...",
            CardImgUrl = "legacy-im-a-full-stack-developer.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/11/16/im-a-full-stack-developer/",
            ReleaseDate = new DateTime(2020, 11, 16),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">So much has happened in the last few weeks! So much to write about. But I’ll concentrate on the most important thing. For the first time I’ve created and published a full-stack application. I can call myself a full-stack developer! Right now I can say I can create a back-end API with <a href=\"http://asp.net/\">Asp.NET</a> Core, the front-end with Angular Material, the authentication with Firestore, with the database and deployment powered by Azure. </p>\n\n\n\n<figure class=\"wp-block-image size-large\"><img loading=\"lazy\" width=\"1024\" height=\"419\" data-attachment-id=\"93\" data-permalink=\"https://cappuccinocodes.wordpress.com/screen-shot-2020-11-16-at-8-12-39-am/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/11/screen-shot-2020-11-16-at-8.12.39-am.png\" data-orig-size=\"2776,1136\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"screen-shot-2020-11-16-at-8.12.39-am\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/11/screen-shot-2020-11-16-at-8.12.39-am.png?w=723\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/11/screen-shot-2020-11-16-at-8.12.39-am.png?w=1024\" alt=\"\" class=\"wp-image-93\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/11/screen-shot-2020-11-16-at-8.12.39-am.png?w=1024 1024w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/11/screen-shot-2020-11-16-at-8.12.39-am.png?w=2048 2048w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/11/screen-shot-2020-11-16-at-8.12.39-am.png?w=150 150w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/11/screen-shot-2020-11-16-at-8.12.39-am.png?w=300 300w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/11/screen-shot-2020-11-16-at-8.12.39-am.png?w=768 768w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/11/screen-shot-2020-11-16-at-8.12.39-am.png?w=1440 1440w\" sizes=\"auto, (max-width: 1024px) 100vw, 1024px\" /><figcaption><em>Budget app&#8217;s </em>CRUD Page</figcaption></figure>\n\n\n\n<p class=\"wp-block-paragraph\">I totally understand there’s a long way to go to become a good full-stack developer, but nonetheless, I have that skill.  And the sky is the limit from here. From now to the end of 2021 my goal is to have a portfolio with 12 applications so I can impress recruiters. I’m thinking of an average of one application a month, plus one month to develop the portfolio itself. <br>Some of App ideas I have are: </p>\n\n\n\n<ul class=\"wp-block-list\"><li>Companies system</li><li>Sleep tracker</li><li>Online Store</li><li>Sports-bets tracker&nbsp;</li><li>Language Learning App</li></ul>\n\n\n\n<p class=\"wp-block-paragraph\">I think one month is a good time to create a wide but also deep enough portfolio with many interesting functionalities and interesting front-end, but if it takes me a bit longer I don’t mind. </p>\n\n\n\n<div class=\"wp-block-image\"><figure class=\"aligncenter size-large\"><img loading=\"lazy\" width=\"1006\" height=\"562\" data-attachment-id=\"94\" data-permalink=\"https://cappuccinocodes.wordpress.com/screen-shot-2020-11-16-at-8-12-50-am/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/11/screen-shot-2020-11-16-at-8.12.50-am.png\" data-orig-size=\"1006,562\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"screen-shot-2020-11-16-at-8.12.50-am\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/11/screen-shot-2020-11-16-at-8.12.50-am.png?w=723\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/11/screen-shot-2020-11-16-at-8.12.50-am.png?w=1006\" alt=\"\" class=\"wp-image-94\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/11/screen-shot-2020-11-16-at-8.12.50-am.png 1006w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/11/screen-shot-2020-11-16-at-8.12.50-am.png?w=150 150w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/11/screen-shot-2020-11-16-at-8.12.50-am.png?w=300 300w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/11/screen-shot-2020-11-16-at-8.12.50-am.png?w=768 768w\" sizes=\"auto, (max-width: 1006px) 100vw, 1006px\" /><figcaption>Budget app&#8217;s login page</figcaption></figure></div>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Focusing</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I’ve been trying to narrow down my lines of work so I don’t get lost in the ocean of possibilities the internet provides. Right now my priority is the creation of a portfolio with 4 apps. That’s absolutely urgent so I can start applying for jobs with something to show recruiters.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Second in the line comes creating the Archive system my mentor offered me to help with my learning. The budget app I created uses the same technologies and database design as the archive, so I’m on my way to complete it. I’m still curious about if and how it will be applied to his portal. <br>And third, which is probably the one I’m most excited about, is the creation of YouTube tutorials. This also ties with the first two, as I can use them as a base for my beginner tutorials and It’s always good to point my viewers to a decent website when they look me up.</p>\n\n\n\n<p class=\"wp-block-paragraph\">There’s so much going on! I’ll post more in the next few days. I think it will work better if I make shorter posts, so I don’t feel like it’s an enormous time-effort and end up not doing it. <br>Back soon! I hope 😀</p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31031,
            Title = "LEGACY: Pagination Obsession",
            Slug = "pagination-obsession",
            Description = "My focus right now on my ASP.NET learning is on pagination. It never occurred to me prior to two weeks ago that pagination is absolutely essential to any API. As databases grow,...",
            CardImgUrl = "legacy-pagination-obsession.png",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/10/26/pagination-obsession/",
            ReleaseDate = new DateTime(2020, 10, 26),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">My focus right now on my <a href=\"http://ASP.NET\">ASP.NET</a>&nbsp;learning is on pagination. It never occurred to me prior to two weeks ago that pagination is absolutely essential to any API. As databases grow, you want to provide ways to allow the consumer not to fetch all records at once.&nbsp;</p>\n\n\n\n<p class=\"wp-block-paragraph\">I spent my entire Sunday trying to find an elegant solution for it, with no success. Some of the tutorials I watched included the programmatic formation of an URI and the code got really dense really quickly. I’ll definitely learn about the URIHelper at some point to enhance my tool box, but right now I want to keep the application lean and only having essential functionalities.</p>\n\n\n\n<p class=\"wp-block-paragraph\">After pagination the focus will be on sorting, which can also be a bit painful and involve construction of URIs but I’m excited because I’m understanding the idea behind the code and that knowledge can never be taken away from me once it’s solid in my head.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><br><strong>Focusing</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I have been using GitHub to help me with the “Divide and Conquer” style of attacking my projects. At any given time I’m executing some clearly defined task and at the end I push my work to Github. This routine has the double benefit of creating a back-up so I don’t repeat last weeks debacle, but also it works as a closure for that task.</p>\n\n\n\n<p class=\"wp-block-paragraph\">When working on a complex project, it might be hard to see the end of the tunnel, so having these checkpoints serve a very important purpose to avoid the emotional ups-and-downs that can come from the frustration of being stuck. And getting stuck is very common in the life of a programmer, so it’s good to have found out a tool and a thinking model to mitigate the impact when it happens.<br>Oh, and using Github Desktop smoothens the process a lot and have great user interface for one to stay on top of the repository.</p>\n\n\n\n<div class=\"wp-block-image\"><figure class=\"aligncenter size-large is-resized\"><img loading=\"lazy\" data-attachment-id=\"85\" data-permalink=\"https://cappuccinocodes.wordpress.com/screen-shot-2020-10-26-at-10-49-26-pm/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/screen-shot-2020-10-26-at-10.49.26-pm.png\" data-orig-size=\"2016,1222\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"screen-shot-2020-10-26-at-10.49.26-pm\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/screen-shot-2020-10-26-at-10.49.26-pm.png?w=723\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/screen-shot-2020-10-26-at-10.49.26-pm.png?w=1024\" alt=\"\" class=\"wp-image-85\" width=\"681\" height=\"412\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/screen-shot-2020-10-26-at-10.49.26-pm.png?w=1024 1024w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/screen-shot-2020-10-26-at-10.49.26-pm.png?w=681 681w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/screen-shot-2020-10-26-at-10.49.26-pm.png?w=1362 1362w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/screen-shot-2020-10-26-at-10.49.26-pm.png?w=150 150w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/screen-shot-2020-10-26-at-10.49.26-pm.png?w=300 300w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/screen-shot-2020-10-26-at-10.49.26-pm.png?w=768 768w\" sizes=\"auto, (max-width: 681px) 100vw, 681px\" /><figcaption>Github desktop in action</figcaption></figure></div>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Tips and Tricks</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I spend much more time eating than I used to. I stopped fasting for a week now and entered a bulking phase. I’ll write about that later. But now when I eat I’ve been watching videos with tips and tricks for the devices/apps the I use the most. I start with Google Calendar. There are many cool functionalities that it’s hard to find out by yourself so I’ll be posting a few every now and then.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Today’s tip is the ability to use shortcuts to change the calendar view. It might seem like a useless functionality at first but I found it very practical and I imagine people that use calendar more than me would love it.</p>\n\n\n\n<div class=\"wp-block-image\"><figure class=\"aligncenter size-large is-resized\"><img loading=\"lazy\" data-attachment-id=\"86\" data-permalink=\"https://cappuccinocodes.wordpress.com/screen-shot-2020-10-26-at-10-50-24-pm-1/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/screen-shot-2020-10-26-at-10.50.24-pm-1.png\" data-orig-size=\"1086,854\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"screen-shot-2020-10-26-at-10.50.24-pm-1\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/screen-shot-2020-10-26-at-10.50.24-pm-1.png?w=723\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/screen-shot-2020-10-26-at-10.50.24-pm-1.png?w=1024\" alt=\"\" class=\"wp-image-86\" width=\"531\" height=\"417\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/screen-shot-2020-10-26-at-10.50.24-pm-1.png?w=1024 1024w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/screen-shot-2020-10-26-at-10.50.24-pm-1.png?w=531 531w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/screen-shot-2020-10-26-at-10.50.24-pm-1.png?w=1062 1062w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/screen-shot-2020-10-26-at-10.50.24-pm-1.png?w=150 150w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/screen-shot-2020-10-26-at-10.50.24-pm-1.png?w=300 300w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/screen-shot-2020-10-26-at-10.50.24-pm-1.png?w=768 768w\" sizes=\"auto, (max-width: 531px) 100vw, 531px\" /><figcaption>Google Calendar shortcuts</figcaption></figure></div>\n\n\n\n<p class=\"wp-block-paragraph\">Ok, time to sleep so I can code early tomorrow morning!</p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31032,
            Title = "LEGACY: Creating My Brand",
            Slug = "creating-my-brand",
            Description = "My brain goes back and forth with the name of the brand: Cappuccino Codes (or coding), but I’m trying not to overthink it too much and always go back to advice given many times...",
            CardImgUrl = "legacy-creating-my-brand.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/10/22/creating-my-brand/",
            ReleaseDate = new DateTime(2020, 10, 22),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">My brain goes back and forth with the name of the brand: Cappuccino Codes (or coding), but I’m trying not to overthink it too much and always go back to advice given many times by Tim Ferriss and his guests: Focus on content, not in Marketing. </p>\n\n\n\n<p class=\"wp-block-paragraph\">So I obviously don’t want to overlook the design of my brand and do something ugly, but I don’t want to spend too much time in branding right now. The focus needs to be on creating quality content and everything else will follow naturally. Once there’s success and money as a consequence, I can always recalibrate my branding with professionals.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Having said that, I created an Instagram account (@cappuccinocodes) and a <a href=\"https://cappuccinocoding.com/\">new domain</a> for the blog, which I want to become a platform with more content in the future.</p>\n\n\n\n<div class=\"wp-block-image\"><figure class=\"aligncenter size-large\"><img loading=\"lazy\" width=\"1024\" height=\"343\" data-attachment-id=\"73\" data-permalink=\"https://cappuccinocodes.wordpress.com/image-1-2/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/image-1.png\" data-orig-size=\"1532,514\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"image-1\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/image-1.png?w=723\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/image-1.png?w=1024\" alt=\"\" class=\"wp-image-73\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/image-1.png?w=1024 1024w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/image-1.png?w=150 150w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/image-1.png?w=300 300w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/image-1.png?w=768 768w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/image-1.png?w=1440 1440w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/image-1.png 1532w\" sizes=\"auto, (max-width: 1024px) 100vw, 1024px\" /></figure></div>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Content Production</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I had an excellent start this Thursday, coding for six hours with the sole focus of putting together a CRUD application with an Angular front-end. That will be the first item in my portfolio and my first tutorial. I created a super simple api without any advanced concept: It’s synchronous, it doesn’t have DTOs nor it uses the repository pattern. I would even avoid Linq queries but that’s probably too much. Maybe one day? </p>\n\n\n\n<p class=\"wp-block-paragraph\">The Angular part was a bit painful. It took me two hours to debug a single typo, which led me to learn that I have to look at the network tab of the inspector to help me troubleshoot stuff. Hopefully I can get all of it done by tomorrow and even connect it to Azure, which would be an advanced part of the tutorial. So far I’ve completed the “Post” part of the front end and I’m looking forward to complete Get, Delete and Put later tonight. Tomorrow I’ll do the Azure part. </p>\n\n\n\n<p class=\"wp-block-paragraph\">After that obviously I have to go back to the project I’m developing for my mentor, which I accidentally deleted yesterday. This whole branding thing might sound like a waste of time given the main objective, which is working with him, but it’s all part of the learning journey</p>\n\n\n\n<div class=\"wp-block-image\"><figure class=\"aligncenter size-large\"><img loading=\"lazy\" width=\"1024\" height=\"343\" data-attachment-id=\"72\" data-permalink=\"https://cappuccinocodes.wordpress.com/image-1/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/image-1.png\" data-orig-size=\"1532,514\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"image-1\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/image-1.png?w=723\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/image-1.png?w=1024\" alt=\"\" class=\"wp-image-72\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/image-1.png?w=1024 1024w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/image-1.png?w=150 150w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/image-1.png?w=300 300w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/image-1.png?w=768 768w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/image-1.png?w=1440 1440w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/image-1.png 1532w\" sizes=\"auto, (max-width: 1024px) 100vw, 1024px\" /></figure></div>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Tutorials</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I’ve been trying to commute walking without listening to anything so I can put my brain to work on my ideas for tutorials. The idea is to have many apps in various stages of development, using different technologies and architectural styles. For example, someone might be looking for a CRUD app with Angular 10, with nothing else. Someone else might want the same but with the repository pattern. Someone else might want all of that but also with Data Transfer Objects to support. Some people might muck around with a generic repository and units of work, some might not. </p>\n\n\n\n<div class=\"wp-block-image\"><figure class=\"aligncenter size-large\"><img loading=\"lazy\" width=\"503\" height=\"360\" data-attachment-id=\"71\" data-permalink=\"https://cappuccinocodes.wordpress.com/image/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/image.png\" data-orig-size=\"503,360\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"image\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/image.png?w=503\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/image.png?w=503\" alt=\"\" class=\"wp-image-71\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/image.png 503w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/image.png?w=150 150w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/image.png?w=300 300w\" sizes=\"auto, (max-width: 503px) 100vw, 503px\" /></figure></div>\n\n\n\n<p class=\"wp-block-paragraph\">Also different projects will use different database relations: Many-to-one, many-to-many (as shown above), one-to-one, and so forth. &nbsp; There’s nothing out there covering all of these bases in one stop shop and I want to provide it. I’ll obviously learn a lot in the process and adjust according to my viewers requests.&nbsp;</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Well!! Time to go back to coding, see ya later!</strong></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31033,
            Title = "LEGACY: Why Cappuccino Coding",
            Slug = "why-cappuccino-coding",
            Description = "This Tuesdays was one of those days that every programmer goes through but it doesn’t make it any more fun. A character building day, one could say. I did an excellent job in al...",
            CardImgUrl = "legacy-why-cappuccino-coding.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/10/20/why-cappuccino-coding/",
            ReleaseDate = new DateTime(2020, 10, 20),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">This Tuesdays was one of those days that every programmer goes through but it doesn&#8217;t make it any more fun. A character building day, one could say. </p>\n\n\n\n<p class=\"wp-block-paragraph\">I did an excellent job in allocating a big chunk of time for coding (7h38&#8242; in total) but apart from maybe the first hour, I didn&#8217;t get anything done. Early in the morning I accidentally deleted my last week of work thinking I was just cleaning my control source environment. That is not too bad, as the application I wrote isn&#8217;t massive and it&#8217;s very well documented. The problem is that somehow my Visual Studio Code was also ruined. Omnisharp stopped working and nothing was getting imported into any project.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;m not sure it&#8217;s fixed yet, it seems like turning Omnisharp&#8217;s &#8220;Using Global Mono&#8221; to &#8220;Never&#8221; did the job, but it&#8217;s too early to celebrate. This one thing that has always frustrated me a little bit in my coding journey. Sometimes I&#8217;ll do things without really knowing why and how they work, not because I&#8217;m too lazy to dig in but it&#8217;s because there are thousands of those things in any given app and If I try to see through the fog of every class I&#8217;ll never anything done (I can barely get anything done as it is).</p>\n\n\n\n<figure class=\"wp-block-image size-large\"><img loading=\"lazy\" width=\"1024\" height=\"509\" data-attachment-id=\"46\" data-permalink=\"https://cappuccinocodes.wordpress.com/screen-shot-2020-10-20-at-6-43-34-pm/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/screen-shot-2020-10-20-at-6.43.34-pm.png\" data-orig-size=\"2086,1038\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"screen-shot-2020-10-20-at-6.43.34-pm\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/screen-shot-2020-10-20-at-6.43.34-pm.png?w=723\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/screen-shot-2020-10-20-at-6.43.34-pm.png?w=1024\" alt=\"\" class=\"wp-image-46\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/screen-shot-2020-10-20-at-6.43.34-pm.png?w=1024 1024w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/screen-shot-2020-10-20-at-6.43.34-pm.png?w=2048 2048w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/screen-shot-2020-10-20-at-6.43.34-pm.png?w=150 150w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/screen-shot-2020-10-20-at-6.43.34-pm.png?w=300 300w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/screen-shot-2020-10-20-at-6.43.34-pm.png?w=768 768w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/screen-shot-2020-10-20-at-6.43.34-pm.png?w=1440 1440w\" sizes=\"auto, (max-width: 1024px) 100vw, 1024px\" /><figcaption><strong><em>The OmniSharp Debacl</em></strong>e</figcaption></figure>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Implementing Principles</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">One of the things that can be quite frustrating in coding is that it takes a while before there are palpable results. It&#8217;s a thing most people feel or have felt, particularly those who work in large projects, where their contribution is too tiny to be noticed, as Alain De Bouton points out in this excellent video about finding meaningful work. </p>\n\n\n\n<p class=\"wp-block-paragraph\">That&#8217;s why I decided to implement a simple principle. At any given time I have to work with clear goals and sub-goals so I can be proud of what was achieved up to any point. That will lead me to finish a number of small applications that will serve as a portfolio to be proud of. </p>\n\n\n\n<p class=\"wp-block-paragraph\">As I know this is something that bothers many beginners and might even ultimately get them to quit, I decided to create a brand that will deliver quality educational material: Cappuccino Coding. I&#8217;ll expand on it later, but basically the idea is to provide a series of tutorials for building real-life (or close to) applications. At first, they&#8217;ll be a bunch of APIs that will be scalable and with different levels of complexity, isolating components and architectural concepts that can be quite intimidating when put together, as most of the best tutorials do. The transition from the &#8220;Todo List&#8221; kind of app to the enterprise level app is very confusing. There are a handful of very good tutorials out there, but I still think there&#8217;s a massive gap of quality material in the middle ground between the super simple and the super complex. That&#8217;s the territory Cappuccino Coding will try to occupy. </p>\n\n\n\n<div class=\"wp-block-image\"><figure class=\"aligncenter size-large is-resized\"><img loading=\"lazy\" data-attachment-id=\"48\" data-permalink=\"https://cappuccinocodes.wordpress.com/img_5406/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/img_5406.jpg\" data-orig-size=\"3024,4032\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;1.8&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;iPhone XR&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;1603114703&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;4.25&quot;,&quot;iso&quot;:&quot;25&quot;,&quot;shutter_speed&quot;:&quot;0.0081967213114754&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;1&quot;}\" data-image-title=\"img_5406\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/img_5406.jpg?w=723\" src=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/img_5406.jpg?w=768\" alt=\"\" class=\"wp-image-48\" width=\"431\" height=\"575\" srcset=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/img_5406.jpg?w=768 768w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/img_5406.jpg?w=431 431w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/img_5406.jpg?w=862 862w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/img_5406.jpg?w=113 113w, https://cappuccinocodes.wordpress.com/wp-content/uploads/2020/10/img_5406.jpg?w=225 225w\" sizes=\"auto, (max-width: 431px) 100vw, 431px\" /><figcaption><strong><em>Fantastic Coffee at Stanton, Brisbane CBD</em></strong></figcaption></figure></div>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Enjoying The Process</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Cappuccino Coding has it&#8217;s name because I want something that people will remember. I do like Shut Up and Code but I think that&#8217;s too aggressive. I think cappuccino conveys a better message: Sit down and enjoy the process. There aren&#8217;t many things I enjoy more in life than sitting down in a nice cafe with a fantastic cappuccino doing some work.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Merging Blogs</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">This is the third blog I&#8217;ve had since I&#8217;ve started coding, which shows how inconstant my mind can be, or all over the shop, one might say, but I&#8217;ll do myself a favour and merge all posts in this blog so I can have a nice archive starting from my first javascript course at Code Academy in June 2019. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>See you soon!</strong></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31034,
            Title = "LEGACY: Laser Focus",
            Slug = "laser-focus",
            Description = "Past Week Last Tuesday I had another meeting with my mentor and we started discussing the front-end of the application I’m working on. I had gotten back to Angular, which I miss...",
            CardImgUrl = "legacy-laser-focus.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/10/19/laser-focus/",
            ReleaseDate = new DateTime(2020, 10, 19),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\"><strong>Past Week</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Last Tuesday I had another meeting with my mentor and we started discussing the front-end of the application I’m working on. I had gotten back to Angular, which I missed a lot, and was pretty happy about it. Seeing all the plumbing I’ve been working on finally materialising into a user interface was very satisfactory.</p>\n\n\n\n<p class=\"wp-block-paragraph\">As soon as we got into the particulars of consuming the API with Angular Material, which was my focus for our meeting, he said: “Oh, you don’t have pagination”, which made me realise pagination, sorting and filtering are basic elements of an API and I hadn’t done it.</p>\n\n\n\n<p class=\"wp-block-paragraph\">So after the meeting I tried to apply a few solutions gathered from the web into my project but I couldn’t implement it, probably because of sheer lack of experience. On Wednesday, which was a particularly difficult day due to circumstances related to my job, I spent two hours looking at my laptop in the train without getting anything done.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Then on the Thursday I regrouped, woke up early, went to my favourite cafe up in the Sunshine Coast and started the project from scratch, using Kevin Docx “<a href=\"https://app.pluralsight.com/library/courses/asp-dot-net-core-3-restful-api-building/table-of-contents\">Building a Restful API with ASP.NET Core 3</a>”. I knew it would take some time to build the app again from zero but it was necessary to get a better hold of what I’m doing. And going into the project I decided I wasn’t going to start from scratch again. I won’t have this luxury when I have tight dead lines to work with. Rather I’d create a very good documentation of the project and solve whatever problems I face with the help of the community. </p>\n\n\n\n<figure class=\"wp-block-image size-large is-resized\"><img loading=\"lazy\" data-attachment-id=\"420\" data-permalink=\"https://cappuccinocodes.wordpress.com/2020/06/20/karlie-kloss/karlie-kloss-1549565171/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/a343e-karlie-kloss-1549565171.jpg\" data-orig-size=\"3466,3466\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"karlie-kloss-1549565171\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/a343e-karlie-kloss-1549565171.jpg?w=723\" src=\"https://souzacode.files.wordpress.com/2020/10/image-1.jpeg?w=1024\" alt=\"\" class=\"wp-image-420\" width=\"423\" height=\"423\" /></figure>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>The Sorting Maze</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">So that’s where I am right now, back to the plumbing. I haven’t touched Angular for week, fully focused on getting the API up and running. Right now I’m dealing with the complexities of creating a sorting functionality, which is the follow-up course: <a href=\"https://app.pluralsight.com/library/courses/asp-dot-net-core-3-advanced-restful-concerns/table-of-contents\">Implementing Advanced Restful Concerns with ASP.NET Core 3</a>.  The solution presented by Kevin seems very intricate and I confess I felt lost for the most part of the last couple of days but I know that this level of discomfort will lead to progress soon. The solution is multi-layered, involving many classes with their respective interfaces. Which means I’ll stay with it for another couple of days before moving on.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>The Next Issue</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">As amazing as the courses are, I’m a bit concerned with the fact that in both courses none of the methods are asynchronous and I’m not sure it will be easy to implement the solutions provided in Kevin&#8217;s “<a href=\"https://app.pluralsight.com/library/courses/building-async-api-aspdotnet-core/table-of-contents\">Building an Async API</a>” course to a complex application to make it async. I guess I’ll have to use help of the community if I get stuck. </p>\n\n\n\n<div class=\"wp-block-image\"><figure class=\"aligncenter size-large\"><img loading=\"lazy\" width=\"460\" height=\"460\" data-attachment-id=\"419\" data-permalink=\"https://cappuccinocodes.wordpress.com/2020/06/19/ricardo-semler/semler-bio-avatar/\" data-orig-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/ca5a2-semler-bio-avatar.jpg\" data-orig-size=\"500,500\" data-comments-opened=\"1\" data-image-meta=\"{&quot;aperture&quot;:&quot;0&quot;,&quot;credit&quot;:&quot;&quot;,&quot;camera&quot;:&quot;&quot;,&quot;caption&quot;:&quot;&quot;,&quot;created_timestamp&quot;:&quot;0&quot;,&quot;copyright&quot;:&quot;&quot;,&quot;focal_length&quot;:&quot;0&quot;,&quot;iso&quot;:&quot;0&quot;,&quot;shutter_speed&quot;:&quot;0&quot;,&quot;title&quot;:&quot;&quot;,&quot;orientation&quot;:&quot;0&quot;}\" data-image-title=\"semler-bio-avatar\" data-image-description=\"\" data-image-caption=\"\" data-large-file=\"https://cappuccinocodes.wordpress.com/wp-content/uploads/2021/06/ca5a2-semler-bio-avatar.jpg?w=500\" src=\"https://souzacode.files.wordpress.com/2020/10/image.jpeg?w=460\" alt=\"\" class=\"wp-image-419\" /></figure></div>\n\n\n\n<p class=\"has-text-align-left wp-block-paragraph\"><br><strong>Another Concern</strong></p>\n\n\n\n<p class=\"has-text-align-left wp-block-paragraph\">All of the above concerns don’t even mention the fact that the app might be tore apart by my mentor, the developer of the parent project, to apply the implementations and architecture that he uses in his project. At the same time it’s liberating because I can just get the app to work using any technique I find appropriate, but it does cause a bit of anxiety on my perfectionist self.</p>\n\n\n\n<p class=\"has-text-align-left wp-block-paragraph\"><strong>Coming Days</strong></p>\n\n\n\n<p class=\"has-text-align-left wp-block-paragraph\">So that’s it! In the next few days hopefully I’ll finalise a more robust API so I can transition to Angular without having to look back. I’m confident all the hard work will pay off and I’ll be using what I learned as a solid foundation for the creation of many APIs.</p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31035,
            Title = "LEGACY: The Ultimate App",
            Slug = "the-ultimate-app",
            Description = "In my coding studies I’ve been experimenting with apps that will deal with data tracked from my personal activities and habits. “What you can measure you can improve”, Tim Ferri...",
            CardImgUrl = "legacy-the-ultimate-app.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/10/12/the-ultimate-app/",
            ReleaseDate = new DateTime(2020, 10, 12),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">In my coding studies I’ve been experimenting with apps that will deal with data tracked from my personal activities and habits. “What you can measure you can improve”, Tim Ferriss always says. I’ve done many small applications to track my sleep, daily activities, budget, amongst others. So I couple of days ago it clicked! I should just create an app with multiple controllers for all of them. <br>It will be more technically challenging than an app with only a couple of controllers. It will probably have a couple of dozen, and a database with as many tables, which will provide a great use case for things like a generic repository and unit of work. </p>\n\n\n\n<p class=\"wp-block-paragraph\">I started it today, with a “Sleep Controller”, to handle data related to my sleeping habits,  with a slightly different approach from all the courses I’ve seen. Usually people start with the full API and then move on to Angular, or vice-versa, but I decided to build it in parallel. I want things to show up on the Front-End asap. </p>\n\n\n\n<p class=\"wp-block-paragraph\">I created a super simple API with a get request and linked it to a basic Angular front-end and I’ll ONLY create functionalities that are actually useful to me. On this app I won’t create anything for the sake of creating it. I just learned today about the YAGNI principle and it sounds like music to my ears:</p>\n\n\n\n<p class=\"wp-block-paragraph\">&#8220;You aren&#8217;t gonna need it&#8221; (YAGNI) is a principle of extreme programming (XP) that states a programmer should not add functionality until deemed necessary.”</p>\n\n\n\n<p class=\"wp-block-paragraph\">How beautiful is this?</p>\n\n\n\n<p class=\"wp-block-paragraph\">Below is literally what my app looks like right now, with two “sleep records” fetched from a SQL Server powered by Docker and accessed by Angular through an API. Not very appealing for the general public but for a coding student that knows what’s going on behind the scenes, this is gorgeous. </p>\n\n\n\n<figure class=\"wp-block-image size-large is-resized\"><img loading=\"lazy\" src=\"https://souzacode.files.wordpress.com/2020/10/image.png?w=842\" alt=\"\" class=\"wp-image-411\" width=\"485\" height=\"289\" /></figure>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>My Relationship with Food</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">One of the things I’ll be tracking in the “Ultimate App”, is my food intake. My eating habits have changed so much in the last couple of months that one wouldn’t think we’re talking about the same person. I’ve ALWAYS had breakfast as soon as I woke up, I never thought there was another option in life. That’s what you do, right? Wake up, and head to the kitchen. I didn’t even use to brush my teeth before breakfast.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Now everything has changed. I never have breakfast and I’ll always fast for at least 12 hours (on the bad days). This week I started with two decent efforts (15h50 and 19h20 of fasting) and I plan to keep pushing those limits. My idea right now is to have an average of 16h a day and try to push for records about once a fortnight. I don’t think I’ve fasted for more than 21hs since I started. </p>\n\n\n\n<p class=\"wp-block-paragraph\">The transformations on my body seem very positive. I’m definitely leaner, but have also lost some muscle. But I think it still looks ok. Now I plan to maintain my current physique and add some muscle by the sheer volume of lifting. I haven’t decreased any weights since I started fasting, which means my strength and muscular capacity haven’t been affected. Will find out more in the next few  weeks</p>\n\n\n\n<figure class=\"wp-block-image size-large is-resized\"><img loading=\"lazy\" src=\"https://souzacode.files.wordpress.com/2020/10/image-1.png?w=1024\" alt=\"\" class=\"wp-image-412\" width=\"403\" height=\"360\" /></figure>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Future of The Blog</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">There’s so much more that I want to talk about but I don’t want to go into long form just yet. Definitely a plan for the future, but right now I’ll try as hard as I can to post consistent small posts like this one and maybe release a longer one monthly</p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31036,
            Title = "LEGACY: More API learning",
            Slug = "more-api-learning",
            Description = "Today I took a step back and started learning APIs from scratch again on a Pluralsight course. It’s interesting how these things play out. I think it was in November or December...",
            CardImgUrl = "legacy-more-api-learning.png",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/10/03/more-api-learning/",
            ReleaseDate = new DateTime(2020, 10, 3),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">Today I took a step back and started learning APIs from scratch again on a Pluralsight course. It’s interesting how these things play out. I think it was in November or December, only 6 months after I started coding and a student of mine saw some Facebook post I made about it and sent me the link to Pluralsight, which I ignored because I was busy learning from YouTube videos.</p>\n\n\n\n<p class=\"wp-block-paragraph\">It’s easy to say in hindsight, but Pluralsight had everything I need from the get go. It has courses covering every separate subject in C# programming. And even though it’s a paid service (around 40$ AUD a month), it’s extremely cheap for what it offers. Well, better late than never. My tortuous path will make me appreciate Pluralsight way more than I would if I hadn’t gone through the winding road.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Right now I have about five concurrent projects that involve creating and API, all of them scratching a personal itch: A budget application, a time tracker database, a sales records database and the archive I’m developing for my apprenticeship. All of them are slightly different from each other, in regards to api design, database relationships and data model characteristics. </p>\n\n\n\n<p class=\"wp-block-paragraph\">The reason why I’m getting involved in so many projects at the same time is that I think it’s better than developing an api in a particular way and then moving on to the next isn’t so effective to provide a bird-eye view of api design as a whole. I just need to keep track of the main design and approaches used in these applications so I don’t spend too much time figuring out how each one works when I switch between projects.</p>\n\n\n\n<p class=\"wp-block-paragraph\"></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31037,
            Title = "LEGACY: Excellent September",
            Slug = "excellent-september",
            Description = "September was a fantastic month where I solidified some practices and experimented with others and altogether the outcome was very satisfactory. IT My new computer gives me a lo...",
            CardImgUrl = "legacy-excellent-september.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/10/01/excellent-september/",
            ReleaseDate = new DateTime(2020, 10, 1),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">September was a fantastic month where I solidified some practices and experimented with others and altogether the outcome was very satisfactory.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>IT</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">My new computer gives me a lot of flexibility I didn’t have before and I still have my old one (which is useful again after getting rid of Parallels) as a backup in case I have malfunction debacles.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I’ve also got used to studying on Pluralsight in combination with Udemy. Pluralsight’s courses are fantastic, University level stuff. And I can easily go back and forth between courses according to my needs. </p>\n\n\n\n<p class=\"wp-block-paragraph\">I’ve also cemented a note taking system that allows me to switch amongst courses easily without feeling lost or having to restart from scratch. For that I’m using Evernote. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Fasting</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">My eating habits have changed a lot this month. I no longer eat breakfast and have been fasting between 12 and 16 hours daily. I still wasn’t able to get rid of my lower ab pudge, but my body fat has dramatically decreased. I also love that I don’t “have” to it at any particular time anymore, which gives me extra flexibility. Plus eating way less makes me consider every little thing I eat way more carefully.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><em><strong>Dancing</strong></em></p>\n\n\n\n<p class=\"wp-block-paragraph\">In September I&#8217;ve also been to three social dance parties, the first few after Covid. Although I was extremely happy to be on the dance floor again, I felt very self-conscious in the first too. I kept dancing a lot during covid, but it&#8217;s just such a distinct experience that I can say I was truly rusty. Last Friday I taught a decent size workshop (30 couples) at Dance Culture and in the social that ensued I finally felt a bit more comfortable. I was able to feel the music, remember moves and not get out of time often. It doesn&#8217;t matter how much I code in the next ten to twenty years, I just know for sure I&#8217;ll keep dancing, because I love it so much.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Tracing Inputs</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I didn&#8217;t do a very good job at tracking my inputs in a way that would make it easy for me to post them here, but I&#8217;ll post a big &#8220;September&#8221; Spotify playlist in the next few days, with everything I listened to. Most of it was Tim Ferriss as usual but I also listened to Biographics: History One Life at a Time. I&#8217;m definitely hooked, I&#8217;ll listen to the whole collection very quickly. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Blogging</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Blogging was a bit of a disaster but towards the end of the month I found out I can write at least parts of posts during commute, which does help getting some posts done. If I leave it to the end of the day like right now (it&#8217;s 11:17pm) it doesn&#8217;t work, I just want to go to bed.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I wish myself a great September. I&#8217;ll definitely work and study very hard and hopefully will keep that people that matter close to me 😉</p>\n\n\n\n<p class=\"wp-block-paragraph\"></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31038,
            Title = "LEGACY: Postman",
            Slug = "postman",
            Description = "There’s still a long way to go but I’m getting increasingly comfortable working with APIs. I can create a CRUD application in no time, connect it to SQLite or Azure and test eve...",
            CardImgUrl = "legacy-postman.png",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/09/29/postman/",
            ReleaseDate = new DateTime(2020, 9, 29),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">There’s still a long way to go but I’m getting increasingly comfortable working with APIs. I can create a CRUD application in no time, connect it to SQLite or Azure and test everything using Postman. </p>\n\n\n\n<p class=\"wp-block-paragraph\">The missing piece of the puzzle is Microsoft SQL Server Studio. Somehow I haven’t been able to access it from Azure Studio because I couldn’t cross the bridge from Mac to Windows Parallels. That also means Parallels is virtually useless right now. I’m in the bus on my way to have a meeting with my mentor to discuss this. He’s just starting using Docker and we might go over it’s setup so I can get rid of windows once and for all. One of the beauties of <a href=\"https://www.udemy.com/course/learn-to-build-an-e-commerce-app-with-net-core-and-angular\">Neil Cummings course</a> is that he does everything in VS Code using the command line so I can code .net stuff in any computer and any IDE.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Update</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">😀 Yeah! This part is being written after the meeting and Docker is now configured in my machine so I can run a SQL server without parallels. My friend also showed me this tool called SQL comparer that helps with database modifications, which I literally have to do all the time when studying.</p>\n\n\n\n<p class=\"wp-block-paragraph\">It seems like my API is ok, it does what it’s supposed to do, but I need to change some names to fit his main project and implement the Unit Of Work pattern because he uses it in his projects. So this is what I’ll be doing this week, implementing unit of work in all my projects and playing with Docker 😍</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Last Week</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">In the last post I wrote my weeks time tracking results but that was actually from Week 38, compared with with 37. So now I have the results of Week 39. Let’s see:</p>\n\n\n\n<p class=\"wp-block-paragraph\">&#8211; Coding: <strong>21h26&#8242;</strong> (23h56’) (26h19’)</p>\n\n\n\n<p class=\"wp-block-paragraph\">– Sleep: <strong>43h56’</strong> (44h01’) (44h02’)</p>\n\n\n\n<p class=\"wp-block-paragraph\">– Commute: <strong>12h47’</strong> (16h36’) (15h35’). This isn’t counting the hours in which I’m coding in the train </p>\n\n\n\n<p class=\"wp-block-paragraph\">– Social: <strong>16h41’</strong> (11h28’) (6h27’)</p>\n\n\n\n<p class=\"wp-block-paragraph\">– Work: <strong>35h14’</strong> (27h35’) (34h10’)</p>\n\n\n\n<p class=\"wp-block-paragraph\">– All of the above: <strong>130h04’</strong> (123h36’) (126h33’)</p>\n\n\n\n<p class=\"wp-block-paragraph\">– Percentage: <strong>77.3%</strong> (73.5%) (75.2%)</p>\n\n\n\n<p class=\"wp-block-paragraph\">Now that I can create databases easily I’ll create an app to track and do the maths on my habits automatically. In terms of database design it’s quite simples because it’s just a bunch of numbers without complex inter table relationships. </p>\n\n\n\n<p class=\"wp-block-paragraph\">PS: I’m in the end of a 16h fast and I feel fantastic! 🤗</p>\n\n\n\n<p class=\"wp-block-paragraph\"></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31039,
            Title = "LEGACY: Senna and my love for Databases",
            Slug = "senna-and-my-love-for-databases",
            Description = "Clearly I’ve been struggling to post but at least it’s not out of laziness. I just want to use all my free time to code. Or at least I like to think so, but when I look at my tr...",
            CardImgUrl = "legacy-senna-and-my-love-for-databases.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/09/27/senna-and-my-love-for-databases/",
            ReleaseDate = new DateTime(2020, 9, 27),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">Clearly I’ve been struggling to post but at least it’s not out of laziness. I just want to use all my free time to code. Or at least I like to think so, but when I look at my tracker I’m always able to find 6 to 7 weekly procrastination hours. </p>\n\n\n\n<p class=\"wp-block-paragraph\">Last week my numbers weren’t too bad. Here’s some data with the previous weak in brackets.</p>\n\n\n\n<p class=\"wp-block-paragraph\">&#8211; Coding: 23h56’ (26h19’)</p>\n\n\n\n<p class=\"wp-block-paragraph\">&#8211; Sleep: 44h01’ (44h02’)</p>\n\n\n\n<p class=\"wp-block-paragraph\">&#8211; Commute: 16h36’ (15h35’). This isn’t counting the hours in which I’m coding in the train </p>\n\n\n\n<p class=\"wp-block-paragraph\">&#8211; Social: 11h28’ (6h27’)</p>\n\n\n\n<p class=\"wp-block-paragraph\">&#8211; Work: 27h35’ (34h10’)</p>\n\n\n\n<p class=\"wp-block-paragraph\">&#8211; All of the above: 123h36’ (126h33’)</p>\n\n\n\n<p class=\"wp-block-paragraph\">&#8211; Percentage: 73.5% (75.2%)</p>\n\n\n\n<p class=\"wp-block-paragraph\">It was an excellent week in terms of coding progress. I haven’t got much done concretely but I’ve gotten way better at understand how .Net API works with a few excellent Pluralsight courses combined with an the good old Udemy “<a href=\"https://www.udemy.com/course/learn-to-build-an-e-commerce-app-with-net-core-and-angular\">Building an E-Commerce</a>” course.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I’ve also dig into database design on Pluralsight. I absolutely love working with data. I remember having spreadsheets for everything since childhood. It was always part of the way my brain operates.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Being a Formula 1 fan in my early days I remember getting dad to draw a table so I could mark the points for the races I would organise with my plastic F1 car. Obviously I was biased and Senna always managed to win 😆. Later I learned to design the tables myself. Good old times of no serious preoccupations!</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Life vs Coding</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">My relationships are suffering a bit because of my current life set up. I&#8217;m in Sunshine Coast for half the week and when I&#8217;m in Brisbane, I&#8217;m mostly coding. So I haven&#8217;t been able to call my family regularly or catch up with my best friend as I was doing before. But I think the friendships that matter will stand the test of time. I&#8217;d rather be a bit selfish now so I have more to offer later on. </p>\n\n\n\n<p class=\"wp-block-paragraph\">I do miss writing though. I have to find the time to write at least every second day. New challenge? 😀</p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31040,
            Title = "LEGACY: 28hs of Coding",
            Slug = "28hs-of-coding",
            Description = "Hi! I’m trying to blog while in the bus. Usually I get motion sickness from looking at my phone in buses (doesn’t happen in trains) but I have to try it so I can blog more often...",
            CardImgUrl = "legacy-28hs-of-coding.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/09/16/28hs-of-coding/",
            ReleaseDate = new DateTime(2020, 9, 16),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">Hi! I’m trying to blog while in the bus. Usually I get motion sickness from looking at my phone in buses (doesn’t happen in trains) but I have to try it so I can blog more often. Let’s see how it goes.</p>\n\n\n\n<p class=\"wp-block-paragraph\">After a very exhausting weekend dedicated to work for the most part, the week started with a couple of successful coding days of 4 hours each. So my objective will be to code for 28hs in the week, which is a good starting point if I actually want to become a decent programmer.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I’m back to my first .Net tutorial. I gave up on it after a few days having realised I need a better foundation in c# and after a few months of courses, tutorials and creating small applications I’m coming back to it with a way better understanding of what’s going on. </p>\n\n\n\n<p class=\"wp-block-paragraph\">In this tutorial, the excellent Neil Cummings uses the repository design pattern to create an asp.net project with an api (creating controllers from scratch) and later attaches an angular front-end to it.</p>\n\n\n\n<p class=\"wp-block-paragraph\">So yeah after the long winding road of figuring out .Net I’m finally creating the application for my apprenticeship. It will be interesting to see how it will fit into the architecture of the whole application. It will be great to learn how to work in a team.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Fasting</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">On Sunday I ate pretty early, at 11am but it was after a huge Saturday where I fasted for 20hs and I felt very week so I didn’t want to push for another day, especially because I had to teach for four hours in the end of the fasting period.</p>\n\n\n\n<p class=\"wp-block-paragraph\">But I can see the results of teaching my body to use fat so I’ll keep experimenting. I’m definitely fasting for at least 12hs everyday and the next step is to have a couple of 20hs days, slowly pushing my limit to 24 to 36hs periods.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Let’s see if I can get a 6-pack for the first time!!</p>\n\n\n\n<p class=\"wp-block-paragraph\"></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31041,
            Title = "LEGACY: Late Night Alumni",
            Slug = "late-night-alumni",
            Description = ".NET I had the Friday almost entirely free ahead of a massive Saturday of work in dance and I took the opportunity to get another five hours of coding in. I spent at least half...",
            CardImgUrl = "legacy-late-night-alumni.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/09/11/late-night-alumni/",
            ReleaseDate = new DateTime(2020, 9, 11),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\"><strong>.NET</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I had the Friday almost entirely free ahead of a massive Saturday of work in dance and I took the opportunity to get another five hours of coding in. I spent at least half the time debugging but I don&#8217;t consider it a waste of time, as all the time is spent looking at code, which makes .NET increasingly familiar. </p>\n\n\n\n<p class=\"wp-block-paragraph\">I skipped a few parts of the EF Core course that get into very specific tools so I could start the <a href=\"https://app.pluralsight.com/library/courses/cfb0434a-b851-417d-9f3a-8ecc2a194d02/table-of-contents\">C# Design Patterns</a> course to learn the repository pattern. I&#8217;ll probably go back to the EF course later to close the gaps. But I feel a certain urgency to start working on the project my mentor gave me, hence why I expedited things a little bit. I think I&#8217;ll be able to start working on the actual code for the project on Sunday after finishing the repository course so I can have a meeting with my mentor possibly on Sunday with the API ready to go and aiming to having it integrated to his system.</p>\n\n\n\n<p class=\"wp-block-paragraph\">That&#8217;s the beauty of the repository pattern. I&#8217;ll be able to use interfaces coded by him years go to avoid code repetition. It&#8217;s a beautiful concept and I&#8217;m looking forward to learn more about it. I&#8217;ll probably create my own project in parallel to get fluency in the concept.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Fasting</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Today I achieve 17hs of fasting and I felt fantastic for the most part. I&#8217;m still very hungry at around lunch time but I&#8217;m getting used to it and I don&#8217;t have collateral effects like dizziness or headaches. I&#8217;m also lifting the same loads I used to lift (in some exercises). </p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;ve  realised that low-intensity exercise doesn&#8217;t do any harm. I&#8217;ve danced for a couple of hours yesterday and today while fasting and felt great. Tomorrow I&#8217;ll teach for five straight hours in the end of my fasting and will probably only eat after 18hs. It will be an interesting test.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>In The Zone</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;ve gotten pretty good at choosing the right audio inputs for my day. If I want to feel productive and focused I play my &#8220;Lounge&#8221; playlist. It&#8217;s my &#8220;in the zone&#8221; list and it sharpens my mind. In the mornings or when I&#8217;m allowing myself to relax a little bit, my go to is my &#8220;Road Trip&#8221; list. And right now I&#8217;m working on my &#8220;Night Time&#8221; playlist, having rediscovered the amazing Late Night Alumni band, a good old favourite from my poker days in the beginning of the last decade. See links below. </p>\n\n\n\n<p class=\"wp-block-paragraph\">Time to sleep!! </p>\n\n\n\n<div class=\"wp-block-group\"><div class=\"wp-block-group__inner-container is-layout-flow wp-block-group-is-layout-flow\">\n<figure class=\"wp-block-embed is-type-rich is-provider-spotify wp-block-embed-spotify wp-embed-aspect-9-16 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<div class=\"embed-spotify\"><iframe title=\"Spotify Embed: Night Time\" style=\"border-radius: 12px\" width=\"100%\" height=\"352\" frameborder=\"0\" allowfullscreen allow=\"autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture\" loading=\"lazy\" src=\"https://open.spotify.com/embed/playlist/5SHFpBv28apm5XWXRS9SGi?utm_source=oembed\"></iframe></div>\n</div></figure>\n\n\n\n<p class=\"wp-block-paragraph\"></p>\n</div></div>\n\n\n\n<figure class=\"wp-block-embed is-type-rich is-provider-spotify wp-block-embed-spotify wp-embed-aspect-9-16 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<div class=\"embed-spotify\"><iframe title=\"Spotify Embed: Lounge\" style=\"border-radius: 12px\" width=\"100%\" height=\"352\" frameborder=\"0\" allowfullscreen allow=\"autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture\" loading=\"lazy\" src=\"https://open.spotify.com/embed/playlist/6C5zSD0JxViBkTZmfTNlZV?si=AZcGUQWCQA6k2Gf4_NZukA&amp;utm_source=oembed\"></iframe></div>\n</div></figure>\n\n\n\n<figure class=\"wp-block-embed is-type-rich is-provider-spotify wp-block-embed-spotify wp-embed-aspect-9-16 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<div class=\"embed-spotify\"><iframe title=\"Spotify Embed: Road Trip\" style=\"border-radius: 12px\" width=\"100%\" height=\"352\" frameborder=\"0\" allowfullscreen allow=\"autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture\" loading=\"lazy\" src=\"https://open.spotify.com/embed/playlist/5n1H0KkwpCodJTrLUaYgmj?si=lTsldVhnQRm3CEAjH-iB9A&amp;utm_source=oembed\"></iframe></div>\n</div></figure>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31042,
            Title = "LEGACY: Julie Lerman",
            Slug = "julie-lerman",
            Description = "My current routine has been preventing me from posting daily. I’ve been coding in the mornings and going to the gym at night (usually after teaching), which means I’m truly exha...",
            CardImgUrl = "legacy-julie-lerman.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/09/10/julie-lerman/",
            ReleaseDate = new DateTime(2020, 9, 10),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">My current routine has been preventing me from posting daily. I&#8217;ve been coding in the mornings and going to the gym at night (usually after teaching), which means I&#8217;m truly exhausted by the end of the day. When I first started this blog I&#8217;d post first thing in the morning, but right now all I want when I wake up is dive into coding, hence why I haven&#8217;t been posting so much. But yes, in the ideal world, this would be a daily practice.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>.Net learning</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">This week has been very productive in terms of learning but not so much in terms of getting things done.  But that&#8217;s ok, I&#8217;m laying the foundations of knowledge for the app I need to create. Right now I&#8217;m diving into the excellent <a href=\"https://app.pluralsight.com/library/courses/c99828cd-6812-41f9-bf1c-3ce2227b9a89/table-of-contents\">Entity Framework Core: Getting Started</a>, by the amazing teacher <a href=\"https://rd.microsoft.com/en-us/julie-lerman\">Julie Lerman</a>. Her explanations have a clarity that I envy and I will definitely try to emulate in my own teachings. I&#8217;ve managed to code for more than five hours twice in a row, which is great!</p>\n\n\n\n<p class=\"wp-block-paragraph\">This course will be followed by another course on Repository Design Pattern, which is one of the most common patterns for C# and it&#8217;s the one it&#8217;s required by my mentor for this app. I tried to start straight with this course, but had to go back into the EF Core course because it was clear I was lacking depth, even though I&#8217;ve had used it before.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Fasting</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;ve been experimenting with fasting and I&#8217;m absolutely loving it. I haven&#8217;t done anything overly hardcore yet but I haven&#8217;t had breakfast for about 10 days now, having fasted for periods ranging from 12 to 16 hours every day. Today I had decided to push into the 18 hours territory but I got offered an irrecusable vegan pizza for free and I just couldn&#8217;t not let it go. </p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;ve already leaned down a little bit but my looks are still acceptable. I&#8217;m an endomorph (aka skinny) so I&#8217;m afraid decreasing my body fat will make me look starved but since it&#8217;s not an irreversible thing I&#8217;m willing to give it a shot. If I end up looking like Gandhi I can always get back to eating hard and putting weight back on.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Ok time to get ready to sleep so I can start coding early tomorrow!! 😴</p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31043,
            Title = "LEGACY: September Repo",
            Slug = "september-repo",
            Description = "Here I’ll be updating the list of inputs I’ve been exposed to in September Movies/TV Shows Podcasts: https://open.spotify.com/episode/5opXot5kVBNSEzQPiEJ2DB?si=Wra2Q9gESm-B7e2Z8...",
            CardImgUrl = "legacy-september-repo.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/09/08/september-repo/",
            ReleaseDate = new DateTime(2020, 9, 8),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">Here I’ll be updating the list of inputs I’ve been exposed to in September</p>\n\n\n\n<p class=\"wp-block-paragraph\">Movies/TV Shows</p>\n\n\n\n<p class=\"wp-block-paragraph\"><span class=\"embed-youtube\" style=\"text-align:center; display: block;\"><iframe loading=\"lazy\" class=\"youtube-player\" width=\"723\" height=\"407\" src=\"https://www.youtube.com/embed/L3pk_TBkihU?version=3&#038;rel=1&#038;showsearch=0&#038;showinfo=1&#038;iv_load_policy=1&#038;fs=1&#038;hl=en&#038;autohide=2&#038;wmode=transparent\" allowfullscreen=\"true\" style=\"border:0;\" sandbox=\"allow-scripts allow-same-origin allow-popups allow-presentation allow-popups-to-escape-sandbox\"></iframe></span></p>\n\n\n\n<p class=\"wp-block-paragraph\"></p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Podcasts</strong>:</p>\n\n\n\n<p class=\"wp-block-paragraph\"><a href=\"https://open.spotify.com/episode/5opXot5kVBNSEzQPiEJ2DB?si=Wra2Q9gESm-B7e2Z8AW_dg\" rel=\"nofollow\">https://open.spotify.com/episode/5opXot5kVBNSEzQPiEJ2DB?si=Wra2Q9gESm-B7e2Z8AW_dg</a></p>\n\n\n\n<p class=\"wp-block-paragraph\"><a href=\"https://open.spotify.com/episode/44Hb8H4Imp2ylpZQ5BQ8g7?si=EI_W1Z7XSmK-JYBDT6BAeQ\" rel=\"nofollow\">https://open.spotify.com/episode/44Hb8H4Imp2ylpZQ5BQ8g7?si=EI_W1Z7XSmK-JYBDT6BAeQ</a></p>\n\n\n\n<p class=\"wp-block-paragraph\"><a href=\"https://open.spotify.com/episode/3CtdbUP6w1O1qZ86QxPfAw?si=pC2ueVNWRUKdMO0_CWwydg\" rel=\"nofollow\">https://open.spotify.com/episode/3CtdbUP6w1O1qZ86QxPfAw?si=pC2ueVNWRUKdMO0_CWwydg</a></p>\n\n\n\n<p class=\"wp-block-paragraph\"><a href=\"https://open.spotify.com/episode/3HBsuAW54lFsf9x0RV0t8u?si=DPp4Kw99QkWtzwnn-fYbVw\" rel=\"nofollow\">https://open.spotify.com/episode/3HBsuAW54lFsf9x0RV0t8u?si=DPp4Kw99QkWtzwnn-fYbVw</a></p>\n\n\n\n<p class=\"wp-block-paragraph\"><a href=\"https://open.spotify.com/episode/2RAA7aGd7u0AISB6ra2Mlo?si=S4lU1w2QQGqTHhVf_Qcogg\" rel=\"nofollow\">https://open.spotify.com/episode/2RAA7aGd7u0AISB6ra2Mlo?si=S4lU1w2QQGqTHhVf_Qcogg</a></p>\n\n\n\n<p class=\"wp-block-paragraph\"><a href=\"https://open.spotify.com/episode/1i6d2w3FsaO3BuwUhkvLXE?si=ztun9rhSSzqSHqSvi6Dq1g\" rel=\"nofollow\">https://open.spotify.com/episode/1i6d2w3FsaO3BuwUhkvLXE?si=ztun9rhSSzqSHqSvi6Dq1g</a></p>\n\n\n\n<p class=\"wp-block-paragraph\"><a href=\"https://open.spotify.com/episode/0fUXN3jjYrDhsDxIGjZRNT?si=1danq0LARH-C25RpmW4Otg\" rel=\"nofollow\">https://open.spotify.com/episode/0fUXN3jjYrDhsDxIGjZRNT?si=1danq0LARH-C25RpmW4Otg</a></p>\n\n\n\n<p class=\"wp-block-paragraph\"><a href=\"https://open.spotify.com/episode/3pB5yvSD7XIxzK2xdN8Pp4?si=6wsExxQvQaSnwC0xbNh9Jg\" rel=\"nofollow\">https://open.spotify.com/episode/3pB5yvSD7XIxzK2xdN8Pp4?si=6wsExxQvQaSnwC0xbNh9Jg</a></p>\n\n\n\n<p class=\"wp-block-paragraph\"></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31044,
            Title = "LEGACY: Tenet",
            Slug = "tenet",
            Description = "Wednesday is my only day off so I was planning to code all day but in the morning I got confronted with severe storage issues on my Macbook Air. When I bought it last November I...",
            CardImgUrl = "legacy-tenet.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/09/03/tenet/",
            ReleaseDate = new DateTime(2020, 9, 3),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">Wednesday is my only day off so I was planning to code all day but in the morning I got confronted with severe storage issues on my Macbook Air. When I bought it last November I had no idea I would need so much space for coding. But with the 50gb Parallels occupy I&#8217;ve been spending a lot of time in the past month fighting for megabytes and it&#8217;s become a bottleneck for my coding work.</p>\n\n\n\n<p class=\"wp-block-paragraph\">So I bought a new computer. It&#8217;s exactly the same I have right now, a <a href=\"https://www.officeworks.com.au/shop/officeworks/p/macbook-air-13-3-1-1ghz-512gb-space-grey-mba20512sg\">Macbook Air</a>, but the 2020 version and this time with 512gb of space. I assume it will be enough to carry me through the next couple of years. The only problem is that after this purchase I&#8217;m absolutely broke. I used all of the savings I had created after having gone broke due to Covid. I&#8217;m not overly upset about it because it&#8217;s an investment, but it doesn&#8217;t feel fantastic to have zero dollars (again). So it&#8217;s time to restart!!!</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Tenet</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;ve also used my day off to spend time with a few friends and to go to the movies for the first time in about 18 months. I watched Christopher Nolan&#8217;s last movie, Tenet. It was great to be back at the movie theatre! I loved the movie, but I didn&#8217;t like the general experience. I explain. Because the plot is so intricate it was impossible to figure out what was going on from about 30&#8242; into it. I knew from the beginning this was the type of production that I&#8217;d have to watch again, pausing and going back and forth to make sense of it. I&#8217;ll probably do it at some point. </p>\n\n\n\n<figure class=\"wp-block-embed-youtube wp-block-embed is-type-rich wp-embed-aspect-16-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<span class=\"embed-youtube\" style=\"text-align:center; display: block;\"><iframe loading=\"lazy\" class=\"youtube-player\" width=\"723\" height=\"407\" src=\"https://www.youtube.com/embed/L3pk_TBkihU?version=3&#038;rel=1&#038;showsearch=0&#038;showinfo=1&#038;iv_load_policy=1&#038;fs=1&#038;hl=en&#038;autohide=2&#038;wmode=transparent\" allowfullscreen=\"true\" style=\"border:0;\" sandbox=\"allow-scripts allow-same-origin allow-popups allow-presentation allow-popups-to-escape-sandbox\"></iframe></span>\n</div></figure>\n\n\n\n<p class=\"wp-block-paragraph\"></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31045,
            Title = "LEGACY: Database Normalisation",
            Slug = "database-normalisation",
            Description = "In the first day of the month I spent my coding time looking at Pluralsight’s database design course, more specifically the database normalisation part. It’s a fascinating topic...",
            CardImgUrl = "legacy-database-normalisation.png",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/09/02/database-normalisation/",
            ReleaseDate = new DateTime(2020, 9, 2),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">In the first day of the month I spent my coding time looking at Pluralsight&#8217;s database design course, more specifically the database normalisation part. It&#8217;s a fascinating topic. I love databases. It&#8217;s something I&#8217;ll definitely dive deep into. However there&#8217;s so much to it! I couldn&#8217;t quite get all the details of primary and foreign keys but I think it will come with more time of study and application.</p>\n\n\n\n<p class=\"wp-block-paragraph\">For my real life project, I&#8217;ve been fiddling with the database I have to create. In this first stage I&#8217;m getting more comfortable with Azure Data Studio and I&#8217;m trying to write as much code in SQL as possible so I become more fluent. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Space on My Computer</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;m REALLY struggling with space on my 128 GB Mac. It&#8217;s become almost impossible to work with Parallels and all the tools I have to install. I might have to spend all of my savings on an upgrade to make this thing happen. 😦</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Inputs</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Book</strong>: Benjaming Franklin: An American Life (Chapter 10)</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Podcasts</strong>: Biographics Ernest Hemingway, George S. Patton, John Lennon</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Records</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Coding time</strong>: 2:22</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Fasting Time</strong>: 12:07&#8242;</p>\n\n\n\n<p class=\"wp-block-paragraph\"></p>\n\n\n\n<p class=\"wp-block-paragraph\"></p>\n\n\n\n<p class=\"wp-block-paragraph\"></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31046,
            Title = "LEGACY: Hello, September!",
            Slug = "hello-september",
            Description = "Coding I’m super excited about the coming month. I’m finally working on a real project for a real company. I’ve created websites for individuals, a small business and an event b...",
            CardImgUrl = "legacy-hello-september.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/09/01/hello-september/",
            ReleaseDate = new DateTime(2020, 9, 1),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\"><strong>Coding</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;m super excited about the coming month. I&#8217;m finally working on a real project for a real company. I&#8217;ve created websites for individuals, a small business and an event before but this one feels like the real deal. The grown up stuff. It feels like now I&#8217;m hanging out with the big boys. 😀</p>\n\n\n\n<p class=\"wp-block-paragraph\">My first task in the real programming world is to create an application with Angular Material, C# and Azure. The idea is fairly simple. A database with an user interface to it. The complex part is to extract data from an Excel Sheet into the database. So I guess in the first few days the objective is just to get the CRUD Application going and then I&#8217;ll deal with the extracting, hopefully by the weekend.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Backlogging</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">My personal project for this month is to create a back log of inputs in this blog. What does it mean? It means I&#8217;ll be keeping one post with the summary of some of the stuff I&#8217;ve done during the month. It will be updated every time I update the blog. It will be a list with all the videos, podcasts, books, songs and any other form of input I have in the month. </p>\n\n\n\n<p class=\"wp-block-paragraph\">The idea is to easily track this stuff back so I can send it to my friends (I&#8217;m always recommending songs, books and podcasts) and also to keep a record for myself. </p>\n\n\n\n<p class=\"wp-block-paragraph\">The idea is part of a bigger project, which is to track all my activities using software programmed by me. </p>\n\n\n\n<p class=\"wp-block-paragraph\">Well!!! Time to start!! Be back later!</p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31047,
            Title = "LEGACY: Bad Sleep",
            Slug = "bad-sleep",
            Description = "Lately I have intensified my social life to the detriment of my health. That phrase sounds like it would come out of a drunkard’s mouth but the foe in this case is caffeine. Sin...",
            CardImgUrl = "legacy-bad-sleep.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/08/16/bad-sleep/",
            ReleaseDate = new DateTime(2020, 8, 16),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">Lately I have intensified my social life to the detriment of my health. That phrase sounds like it would come out of a drunkard&#8217;s mouth but the foe in this case is caffeine. Since I moved to Toowong I found great cafes to have conversations with friends. My favourite is The Boundary Hotel in West End. All would be alright if it wasn&#8217;t for the fact that if I have a catch up at 6pm I&#8217;ll still drink coffee and that is absolutely ruining my sleep. I haven&#8217;t slept for more than 6 hours in a long time and last night I had less than four. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>.NET Training</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Today I finalised my Angular ASP.NET app. It&#8217;s actually super simple, but my focus now is to deploy it to Azure. This will be my sole focus this week and I won&#8217;t rest until I get there. Right now I literally have zero idea of how to go about it. All I know is I need an Azure account haha. Fun times ahead.</p>\n\n\n\n<p class=\"wp-block-paragraph\"></p>\n\n\n\n<p class=\"wp-block-paragraph\"></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31048,
            Title = "LEGACY: Clarity",
            Slug = "clarity",
            Description = "The last couple of days were fantastic. I was able to change my routines dramatically and get closer to an ideal environment for coding. I’m 100% motivated to get where I want a...",
            CardImgUrl = "legacy-clarity.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/08/15/clarity/",
            ReleaseDate = new DateTime(2020, 8, 15),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">The last couple of days were fantastic. I was able to change my routines dramatically and get closer to an ideal environment for coding. I&#8217;m 100% motivated to get where I want and the more I&#8217;m in front of my computer the more it&#8217;s clear in my head. I&#8217;m also very excited about how much I have to learn and where I&#8217;ll be in a year, in regards to my knowledge. </p>\n\n\n\n<p class=\"wp-block-paragraph\">Being away from facebook for most of the day is a true blessing. I get to fully focus on the stuff I have to do without having my mind going into the conversations I&#8217;m having or whatever piece of news I read. I don&#8217;t want my social life to suffer ever again as it did for long periods of my life, but I&#8217;ll definitely follow through with a very regimented routine.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I haven&#8217;t been single for a long time but the upside of not having anyone is that I can allocate all the time in the world to whatever I want. I&#8217;ve also been working less hours to free up tons of time blocks for coding. When I commute I&#8217;m either studying Italian or reading Reddit. I&#8217;m not checking social media on each break as it&#8217;s also very distracting. I&#8217;m basically checking it somewhere in the afternoon and a little bit at night and that&#8217;s it. Loving it!</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>.NET Training</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Today I took another step into Angular + .NET development. After my first painful experience, I cruised through a tutorial to create a CRUD API. It will be my second application in C# and I want to build up on it. But before creating more sophisticated logic I want to connect it to Azure. I see myself as an Angular + .NET + Azure developer in the future and the foundation is almost entirely laid. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Input</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Right now I&#8217;m listening to the massive audiobook on Benjamin Franklin. What a fascinating character! He seems to be one of the most influential historical figures in America, having touched in many aspects of American life and definitely having been responsible for shaping American values.</p>\n\n\n\n<p class=\"wp-block-paragraph\">My latest podcast, still unfinished, Tim Ferriss&#8217; show with Bob Metcalfe, the creator of Ethernet, and a bunch of short biographical ones: Herman Goering, Idi Amin, John McAfee, Mark Zuckerberg, Timothy McVeigh. Such a great series of podcasts! Short and super informative. Can&#8217;t wait for tomorrow&#8217;s on Pancho Villa. </p>\n\n\n\n<p class=\"wp-block-paragraph\"></p>\n\n\n\n<p class=\"wp-block-paragraph\"></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31049,
            Title = "LEGACY: C# Collections",
            Slug = "c-collections",
            Description = "Yesterday I had an excellent day of teaching. My classes in Sunshine Coast (Queensland, Australia) aren’t big, but I do have a very loyal student base that makes me very happy....",
            CardImgUrl = "legacy-c-collections.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/08/14/c-collections/",
            ReleaseDate = new DateTime(2020, 8, 14),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">Yesterday I had an excellent day of teaching. My classes in Sunshine Coast (Queensland, Australia) aren&#8217;t big, but I do have a very loyal student base that makes me very happy. Next week we&#8217;re going to catch up for drinks for the first time since I started teaching there in December. Sunshine Coast is such a beautiful place and I&#8217;m glad I&#8217;m creating roots in that part of the world.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>.NET Training</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Yesterday I did a good job at avoiding distraction, as I discussed in my previous post. I did some studying during my commute in the train and when I was in the bus I did some research for my dance classes. No messenger, whatsapp, Instagram, anything. I did have to check messenger for work purposes, but other than that I was able to avoid being reactive instead of setting my own pace and thoughts. </p>\n\n\n\n<p class=\"wp-block-paragraph\">Instead of watching random Youtube videos or reading stupid news I downloaded Reddit App on my phone so I could read about .NET when I couldn&#8217;t be on my computer. There were a few interesting topics discussing architecture and dependency management. It&#8217;s every useful to read about the technologies I&#8217;m learning so I can fill the gaps in my knowledge and get used to the lingo. </p>\n\n\n\n<p class=\"wp-block-paragraph\">One of the things that I found overwhelming in this first month of .NET was the amount of options I had to start a project. I found tutorials using more than five Visual Studio templates to achieve the same things. But now that I&#8217;m reading more about it, I can better understand when to use what.</p>\n\n\n\n<p class=\"wp-block-paragraph\">On Pluralsight I started learning about collections. So far everything is very similar to Java Collections. Arrays and Lists seem to be identical. Today I&#8217;ll continue digging into collections and I&#8217;ll also study the architecture of the little Angular application I created. My main goal right now is to be able to create an Angular App with Azure. That will get me closer to where I need to be to become my friend&#8217;s apprentice. </p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31050,
            Title = "LEGACY: Dealing With Distraction",
            Slug = "dealing-with-distraction",
            Description = "I’ve been thinking about how to deal with the distractions technology allow us to have if we aren’t careful. The biggest one is obviously smartphones. Today I was listening to a...",
            CardImgUrl = "legacy-dealing-with-distraction.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/08/13/dealing-with-distraction/",
            ReleaseDate = new DateTime(2020, 8, 13),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">I&#8217;ve been thinking about how to deal with the distractions technology allow us to have if we aren&#8217;t careful. The biggest one is obviously smartphones. Today I was listening to an interview with Elon Musk on Joe Rogan&#8217;s podcast and Musk said we&#8217;re already half-cyborgs, connected all the time to this super computer, the smartphone. It&#8217;s a great way to see it.</p>\n\n\n\n<p class=\"wp-block-paragraph\">The problem is that in this super computer we have access to social media and news and all of the involved in them are fighting really hard for attention. Basically we live in a big &#8220;Look at me&#8221; culture, enabled by such powerful devices.</p>\n\n\n\n<p class=\"wp-block-paragraph\">To be able to use my time meaningfully in the most optimal way I think we have to carefully design our environment so that we&#8217;re not drawn into these attention-seeking blackholes. Example: By turning notifications off we have more agency over how our time is spent on our phone. I&#8217;m not constantly reacting to other people, but I&#8217;m choosing when to become reactive. It&#8217;s a subtle change with big implications. </p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;ve been successful in implementing some of these changes in the past. I&#8217;ve been generally good at allocating my time to meaningful things. Most of my time is spent working, sleeping, coding or socialising. If I remove basic survival activities like preparing food and commuting, I don&#8217;t spend a lot of time with distractions such as movies or just scrolling on my phone. </p>\n\n\n\n<p class=\"wp-block-paragraph\">But the problem is even having my phone around allows me to take a quick look at it for whatever reason while I&#8217;m coding, which takes from the quality of my work. If I check my messages chances are I&#8217;ll be thinking about its contents even when I get back to coding. If it&#8217;s a bad message it might ruin my coding time altogether. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Nightmare</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">In the worst case scenario, checking my phone when I shouldn&#8217;t can be the lead domino to a series of things that will compound and culminate in a couple of ruined days. Recently it happened twice. Checking the news over the Beirut explosion and a horrible crime in Sydney, Australia made me lose at least four hours across a few days checking the follow-up stories to those stories. </p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;m positive my success as a coder will be dramatically accelerated if I aggressively tackle distraction. For that I&#8217;ll set some boundaries and stick to them religiously. I&#8217;ll develop a list of &#8220;Commandments&#8221; for that. This is my first commandment:</p>\n\n\n\n<ul class=\"wp-block-list\"><li>&#8220;<strong>THOU SHALL NOT &#8220;CHECK&#8221; ON YOUR PHONE</strong>&#8221; &#8211; Meaning no news, social media or e-mails in blocks of time dedicated to coding. Example: If on my calendar coding goes from 7am to 2pm all social media will be DELETE FROM MY PHONE and news websites BLOCKED FROM MY COMPUTER AND MY PHONE. No exceptions allowed. There&#8217;s nothing so urgent to be checked that can&#8217;t wait till 2pm. </li><li>&#8220;<strong>THOU SHALL ONLY &#8220;CHECK&#8221; SOCIAL MEDIA DURING COMMUTE</strong>&#8221; &#8211; The exception is if I&#8217;m riding my bike to or from work. Then I&#8217;ll allow myself to be on social media and news when I arrive on my destination. But at work it&#8217;s gone again. I might elect small chunks of time for batching social media as I need it for work but then it&#8217;s gone. It HAS TO GO. </li></ul>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>This Blog</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I think there&#8217;s a lot of value in posting here daily. Not only for the future document this will become but also as an instrument for developing discipline. So I&#8217;ll try really hard to make it happen. </p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31051,
            Title = "LEGACY: Pluralsight",
            Slug = "pluralsight",
            Description = ".NET training Hey folks! I’m very happy to have found pluralsight.com. I’ve started taking the C# fundamentals course and the teaching is fantastic. You can tell the instructor...",
            CardImgUrl = "legacy-pluralsight.jpeg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/08/08/pluralsight/",
            ReleaseDate = new DateTime(2020, 8, 8),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\"><strong>.NET training</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Hey folks! I&#8217;m very happy to have found pluralsight.com. I&#8217;ve started taking the C# fundamentals course and the teaching is fantastic. You can tell the instructor isn&#8217;t only a programmer but an experienced educator. I love the course. I&#8217;m flying through it because the syntax is so similar to Java, but we are getting into delegates and IDisposable, stuff that I&#8217;ve never seen before, so it should get fun soon.</p>\n\n\n\n<p class=\"wp-block-paragraph\">During the past couple of days I&#8217;ve been fiddling with Azure and I&#8217;ve also back to Windows Forms to enhance my budget application. I&#8217;m learning that it&#8217;s so important to document the code. Sometimes I go back into an old app and I&#8217;m completely lost. Not only I should be careful enough to create detailed docs but also links to the tutorials I used to learn. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Input</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Usually when I write here I&#8217;m already exhausted and all I want to do is go to bed, that&#8217;s why I&#8217;m not posting in detail about the long podcasts I&#8217;ve been listening to. My latest discover is a very interesting Biographies podcast. I&#8217;ve started listening to it from the oldest. The first two were about <a href=\"https://en.wikipedia.org/wiki/Hermann_G%C3%B6ring\">Hermann Göring</a> and Idi Amin, two of the most horrific killers of history. But the podcasts are short but yet rich. It&#8217;s worth it!</p>\n\n\n\n<figure class=\"wp-block-embed-spotify wp-block-embed is-type-rich wp-embed-aspect-21-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<a href=\"https://open.spotify.com/show/0JzjzwJcRqFZ3BcACtahh8\" rel=\"nofollow\">https://open.spotify.com/show/0JzjzwJcRqFZ3BcACtahh8</a>\n</div></figure>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31052,
            Title = "LEGACY: One of those days",
            Slug = "one-of-those-days",
            Description = "The problem I’m pretty sure everyone teaching themselves anything, and especially coding, had days where they felt overwhelmed or lost. I don’t feel like that all the time but i...",
            CardImgUrl = "legacy-one-of-those-days.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/08/05/one-of-those-days/",
            ReleaseDate = new DateTime(2020, 8, 5),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\"><strong>The problem</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;m pretty sure everyone teaching themselves anything, and especially coding, had days where they felt overwhelmed or lost. I don&#8217;t feel like that all the time but it&#8217;s definitely not a rare feeling. </p>\n\n\n\n<p class=\"wp-block-paragraph\">In the past year I&#8217;ve been exposed to so many new technologies that I&#8217;m still finding it hard to understand what to pick in lots of circumstances. When I finish a tutorial or a small project I often get lost in deciding what will be next and what&#8217;s the best way to go about it. Often I start tutorials and abandon straight away if I understand the technology is outdated or the tutorial is irrelevant. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Solutions</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;ve come up with two ideas to mitigate these issues. One of them is to spend more time in forums like reddit and quora. There&#8217;s so much going on in these spaces at any given time. Just reading other people&#8217;s questions makes me thing of many things I wasn&#8217;t aware of. And often times the questions are similar to mine or in an adjacent sphere of interest or difficulty. </p>\n\n\n\n<p class=\"wp-block-paragraph\">The second is too seek the structure of an online learning platform. Although I love Udemy courses, they can also take you in a million directions with all different and disconnected approaches. So I&#8217;ve decided to jump into Windows Learn, which is free and has a bunch of learning resources. That will be a preparation for joining Pluralsight, the most recommended platform in my research.</p>\n\n\n\n<p class=\"wp-block-paragraph\">All of that will be done while I&#8217;m working on a project. If there&#8217;s something I learned in this journey so far is that I need to be building something. I have motivation to learn at any time but If I&#8217;m building, that motivation is increased significantly. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Life is Good</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Life is good at the moment. I&#8217;ve been very social lately, catching up with a lot of friends for coffee. Also haven&#8217;t skipped gym for five days since last weekends mini-crisis and sleep/nutrition are back on track. I&#8217;ve also got a heater so now I can avoid the coldest times of the day. </p>\n\n\n\n<p class=\"wp-block-paragraph\">I still find managing my days pretty hard. I end up not doing things I want or should do for pure lack of planning or distractions that are time-costly. But at least I learned to let go. I don&#8217;t get depressed if I don&#8217;t update the blog every day but I&#8217;m able to do everything frequently enough without having to cram everything into 24hs. </p>\n\n\n\n<p class=\"wp-block-paragraph\">But If I ever fall into any mental rabbit hole, all I have to do is remind myself of 11th of June of 2020, the day when I got my PR and what that represents. Everything will turn out alright, even if I have some less than great days.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Input</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">In the past month I&#8217;ve been jumping around a bit with Podcasts: Tim Ferriss, Jocko, Dan Carlin and more recently, Jordan Peterson. I&#8217;ve also engaged in a Computer Science series on Youtube and my new favourite is School of Life, specifically the Relationships channel. So many good insights. Practical, simple, down-to-earth applied philosophy. I&#8217;ll be posting some of them here. I highly highly (yeah, two highlies) recommend.</p>\n\n\n\n<figure class=\"wp-block-embed-youtube wp-block-embed is-type-rich wp-embed-aspect-16-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<span class=\"embed-youtube\" style=\"text-align:center; display: block;\"><iframe loading=\"lazy\" class=\"youtube-player\" width=\"723\" height=\"407\" src=\"https://www.youtube.com/embed/dh43cVtfMYs?version=3&#038;rel=1&#038;showsearch=0&#038;showinfo=1&#038;iv_load_policy=1&#038;fs=1&#038;hl=en&#038;autohide=2&#038;start=1&#038;wmode=transparent\" allowfullscreen=\"true\" style=\"border:0;\" sandbox=\"allow-scripts allow-same-origin allow-popups allow-presentation allow-popups-to-escape-sandbox\"></iframe></span>\n</div></figure>\n\n\n\n<p class=\"wp-block-paragraph\"> </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Mini-challenge</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I have two mini-challenges for tomorrow</p>\n\n\n\n<p class=\"wp-block-paragraph\">The first is not to text anyone or read any news before 12pm. The second is to register track my activities a few times a day instead of just one for accuracy purposes. </p>\n\n\n\n<p class=\"wp-block-paragraph\"></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31053,
            Title = "LEGACY: Jordan Peterson",
            Slug = "jordan-peterson",
            Description = "I finally fixed the problem I was having to get an Angular app to work with a .NET back end. That made my day. I’ve been battling this problem since last Wednesday and it was ha...",
            CardImgUrl = "legacy-jordan-peterson.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/08/03/jordan-peterson/",
            ReleaseDate = new DateTime(2020, 8, 3),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\"> I finally fixed the problem I was having to get an Angular app to work with a .NET back end. That made my day. I&#8217;ve been battling this problem since last Wednesday and it was hard to the debug because it was so obvious nobody even talked about it on the internet. </p>\n\n\n\n<p class=\"wp-block-paragraph\">What happened was that the tutorials I was following used Visual Studio Code for Angular and Visual Studio for C# and I didn&#8217;t use VSC in Windows. That means that I was serving the view on Mac, trying to send data with the help of a CORS package to the back end in Windows. Of course it was never going to help. I don&#8217;t think many people had this stupid idea before, hence why the problem wasn&#8217;t discussed over the internet. But I realised there was something fundamentally wrong after fiddling with both the front-end and back-end for many hours without moving forward an inch.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Now I understand how to connect Angular to the back-end in C#. The next step is to connect Azure to the equation. Which means I&#8217;ll know the basics of the technology interactions I need to know to become my friend&#8217;s apprentice. I still have to learn a lot about RxJS, but that will be after dealing with Azure. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Social Gatherings</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Yesterday I had my third social gathering after getting my visa and It&#8217;s impossible to ignore the positive effect of such activities on me. I&#8217;ve learned the importance of belonging to a group as a key component of happiness but it&#8217;s my first time experimenting it purposefully, with the awareness of what it does. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Jordan Peterson</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\"> Today I had coffee with a friend and he told me the impact of Jordan Peterson&#8217;s work on his life. It&#8217;s a friend whose endorsements I value highly, so I had to check it out. I had heard about his work from other sources so I listened to his the first episode of his podcast on Spotify and half the second.</p>\n\n\n\n<p class=\"wp-block-paragraph\">There&#8217;s no bullshit. He goes straight to the point discussing life&#8217;s dilemmas based on a very well-rounded theoretical standpoint. It sounds to me he&#8217;s trained both in philosophy and psychology, but I could be wrong. His knowledge is impressive but even more so is his ability to express it. I&#8217;ll definitely be touching on his work very frequently in this blog.</p>\n\n\n\n<figure class=\"wp-block-embed-spotify wp-block-embed is-type-rich wp-embed-aspect-21-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<div class=\"embed-spotify\"><iframe title=\"Spotify Embed: Reality and the Sacred\" style=\"border-radius: 12px\" width=\"100%\" height=\"152\" frameborder=\"0\" allowfullscreen allow=\"autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture\" loading=\"lazy\" src=\"https://open.spotify.com/embed/episode/38YGcRf7600HRKaSv3ZkYj?utm_source=oembed\"></iframe></div>\n</div></figure>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31054,
            Title = "LEGACY: Stuck with Angular + .Net",
            Slug = "stuck-with-angular-net",
            Description = "I’ve broken a negative record and haven’t posted for four days in a row. Not posting was just one of the cracks I had in my routine during the past four days. I’ve also missed t...",
            CardImgUrl = "legacy-stuck-with-angular-net.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/08/01/stuck-with-angular-net/",
            ReleaseDate = new DateTime(2020, 8, 1),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">I&#8217;ve broken a negative record and haven&#8217;t posted for four days in a row. Not posting was just one of the cracks I had in my routine during the past four days. I&#8217;ve also missed two gym days in a row and my bedroom was as disorganised as it&#8217;s ever been since I got my visa. </p>\n\n\n\n<p class=\"wp-block-paragraph\">I don&#8217;t think there was only one reason for the debacle but I suspect the biggest one was the persistent frustration I&#8217;ve been facing in coding. Since Wednesday night I&#8217;ve been stuck with two Angular + .Net Tutorials. I created the APIs (with C# .Net), created the front-end with Angular and I can&#8217;t seem to get them to work together. On a side note, I really missed working with Angular! It&#8217;s actually so much fun!</p>\n\n\n\n<p class=\"wp-block-paragraph\">However today I think I had a theoretical breakthrough and it came to me what I have to do. I won&#8217;t celebrate too early though. The idea came right before work, so I had to leave. But tomorrow If I have some free time I&#8217;ll try to finally make this happen. I&#8217;ve been losing my sleep over this issue. </p>\n\n\n\n<p class=\"wp-block-paragraph\">Here are two stackoverflow posts about the issues:</p>\n\n\n\n<p class=\"wp-block-paragraph\"><a href=\"https://stackoverflow.com/questions/63146264/err-connection-refused-asp-net-core-angular-10?noredirect=1#comment111760307_63146264\">https://stackoverflow.com/questions/63146264/err-connection-refused-asp-net-core-angular-10?noredirect=1#comment111760307_63146264</a></p>\n\n\n\n<p class=\"wp-block-paragraph\"><a href=\"https://stackoverflow.com/questions/63200640/angular-err-connection-refused-error-during-post-request/63201947#63201947\">https://stackoverflow.com/questions/63200640/angular-err-connection-refused-error-during-post-request/63201947#63201947</a></p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Back</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;m glad to be back. Writing here is important for my routine and is a good point of reference for the idea I have of being disciplined. I&#8217;m challenging myself to post everyday in August, but it will often be small posts as I&#8217;ll have some long days. </p>\n\n\n\n<p class=\"wp-block-paragraph\"></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31055,
            Title = "LEGACY: Angular + Entity Framework",
            Slug = "angular-entity-framework",
            Description = "ASP.NET Training I was going to start my Entity Framework studies with Windows Forms but I decided to give it a go and try to create some basic WebApplication with Angular and E...",
            CardImgUrl = "legacy-angular-entity-framework.png",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/07/27/angular-entity-framework/",
            ReleaseDate = new DateTime(2020, 7, 27),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\"><strong>ASP.NET Training</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I was going to start my Entity Framework studies with Windows Forms but I decided to give it a go and try to create some basic WebApplication with Angular and EF. It literally took me two hours to go over 20 minutes of tutorials jus to configure the project to follow a simple CRUD tutorial.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Even though it&#8217;s challenging I&#8217;m still happy to be something of smaller scale together before I return to the full-fledge application that&#8217;s the base of my previous course. The tutorial isn&#8217;t long, just 1h40 and if I finish without any unsolvable issues I think I&#8217;ll have a basic understanding of how things work in terms of architecture.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Input</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;ve been listening to my book on Ben Franklin and Tim Ferriss is still looping on my phone whenever I have the chance but practicing Italian is occupying a big chunk of my attention. That&#8217;s why I haven&#8217;t mentioned podcasts in a while. </p>\n\n\n\n<p class=\"wp-block-paragraph\">Another contributing factor is the change of my gym time. Previously I&#8217;ve been going to the gym first thing, always with a new podcast. Now I don&#8217;t commute to the gym anymore as it&#8217;s near work. In the bus I&#8217;m studying Italian and when I use my bike to go I&#8217;d rather listen to music. </p>\n\n\n\n<p class=\"wp-block-paragraph\">But I&#8217;ll be posting the interesting stuff I&#8217;ve been listening to soon. </p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31056,
            Title = "LEGACY: A Good Sunday",
            Slug = "a-good-sunday",
            Description = "I’ve had an excellent Sunday. The two activities that define my identity, coding and dancing, went really well, so it was a satisfying day. I created a couple more functionaliti...",
            CardImgUrl = "legacy-a-good-sunday.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/07/27/a-good-sunday/",
            ReleaseDate = new DateTime(2020, 7, 27),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">I&#8217;ve had an excellent Sunday. The two activities that define my identity, coding and dancing, went really well, so it was a satisfying day. I created a couple more functionalities on my Budget App. I&#8217;ll keep working on it tomorrow, but in the morning my priority is to try to create the same app using Entity Framework instead of ADO.NET. I think later on I will benefit from having learning both.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I also need to have a better look at error handling in C#. I had a good idea of what it was all about in Java, even though I haven&#8217;t used it that much by myself, but in C# I only have a vague idea. I suppose it&#8217;s similar to Java. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Salsa</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I had fantastic classes yesterday. We got rid of a class that had a bad time slot so all the classes were busy. Teaching empty classes affects my mood so I&#8217;ll avoid it at all costs from now on. I did it too many times in the last year. Now that I don&#8217;t have to worry about going back to Brazil I can just say no to more stuff.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Time Track</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">This week I lost track of my activities at about Wednesday and I couldn&#8217;t be bothered continuing. I&#8217;ll try my best to do it again this week. I might even create a small app to store it so kill two birds with a shot. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Gym</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Back on track!! After missing last weeks Friday,  I went to the gym eight days in a row so I could have the Sunday off and now I&#8217;m back on track! </p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31057,
            Title = "LEGACY: My First C# App!",
            Slug = "my-first-c-app",
            Description = "Today was a great day of coding! I’ve completed a fully functional C# Budget App. It performs all CRUD operations and it also filters records by date, category or both at the sa...",
            CardImgUrl = "legacy-my-first-c-app.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/07/25/my-first-c-app/",
            ReleaseDate = new DateTime(2020, 7, 25),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">Today was a great day of coding! I&#8217;ve completed a fully functional C# Budget App. It performs all CRUD operations and it also filters records by date, category or both at the same time. It was the culmination of close to three weeks of hard navigate the unknown waters of a new language and a new framework. </p>\n\n\n\n<p class=\"wp-block-paragraph\">For this app I used Windows Forms for the interface, ADO.NET with Table Adapter for the behind the scenes and SQL Server for the database. </p>\n\n\n\n<p class=\"wp-block-paragraph\">Tomorrow I&#8217;ll try to add some more functionalities to the app and improve error handling and general UX . After that I&#8217;ll put it to rest and start creating the same app with Entity Framework. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Arts</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Today I finished <em>Pride and Prejudice</em>. What a fantastic book. I&#8217;ll probably go back to the book every once in a while to steal some interesting words and expressions. The language is so rich! I quickly jumped on Audible to get a new book and, following the plan to alternate fiction and non-fiction I got <a href=\"https://www.amazon.com.au/Benjamin-Franklin-American-Walter-Isaacson/dp/074325807X\">Benjamin Franklin&#8217;s biography.</a> </p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;m happy I&#8217;ve been pretty consistent in studying Italian whenever I have to do stuff like flossing or waiting at a bus stop. It&#8217;s becoming second nature to use that type of time to do something useful other than scroll on Facebook or whatever.</p>\n\n\n\n<p class=\"wp-block-paragraph\"></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31058,
            Title = "LEGACY: ADO.NET",
            Slug = "ado-net",
            Description = "Two days without posting! Am I losing the discipline? Looks like yeah. They were also two days without coding. I had a day off of work before teaching in Sunshine Coast so I dec...",
            CardImgUrl = "legacy-ado-net.png",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/07/24/ado-net/",
            ReleaseDate = new DateTime(2020, 7, 24),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">Two days without posting! Am I losing the discipline? Looks like yeah. They were also two days without coding. I had a day off of work before teaching in Sunshine Coast so I decided to go a day before, but I just couldn&#8217;t sit down to code as I planned.</p>\n\n\n\n<p class=\"wp-block-paragraph\">.<strong>NET training</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">But today I had a solid 4h17&#8242;. I&#8217;m happy I completed a super simple version of a Windows Forms App with CRUD functionalities but I&#8217;ve done zero coding for that. All I did was to install a &#8220;table adapter&#8221; to a &#8220;Dataset&#8221;, which means I connected my view to my database and the table adapter creates the queries automatically with a &#8220;Query Builder&#8221;. </p>\n\n\n\n<p class=\"wp-block-paragraph\">It&#8217;s all nice and pretty but it almost feels like I&#8217;m working on WordPress dragging and dropping things. I have zero knowledge of how to get the data and do something with it with actual code (example: to get the sum of all values in a table in a date range. </p>\n\n\n\n<p class=\"wp-block-paragraph\">But tomorrow I have a massive chunk of time for coding so I&#8217;ll definitely find out how to do it. Once I find it out and I&#8217;m able to create a couple of functionalities I&#8217;ll go into Entity Framework a bit deeper as this is the way my &#8220;mentor&#8221; connects to the database so I should be focusing on that. But I still think it&#8217;s valuable to know the basics of ADO.NET. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Arts</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I had forgotten how music can produce emotions and I&#8217;m realising it again by studying Italian through music. I&#8217;ll come back to that tomorrow but for now I&#8217;ll just post my favourite song so far: </p>\n\n\n\n<figure class=\"wp-block-embed-spotify wp-block-embed is-type-rich wp-embed-aspect-9-16 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<div class=\"embed-spotify\"><iframe title=\"Spotify Embed: L&amp;apos;appuntamento\" style=\"border-radius: 12px\" width=\"100%\" height=\"152\" frameborder=\"0\" allowfullscreen allow=\"autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture\" loading=\"lazy\" src=\"https://open.spotify.com/embed/track/5PnEkOUOFnk0wMI71JwddQ?utm_source=oembed\"></iframe></div>\n</div></figure>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31059,
            Title = "LEGACY: First miss",
            Slug = "first-miss",
            Description = "For the first time yesterday I didn’t post. I arrived home after midnight and was half asleep so I had to give it a miss. I’m still proud of my record. I posted for 35 days in a...",
            CardImgUrl = "legacy-first-miss.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/07/21/first-miss/",
            ReleaseDate = new DateTime(2020, 7, 21),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">For the first time yesterday I didn&#8217;t post. I arrived home after midnight and was half asleep so I had to give it a miss. I&#8217;m still proud of my record. I posted for 35 days in a row, which is a sign I&#8217;m building the discipline I&#8217;ll need to become a coder.</p>\n\n\n\n<p class=\"wp-block-paragraph\">.<strong>NET Training</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Yesterday I found out a fancy screensaver I got when I bought my Macbook Air was occupying 30gb of space of my 128gb HD. I was struggling to keep downloading the tools I needed to learn .NET and all of the sudden, this great surprise. I found out by displaying the hidden files in my system. It was a great surprise.</p>\n\n\n\n<p class=\"wp-block-paragraph\">After fumbling around with C# and .NET for a couple of weeks now, I&#8217;m building my first app using Windows Forms and ASP.NET. I&#8217;ll build a very simple version to put on my portfolio. I like the idea of using windows forms first so that I don&#8217;t have to learn C# plus ASP.NET at the same time, which I&#8217;m finding too much at the moment </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Arts</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">In the past few days I&#8217;ve been listening to a lot of Italian music. Even if I don&#8217;t understand the lyrics perfectly at least I&#8217;m getting my listening sharper. Plus I listened to an interview by Fabio Capello. I suspect we can learn a lot from listening to people talk. I also have many people I can speak Italian with, which is very helpful. </p>\n\n\n\n<p class=\"wp-block-paragraph\">Here&#8217;s a playlist with the Italian songs I&#8217;ve been listening, some of them classics: </p>\n\n\n\n<figure class=\"wp-block-embed-spotify wp-block-embed is-type-rich wp-embed-aspect-9-16 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<div class=\"embed-spotify\"><iframe title=\"Spotify Embed: Italiano\" style=\"border-radius: 12px\" width=\"100%\" height=\"352\" frameborder=\"0\" allowfullscreen allow=\"autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture\" loading=\"lazy\" src=\"https://open.spotify.com/embed/playlist/4szO9Jre9ZOuUskRDmcrnn?utm_source=oembed\"></iframe></div>\n</div></figure>\n\n\n\n<p class=\"wp-block-paragraph\"></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31060,
            Title = "LEGACY: Social Life",
            Slug = "social-life",
            Description = "The week is over and I have the numbers from my time tracker. It’s probably got a margin of error of about 5-10% but it gives me the overall picture of how I’m spending my time....",
            CardImgUrl = "legacy-social-life.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/07/20/social-life/",
            ReleaseDate = new DateTime(2020, 7, 20),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">The week is over and I have the numbers from my time tracker. It&#8217;s probably got a margin of error of about 5-10% but it gives me the overall picture of how I&#8217;m spending my time. Here are the numbers: </p>\n\n\n\n<ul class=\"wp-block-list\"><li>Sleeping: 27% (47h26&#8242;)</li><li>Working: 19% (33h11&#8242;)</li><li>Coding: 11.5% (19h43&#8242;)</li></ul>\n\n\n\n<p class=\"wp-block-paragraph\">After this I have two huge time leaks. </p>\n\n\n\n<ul class=\"wp-block-list\"><li>Social: 10.7% (18h)</li><li>Commute: 8% (13h30&#8242;)</li></ul>\n\n\n\n<p class=\"wp-block-paragraph\">I don&#8217;t mind having a sharp social life, but coding for 20h and socialising for 18h means I&#8217;m not making the necessary sacrifices to do the things that I have to do. Just to be clear, socialising usually means having coffee or dinner with a single person. I&#8217;m rarely involved in any gathering. And that also includes the time I spend on the phone with my family back in Brazil.</p>\n\n\n\n<p class=\"wp-block-paragraph\">My conclusion is that there&#8217;s room to increase coding in at least 50%. If I cut my social life in half and stop going to the gym in the mornings, that means I&#8217;ll have about 12-14 hours to relocate. Realistically, I won&#8217;t be using all of them, but I could definitely get to 30hs of coding. </p>\n\n\n\n<p class=\"wp-block-paragraph\">Well, going to the gym late has pros and cons and one of the cons is that I&#8217;m up at 12:37am so I&#8217;ll stop here, with stopwatches restarted for Week 30 of 2020. 🙂</p>\n\n\n\n<p class=\"wp-block-paragraph\"></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31061,
            Title = "LEGACY: Rum!",
            Slug = "rum",
            Description = "I had an awful start of the day. I indulged in too much rum last night and had my cognitive capacity significantly decreased in the first few hours of my day. I think it’s ok to...",
            CardImgUrl = "legacy-rum.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/07/19/rum/",
            ReleaseDate = new DateTime(2020, 7, 19),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">I had an awful start of the day. I indulged in too much rum last night and had my cognitive capacity significantly decreased in the first few hours of my day. I think it&#8217;s ok to have some sort of distraction from my coding obsession and wind down on my routine sometimes including substance use but I just hate the way I felt in those hours. Not sure it&#8217;s worth it.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Coding</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I did have another big day of work so coding was limited to 3.5 pomodoros. As previously planned, I start reviewing the app I&#8217;m created to better understand it. I went back to the beginning of the course and I&#8217;m reviewing the process of folders and classes creation so I can map out the API before I move on. </p>\n\n\n\n<p class=\"wp-block-paragraph\">The combination of many layers of classes with the novelties of C# Core were too much for my newbie brain. But I&#8217;ll try not to go too deep into the core of the language. I&#8217;ll learn as I need it. Right now I&#8217;m interested in lambda expressions. They&#8217;re everywhere in the application and I&#8217;m not fluent in that particular area.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Input</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;m exhausted so I won&#8217;t post about today&#8217;s podcast, but here are a couple of interesting videos I watched today. I was interested in real footage of Marine Corps bootcamps and I also want to know who are the most famous motivational speakers of our time. I found out about this Eric Thomas guy. I think even some intrinsically super motivated would benefit from this guy&#8217;s energy:</p>\n\n\n\n<figure class=\"wp-block-embed-youtube wp-block-embed is-type-rich wp-embed-aspect-16-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<span class=\"embed-youtube\" style=\"text-align:center; display: block;\"><iframe loading=\"lazy\" class=\"youtube-player\" width=\"723\" height=\"407\" src=\"https://www.youtube.com/embed/7Oxz060iedY?version=3&#038;rel=1&#038;showsearch=0&#038;showinfo=1&#038;iv_load_policy=1&#038;fs=1&#038;hl=en&#038;autohide=2&#038;wmode=transparent\" allowfullscreen=\"true\" style=\"border:0;\" sandbox=\"allow-scripts allow-same-origin allow-popups allow-presentation allow-popups-to-escape-sandbox\"></iframe></span>\n</div></figure>\n\n\n\n<figure class=\"wp-block-embed-youtube wp-block-embed is-type-rich wp-embed-aspect-16-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<span class=\"embed-youtube\" style=\"text-align:center; display: block;\"><iframe loading=\"lazy\" class=\"youtube-player\" width=\"723\" height=\"407\" src=\"https://www.youtube.com/embed/gWwULJvVmcM?version=3&#038;rel=1&#038;showsearch=0&#038;showinfo=1&#038;iv_load_policy=1&#038;fs=1&#038;hl=en&#038;autohide=2&#038;start=182&#038;wmode=transparent\" allowfullscreen=\"true\" style=\"border:0;\" sandbox=\"allow-scripts allow-same-origin allow-popups allow-presentation allow-popups-to-escape-sandbox\"></iframe></span>\n</div></figure>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31062,
            Title = "LEGACY: Subpar",
            Slug = "subpar",
            Description = "I don’t want to be unforgiving but I had the second day in a row of no coding and I’m pretty disappointed with myself. I’ll never be a programmer if I have spells of 48 hours co...",
            CardImgUrl = "legacy-subpar.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/07/18/subpar/",
            ReleaseDate = new DateTime(2020, 7, 18),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">I don&#8217;t want to be unforgiving but I had the second day in a row of no coding and I&#8217;m pretty disappointed with myself. I&#8217;ll never be a programmer if I have spells of 48 hours coding for less than an hour. Ok, I understand I had to commute for 6 hours and had two big days of work but I could have done better.</p>\n\n\n\n<p class=\"wp-block-paragraph\">On a positive note, I&#8217;ve been successful at tracking my time during this week so by the end of Sunday I&#8217;ll have a pretty good idea of how my life is being spent. As Tim Ferriss likes to say, what you can measure, you can improve.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Gym</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;ve also failed to go to the gym for the first time since Covid-19. I have to be really really careful to avoid messing with my routines. It starts exactly like today. I have to aggressively get back on track ASAP. So because I didn&#8217;t go this Friday that means I&#8217;ll have to compensate on Sunday and work out every day for eight days, non-negotiable. </p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31063,
            Title = "LEGACY: ",
            Slug = "211",
            Description = "After a month posting daily I failed a day due to being busy teaching in Sunshine Coast. This is a great opportunity for me to exercise the ability of preventing a dent in an es...",
            CardImgUrl = "legacy-211.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/07/17/211/",
            ReleaseDate = new DateTime(2020, 7, 17),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">After a month posting daily I failed a day due to being busy teaching in Sunshine Coast. This is a great opportunity for me to exercise the ability of preventing a dent in an established habit from disrupting that habit. So here I am writing in the train back home.</p>\n\n\n\n<p class=\"wp-block-paragraph\">It was great to leave town again after four months of Covid. Things seem to be normal in Sunshine Coast. There&#8217;s no social distance or whatsoever but I think everyone is relaxed because there hasn&#8217;t been a case in several days. </p>\n\n\n\n<p class=\"wp-block-paragraph\">I think it&#8217;s too early too lower our guards though. Things could change in a blink of an eye as Victoria showed us. Our borders with New South Wales are open and cases are increasing over there.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Coding</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I didn&#8217;t have many available hours in the morning but made a tiny bit of progressive in my ASP.NET course. However I&#8217;m now making a map of the file and class structure of the application so I can better understand it.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;ll also create diagrams for the flow of operations so I can understand how data is being moved around within the app. I should have done it from the beginning but now the app grew too big to keep going without it. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Podcast</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I was back to the gym after my 3 day break and with it I&#8217;m back to podcasts. Today&#8217;s episode was with Doris Kearns Goodwin, an American Historian that worked for Lyndon Johnson and became a specialist in the biographies or presidents. Very interesting conversation about the life and habits of people like Lincoln, Roosevelt, Truman, Kennedy and other great guys that ruled America.</p>\n\n\n\n<figure class=\"wp-block-embed-spotify wp-block-embed is-type-rich wp-embed-aspect-21-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<div class=\"embed-spotify\"><iframe title=\"Spotify Embed: #335: The Life Lessons and Success Habits of Four Presidents — Doris Kearns Goodwin\" style=\"border-radius: 12px\" width=\"100%\" height=\"152\" frameborder=\"0\" allowfullscreen allow=\"autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture\" loading=\"lazy\" src=\"https://open.spotify.com/embed/episode/6dL70z91m3pyUo7lPMFJc7?utm_source=oembed\"></iframe></div>\n</div></figure>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31064,
            Title = "LEGACY: Cocoon",
            Slug = "cocoon",
            Description = "ASP.NET Training Today was an interesting day. After another couple of hours delving into my ASP.NET course I felt the necessity of going back a little and trying to understand...",
            CardImgUrl = "legacy-cocoon.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/07/15/cocoon/",
            ReleaseDate = new DateTime(2020, 7, 15),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\"><strong>ASP.NET Training</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Today was an interesting day. After another couple of hours delving into my ASP.NET course I felt the necessity of going back a little and trying to understand more of C# core. I was feeling a bit lost with many things that I can&#8217;t quite relate to Java such as the <em>Expression Class</em>.</p>\n\n\n\n<p class=\"wp-block-paragraph\">But then I lost a few hours trying to find the best resource to Study. <em>Head First C#</em> first edition had to be abandoned because it&#8217;s a 2008 book and Visual Studio doesn&#8217;t offer some of the stuff required to follow the book. I then downloaded 3rd edition from 2013 but then switched to another book, <em>Beginning C#</em>. I skimmed over the first 70 pages to jump into the actual coding but then I was already a bit tired. At least now I know where to start from tomorrow. </p>\n\n\n\n<p class=\"wp-block-paragraph\">After that I went into the previously bought C# course from Udemy and went over some of the basics. I created my first application using Windows Forms, a simple digital clock,  but then it stuck with the idea that I had to deploy it. I can run it on my Windows Parallel but I couldn&#8217;t get it to Run on my old Windows PC. </p>\n\n\n\n<p class=\"wp-block-paragraph\">So why am I trying to deploy a digital clock? Well I finally created the skeleton for my portfolio. I linked my domain to my Inmotion Hosting and Installed WordPress in it. The site is already live but I&#8217;ll only publish it here when it&#8217;s ready. The idea is to start creating small applications to give my future employers an idea of my evolution as a software engineer. </p>\n\n\n\n<p class=\"wp-block-paragraph\">My vision for my portfolio is to have dozens of applications of all kinds. I want to start deploying small applications that will be enhanced with time. I&#8217;m not sure how to go about deploying my non-web stuff on my portfolio but it seems like I can do it on the cloud. </p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;ll keep doing that tomorrow but not without moving forward on my Asp.NET MVC course, because my final goal is to be able to partner up with my mentor as a developer. </p>\n\n\n\n<p class=\"wp-block-paragraph\">So overall it wasn&#8217;t a day of concrete coding done, but I did lay the foundations for the next few weeks of learning.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Arts and Gym</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Today was my last day of fitness vacation. After working out uninterruptedly since the gyms reopened I needed some rest so I took 3 days off. Tomorrow I&#8217;m back to lifting. I feel recharged and training tomorrow should be awesome. I also took the chance to stay away from podcasts in the last four days. I&#8217;m also returning to them with renewed appreciation. </p>\n\n\n\n<p class=\"wp-block-paragraph\">But in the arts territory I discovered two very interesting things. The first is a French pop-folk band called Cocoon. Their last album is the best thing I&#8217;ve discovered in music in a while. Fantastic feel-good music carefully composed and produced. Very very good stuff. There&#8217;s a chance it will be a big part of my 2020 soundtrack.</p>\n\n\n\n<p class=\"wp-block-paragraph\">The second one was this series called <em>Master of None</em> with Aziz Ansari. Very light-hearted but clever comedy that deals with some of the dilemmas of modern urban life. It&#8217;s still early to say it&#8217;s a great series but the first episode impressed me. And the 25 minute format fits my current reality where I&#8217;m not interest in sitting for an hour to watch something very frequently. I can probably watch an episode daily and then a movie every week or fortnight. </p>\n\n\n\n<p class=\"wp-block-paragraph\">Watching these things will be very good for me right now because of my lack of geographical variation. I think I&#8217;ve probably been living within a 5km area for close to 3 months now. Tomorrow will be my first time away from Brisbane City in four month. Going to Sunshine Coast to start teaching zouk again. 🙂</p>\n\n\n\n<p class=\"wp-block-paragraph\"></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31065,
            Title = "LEGACY: Yann Muller",
            Slug = "yann-muller",
            Description = "Big Day Big day of teaching dance today as we are officially back to partner dancing (provided we don’t have an outbreak of Covid-19). I was very happy our classes had better nu...",
            CardImgUrl = "legacy-yann-muller.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/07/14/yann-muller/",
            ReleaseDate = new DateTime(2020, 7, 14),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\"><strong>Big Day</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Big day of teaching dance today as we are officially back to partner dancing (provided we don&#8217;t have an outbreak of Covid-19). I was very happy our classes had better numbers than I expected. I love teaching Salsa and it was good to be back, despite the freezing night in Brisbane</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>ASP.NET Training</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">It was probably the hardest day of my journey with .NET so far. The theme of the day was Error Handling and even though I understood the overall concept, every line of code was new to me. Method after method, after technique, after class, after object piling up on a mountain of stuff I haven&#8217;t seen before. </p>\n\n\n\n<p class=\"wp-block-paragraph\">But I&#8217;ve been in these situations before and I know It&#8217;s just a matter of getting used to it, so I&#8217;m not panicking (just yet).</p>\n\n\n\n<p class=\"wp-block-paragraph\">However the big day only allowed time for 7.5 Pomodoros (3h05&#8242;), slightly below the daily target. I&#8217;ll try to compensate tomorrow, since It&#8217;s a day off of work.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Arts</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Today I found an artist that I really enjoy. It&#8217;s a French DJ called Yann Muller. Most of his work isn&#8217;t original but his remixes and covers of famous songs are unbelievable good. And they all fit into the light feel good jazzy house category that&#8217;s my favourite genre right now. </p>\n\n\n\n<figure class=\"wp-block-embed-spotify wp-block-embed is-type-rich wp-embed-aspect-9-16 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<div class=\"embed-spotify\"><iframe title=\"Spotify Embed: Yann Muller\" style=\"border-radius: 12px\" width=\"100%\" height=\"352\" frameborder=\"0\" allowfullscreen allow=\"autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture\" loading=\"lazy\" src=\"https://open.spotify.com/embed/artist/41HOzTOe9JNerhym1HWxti?utm_source=oembed\"></iframe></div>\n</div></figure>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31066,
            Title = "LEGACY: Ocean’s 8",
            Slug = "mission-accomplished",
            Description = "Quick post to talk about a great Monday with my coding objectives achieved, having taught partnered classes for the first time in around four months and having watched a movie f...",
            CardImgUrl = "legacy-mission-accomplished.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/07/14/mission-accomplished/",
            ReleaseDate = new DateTime(2020, 7, 14),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">Quick post to talk about a great Monday with my coding objectives achieved, having taught partnered classes for the first time in around four months and having watched a movie for the first time in around six months.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>ASP.NET training</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I managed to follow my new plan of total focus on coding in the morning. I deleted messenger from my phone and blocked my most visited websites from Chrome.  As a result I was able to code for eight Pomodoros (3h20). I was going to reach the four hour target at night but I sat down to watch a movie with a friend who&#8217;s going through some tough times.</p>\n\n\n\n<p class=\"wp-block-paragraph\">The .Net course is super confusing right now, with many tools and layers of abstraction being added on top of the other. But I know it&#8217;s just because I&#8217;m not familiar with the framework&#8217;s ways. With time I know I&#8217;ll get more comfortable with it</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Arts</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">So I watched <em>Ocean&#8217;s 8</em>, the female continuation of the acclaimed &#8220;Ocean&#8217;s&#8221; series. It lacks in originality. Everything looks like <em>Ocean&#8217;s Eleven</em>, from music, to plot and characters. The only difference is the female cast. Still fun to watch, though.</p>\n\n\n\n<p class=\"wp-block-paragraph\">In music, I tried to stick to just a few artists, but it was hard because many House Music artists (my favourite music style these days) only have a handful of songs released. So I ended up jumping around for a bit. My recommendation for today is the Italian DJ Francesco Rossi. </p>\n\n\n\n<figure class=\"wp-block-embed-spotify wp-block-embed is-type-rich wp-embed-aspect-9-16 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<div class=\"embed-spotify\"><iframe title=\"Spotify Embed: Paper Aeroplane - Original Mix\" style=\"border-radius: 12px\" width=\"100%\" height=\"152\" frameborder=\"0\" allowfullscreen allow=\"autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture\" loading=\"lazy\" src=\"https://open.spotify.com/embed/track/6X3fbI7GtdZqKiGj7EH4bh?si=sfWt1jSYRQyV3gGDtjvOTA&amp;utm_source=oembed\"></iframe></div>\n</div></figure>\n\n\n\n<p class=\"wp-block-paragraph\"></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31067,
            Title = "LEGACY: One Month of Residency",
            Slug = "one-month-of-residency",
            Description = "Graveyard Shift I felt so tired this Sunday I went to bed at 7:30pm and that messed with my sleep. I think my body interpreted it as a nap and I’ve been up since 11:30pm. So now...",
            CardImgUrl = "legacy-one-month-of-residency.png",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/07/13/one-month-of-residency/",
            ReleaseDate = new DateTime(2020, 7, 13),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\"><strong>Graveyard Shift</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I felt so tired this Sunday I went to bed at 7:30pm and that messed with my sleep. I think my body interpreted it as a nap and I&#8217;ve been up since 11:30pm. So now I&#8217;m burning the midnight oil for the first time in a long time. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Rethinking My Priorities</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">After an overall unproductive weekend I had to stop and reflect about my priorities for a few minutes. I&#8217;ve recently identified that if I&#8217;m lacking motivation, usually that means I&#8217;m not clearly visualising my priorities. So here is my thought process.</p>\n\n\n\n<p class=\"wp-block-paragraph\">There are many things I love doing. Dancing, teaching, writing, watching stuff, hanging out with friends, just to list a few. But my priority is becoming a programmer. So that means that I need do make some sacrifices in other departments to achieve this main goal. That doesn&#8217;t mean completely wiping out the other activities, as it would lead to unhappiness, which would by the way decrease my chances of succeeding in achieving the goal.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Strategies</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">So how do I go about executing that? Well, the trick is scheduling. Designing a schedule that revolves around programming. I&#8217;ve been doing this for a while now, but it&#8217;s easy to deviate from it, including little activities here and there that end up occupying more time than it should.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Then how do I optimise the schedule? My plan is to add constraints. I&#8217;m allocating massive chunks of time for coding. In those blocks I can only code or rest. I can&#8217;t start watching a video or writing or researching dance. Those things are too interesting and end up leaking into my coding time. So that means the only productive thing I can do at that time block is coding. I can choose to do nothing. To grab something to eat, to go to the bathroom, to take a nap. But not to do any &#8220;tasks&#8221;.</p>\n\n\n\n<p class=\"wp-block-paragraph\">What does that do? It should increase my actual coding time. And most importantly, it should prevent my mind from task switching. If I do mundane stuff like eating or peeing, it&#8217;s way easier to switch back to coding. If I read the news or listen to a super interesting podcast, my mind will try to go into ponder and process mode, and it will be hard to go back to coding with full attention.</p>\n\n\n\n<p class=\"wp-block-paragraph\">And that has an extra benefit. If I do all the coding I need on those blocks, when I move on to the non-priority activities, my mind won&#8217;t be thinking of code. Or of the coding I should have done. I&#8217;ll have peace of mind about it and, hence, I&#8217;ll be able to focus on the present task. It&#8217;s the ultimate nirvana of mindfulness. This ideal state of mind that humans aren&#8217;t programmed for, but everyone is trying to achieve.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Less Jumping Around</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">As an avid consumer of arts, it&#8217;s really easy to jump around from artist to artist, album to album, song to song and end up without a clear notion about any of it. And more than that, without experiencing that piece of art properly. Art is about experience. </p>\n\n\n\n<p class=\"wp-block-paragraph\">Ok if I start a movie and hate it, I might decide to make better use of the following one hour and a half of my time. But if I start a song, there&#8217;s no reason not to finish it, even if I hate it. If I hate four or five songs of an artist, I should listen to their most listened songs as a final test and only then, abandon them. If I don&#8217;t do that I might be missing out on interesting artist because of bad first impressions and I need to avoid that.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Movies</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">The hardest thing for me right now is to find time to watch movies. I absolutely love a good cinematic experience but I don&#8217;t think I&#8217;ve watched a movie in the last six months. And I don&#8217;t like the idea of watching a movie in pieces. The impact that movies like &#8220;<em>Saving Private Ryan&#8221;, Thin Red Line&#8221;, &#8220;Platoon&#8221;, &#8220;Forrest Gump&#8221;, &#8220;The Bodyguard</em>&#8221; would have had in my life wouldn&#8217;t be the same if I had watched them peripatetically.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Commandments</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I was reading &#8220;<em>Seven Habits of Highly Effective People</em>&#8221; today and I came across this idea of having commandments. A list of things to live by. We all have that to some extent, but the idea here is to write them down and read them over and over. Have it easily to visualise so you&#8217;re constantly being reminded of your commandments. </p>\n\n\n\n<p class=\"wp-block-paragraph\">I think what it achieves is it prevents us from deviating from those principles. There&#8217;s too much distraction out there. Keeping a small core of consistent beliefs should decrease anxiety and serve as a compass. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Metrics</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;m trying to work on my metrics once again. I&#8217;ll track everything I do during this week. It&#8217;s the 29th week of the month. But I won&#8217;t have set goals for anything other than coding. I just want to see where my time is going. </p>\n\n\n\n<p class=\"wp-block-paragraph\">So my objective for this week is to code for an average of 4hs a day. That doesn&#8217;t mean the chunk of time I allocated for coding. That means the actual time I have my butt on the chair and my hands on the computer. Clean coding time without any fat attached.</p>\n\n\n\n<p class=\"wp-block-paragraph\">So, time to go! Too much time blogging already! 🙂</p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31068,
            Title = "LEGACY: Async/Await",
            Slug = "180",
            Description = "Super quick post as I’m crazy tired from another big day. ASP.NET Training I made some progress in my course, getting up to 9% completed. I’m absolutely loving learning ASP.NET....",
            CardImgUrl = "legacy-180.png",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/07/11/180/",
            ReleaseDate = new DateTime(2020, 7, 11),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">Super quick post as I&#8217;m crazy tired from another big day.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>ASP.NET Training</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I made some progress in my course, getting up to 9% completed. I&#8217;m absolutely loving learning ASP.NET. Up to know everything is very clear and I&#8217;m understanding the architecture of the application perfectly. I love the concept of separation of concerns and writing clean, organised code. </p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;m being really careful not to skim through lessons. I&#8217;m making tons of notes and writing a step-by-step summary of everything being done so I can quickly access it any time I need. For that I use the fantastic free note-taking app Evernote. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Recovery Week</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">After four and a half weeks without a single gym miss, I&#8217;ll take a few days off to recover. I&#8217;m not sure yet but I think I&#8217;ll just skip the first half of the week and get back next Thursday. And that includes bike-rides to work. I&#8217;m starting to having some back and knee pain and I think those are symptoms of over-training. I might include some sort of fasting in that period as well. I&#8217;ve been curious about fasting for some time now but I&#8217;ve never put it into practice. Let&#8217;s see what happens!</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Input</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Yesterday and today I&#8217;ve listened to a podcast with the phenomenal Jenna Levin, a theoretical cosmologist and professor of physics and astronomy. Super fun interview with lots of insights and inspiration from an amazing mind! Needless to say I highly recommend it . </p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;ve also watched another <a href=\"https://www.youtube.com/watch?v=aT57dnlo-Tw\">video about the assyrians</a>, listened to Dan Carlin&#8217;s podcast and watched a <a href=\"https://www.youtube.com/watch?v=6_GTdR0gBVE\">video to try to understand async-await</a> in programming. </p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31069,
            Title = "LEGACY: Assyrians",
            Slug = "assyrians",
            Description = "I’m very exhausted from a big day so I’ll keep it small today. ASP.NET Training Unfortunately I could only code for two pomodoros today but it’s still progress. We did some refa...",
            CardImgUrl = "legacy-assyrians.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/07/10/assyrians/",
            ReleaseDate = new DateTime(2020, 7, 10),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">I&#8217;m very exhausted from a big day so I&#8217;ll keep it small today.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>ASP.NET Training</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Unfortunately I could only code for two pomodoros today but it&#8217;s still progress. We did some refactoring on our training app and everything is running smoothly. I can understand everything and I&#8217;m looking forward to the next section of the course which discusses the architecture of an ASP.NET application.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;ll probably have to do some side study about async/await and http in general watching a few Youtube Videos.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Input</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;ll consider two catch ups as inputs. One with a good friend in the morning for coffee and the other with my workmates at night. I still find hard to navigate gatherings like that. I&#8217;m much better one on one, but I guess the only way to become socially graceful is by doing it.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;ll talk about the podcast tomorrow, because I can&#8217;t keep my eyes open, but other than that I continued with Pride and Prejudice and Dan Carlin&#8217;s Hardcore History about the spartans. He went all the way back to explain the previous civilisations, with focus on the Assyrians. Quite fascinating stuff.</p>\n\n\n\n<figure class=\"wp-block-embed-youtube wp-block-embed is-type-rich wp-embed-aspect-16-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<span class=\"embed-youtube\" style=\"text-align:center; display: block;\"><iframe loading=\"lazy\" class=\"youtube-player\" width=\"723\" height=\"407\" src=\"https://www.youtube.com/embed/LIYiThAyY8s?version=3&#038;rel=1&#038;showsearch=0&#038;showinfo=1&#038;iv_load_policy=1&#038;fs=1&#038;hl=en&#038;autohide=2&#038;wmode=transparent\" allowfullscreen=\"true\" style=\"border:0;\" sandbox=\"allow-scripts allow-same-origin allow-popups allow-presentation allow-popups-to-escape-sandbox\"></iframe></span>\n</div></figure>\n\n\n\n<figure class=\"wp-block-embed-youtube wp-block-embed is-type-rich wp-embed-aspect-16-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<span class=\"embed-youtube\" style=\"text-align:center; display: block;\"><iframe loading=\"lazy\" class=\"youtube-player\" width=\"723\" height=\"407\" src=\"https://www.youtube.com/embed/7pa54hWROpQ?version=3&#038;rel=1&#038;showsearch=0&#038;showinfo=1&#038;iv_load_policy=1&#038;fs=1&#038;hl=en&#038;autohide=2&#038;wmode=transparent\" allowfullscreen=\"true\" style=\"border:0;\" sandbox=\"allow-scripts allow-same-origin allow-popups allow-presentation allow-popups-to-escape-sandbox\"></iframe></span>\n</div></figure>\n\n\n\n<p class=\"wp-block-paragraph\"></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31070,
            Title = "LEGACY: Napoleon",
            Slug = "napoleon",
            Description = ".NET training I’m very impressed with the Udemy course I purchased for my new journey. Even though it’s not so technically comprehensive as the previous Java + Hibernate one I w...",
            CardImgUrl = "blog1.png",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/07/09/napoleon/",
            ReleaseDate = new DateTime(2020, 7, 9),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\"><strong>.NET training</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;m very impressed with the <a href=\"https://www.udemy.com/course/learn-to-build-an-e-commerce-app-with-net-core-and-angular/\">Udemy course I purchased</a> for my new journey. Even though it&#8217;s not so technically comprehensive as the previous <a href=\"https://www.udemy.com/course/java-servlet-jsp-and-hibernate-build-a-complete-website/\">Java + Hibernate one I was studying</a>, the clarity with which instructor Neil Cummins explains everything is an absolute delight.</p>\n\n\n\n<p class=\"wp-block-paragraph\">And he literally explain every line of code comprehensively without making himself sound repetitive or verbose. Best communicator I&#8217;ve seen on Udemy by far. I want to be like him when I teach, ha!</p>\n\n\n\n<p class=\"wp-block-paragraph\">I had a somewhat effective day of training today, getting a hang on Postman and the basics of End Point construction. And his course has the advantage of using Visual Studio Code, which allows us Mac Users to following along without any problems. I&#8217;ve completed a little more than 5% of the course and I&#8217;m enjoying thoroughly. I&#8217;m not in a hurry but it would be great to get 4% or 5% done everyday but I know it&#8217;s quite unrealistic. After that I still have to learn Azure and RxJS to become an useful apprentice.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><br><strong>Four weeks of residency</strong>!</p>\n\n\n\n<p class=\"wp-block-paragraph\">It already seem far away but it&#8217;s been only 4 weeks since I&#8217;ve become a resident. I&#8217;m proud to have been following my plan since then, investing time and money into my education and nurturing friendships. In the beginning of this journey I&#8217;m living very frugally, without any luxuries.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;m glad I followed a strict routine, always going to bed early and waking up early, studying almost every day, not missing a single gym session. This discipline will be important to establish myself in the IT industry. There&#8217;s a lot to catch up on.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Oh! I and I&#8217;ve posted every single day in this blog since I started. I&#8217;ve never been so consistent in writing a blog 🙂</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Input</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Today I finished yesterday&#8217;s <a href=\"https://open.spotify.com/episode/52wbuGUH2EuvYwwplgzV0p\">podcast with Catherine Hoke</a> and then I was a bit all over the place with my inputs. I returned to &#8220;Jocko&#8217;s Podcast&#8221; for an <a href=\"https://open.spotify.com/episode/5pZyBFPEFsZjSVmZcgFdAk\">episode about the Boer Wars</a>, watched an <a href=\"https://www.youtube.com/watch?v=1I5ZMmrOfnA&amp;list=PL8dPuuaLjXtNlUrzyH5r6jN9ulIgZBpdo&amp;index=6\">episode of the computer science crash course</a> and started listening to a &#8220;<a href=\"https://open.spotify.com/episode/6EDjj9pMFbm1gVuw3TSlWX\">Hardcore History&#8221; episode</a>. If you don&#8217;t know about this podcasts, it&#8217;s a fantastic account of history by an exquisite story-teller called Dan Carlin. I can&#8217;t recommend it enough. I&#8217;m also deep into &#8220;Pride and Prejudice&#8221;, which should be finished by the weekend. Oh, and in the end of the day I found a fantastic history Youtube Channel where I watched an episode about the first battle won by Napoleon: <a href=\"https://www.youtube.com/watch?v=DRUx61plsz4&amp;list=PLUOc2qodFHp-mOphKW9RzQLsFTt-IV9RY&amp;index=1\">The Siege of Toulon</a>. </p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31071,
            Title = "LEGACY: .Net Training",
            Slug = "164",
            Description = ".NET I started the day looking at the C# stuff and after quickly going through about 60 videos I realised I was looking into very generic stuff like variables, datatypes and bas...",
            CardImgUrl = "legacy-164.png",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/07/08/164/",
            ReleaseDate = new DateTime(2020, 7, 8),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\"><strong>.NET</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I started the day looking at the C# stuff and after quickly going through about 60 videos I realised I was looking into very generic stuff like variables, datatypes and base classes. And it was all really similar to Java. After asking my &#8220;mentor&#8221; if I&#8217;ll need complex concepts such as multithreading to help him, he said I wouldn&#8217;t.</p>\n\n\n\n<p class=\"wp-block-paragraph\">So I&#8217;m taking a leap and jumping straight into the .NET stuff. For a few hours I worked on a couple of .NET REST api tutorials, but they assumed a knowledge that I didn&#8217;t have. It was slightly ahead of me. I might go back to them later. But then I decided to buy a more comprehensive Angular + .NET tutorial from scratch for developers with a bit of experience.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Udemy courses have proven to be far superior to most Youtube tutorials. I think these tutorials are still useful to have a quick glance at stuff or find solutions for very specific problems, but to dive deep into technologies, there are quality instructors out there providing great material that covers everything from architecture to the minutia, while explaining every line of code.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Having said that, even though these tutorials I&#8217;ve been buying are quite cheap, I&#8217;m far from comfortable financially, so hopefully I&#8217;ll stick to this one (while still working on my Java+Hibernate one) so I can spare my hollow wallet.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Gym and Podcasts</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Today I completed 4 weeks in a row without a single miss in the gym and I&#8217;m feeling great physically. The amount of junk food is down to a minimum as well so now what I need to do is slightly decrease carbs. I&#8217;ve been doing some cardio going to and from work on my bike so that helps.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Today I listened to a podcast with Catherine Hoke, an entrepreneur that after becoming successful as a businesswoman decided to dedicate her life to rehabilitating inmates in the US. Super inspirational stuff. What a powerhouse of a woman. The interview gets emotional at some point when she goes deep into personal issues. She thinks most people deserve a second chance and uses herself as an example, from when she made some pretty bad choices.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Yesterday I listened to Frank Blake, successful lawyer and former CEO of Home Depot. As much as my life paths have nothing to do with his, I learned so much from this interview. So many great stories about self-management, leadership, the power of positivity and insights into the corporate world in the US.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I know I always write this, but I highly recommend both episodes.<br></p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Music</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Today I came across a great album for the night time: &#8220;All Visible Objects&#8221; from Moby. I remember listening to him around 15 years ago, back in the mp3 times. And he still delivers. Half the album is brilliant and is going to my &#8220;Arts 2020&#8221; list.</p>\n\n\n\n<figure class=\"wp-block-embed-spotify aligncenter wp-block-embed is-type-rich wp-embed-aspect-9-16 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<div class=\"embed-spotify\"><iframe title=\"Spotify Embed: All Visible Objects\" style=\"border-radius: 12px\" width=\"100%\" height=\"352\" frameborder=\"0\" allowfullscreen allow=\"autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture\" loading=\"lazy\" src=\"https://open.spotify.com/embed/album/69hBXxdKSH0bT7odfOc37u?utm_source=oembed\"></iframe></div>\n</div></figure>\n\n\n\n<figure class=\"wp-block-embed-spotify wp-block-embed is-type-rich wp-embed-aspect-21-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<div class=\"embed-spotify\"><iframe title=\"Spotify Embed: #303: How to Do Crazy Good Turns -- Frank Blake\" style=\"border-radius: 12px\" width=\"100%\" height=\"152\" frameborder=\"0\" allowfullscreen allow=\"autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture\" loading=\"lazy\" src=\"https://open.spotify.com/embed/episode/1bTgHluvN58ozTmWrWyB2d?utm_source=oembed\"></iframe></div>\n</div></figure>\n\n\n\n<figure class=\"wp-block-embed-spotify wp-block-embed is-type-rich wp-embed-aspect-21-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<div class=\"embed-spotify\"><iframe title=\"Spotify Embed: #293: Catherine Hoke — The Master of Second Chances\" style=\"border-radius: 12px\" width=\"100%\" height=\"152\" frameborder=\"0\" allowfullscreen allow=\"autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture\" loading=\"lazy\" src=\"https://open.spotify.com/embed/episode/52wbuGUH2EuvYwwplgzV0p?utm_source=oembed\"></iframe></div>\n</div></figure>\n\n\n\n<p class=\"wp-block-paragraph\"><br></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31072,
            Title = "LEGACY: Running Windows on My Mac",
            Slug = "running-windows-on-my-mac",
            Description = "Coding I had a fantastic day of coding. After waking up, going to the gym and back home at the exact time I planned, I sat down to study a bit of Java before diving into C#. I w...",
            CardImgUrl = "legacy-running-windows-on-my-mac.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/07/07/running-windows-on-my-mac/",
            ReleaseDate = new DateTime(2020, 7, 7),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\"><strong>Coding</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I had a fantastic day of coding. After waking up, going to the gym and back home at the exact time I planned, I sat down to study a bit of Java before diving into C#. I want keep Java going in the background as I learn the new language.</p>\n\n\n\n<p class=\"wp-block-paragraph\">My first experience with C# couldn&#8217;t have been better. I seem to have passed the hurdle of having Windows on my Mac using &#8220;Parallels&#8221; service as a trial and everything is running smoothly. I thought it would take me many days to figure out how to start coding C# on a mac but it was easier than I thought. I&#8217;m running Visual Studio 2019 (not visual studio code), which is designed for Microsoft languages on Parallel and everything is running smoothly.</p>\n\n\n\n<p class=\"wp-block-paragraph\">For the first time I came across <a href=\"https://www.udemy.com/course/c-for-beginners-to-advance-via-projects-1/learn/lecture/13605260#overview\">a teacher</a> that teaches the GUI before teaching any code. And I think it&#8217;s a fantastic idea. As much as I loved Code Gym, I think it&#8217;s counter productive to try to make code attractive to a non-coder with pure-code teaching. If you still don&#8217;t love coding and you&#8217;re learning is based purely on coding, without any connection to the world, chances are the students will disappear. I&#8217;m sure the low retention at code gym has to do with that.</p>\n\n\n\n<p class=\"wp-block-paragraph\">After the first few videos setting up the system for C#, I was already creating a GUI with Windows Forms, which is twin-brothers with JavaFX. That&#8217;s great news! I was lucky to just have learned JavaFX so I&#8217;ll be able to watch everything super fast. I understand the concept, so all I have to do is return to whatever video I need when I need it.</p>\n\n\n\n<p class=\"wp-block-paragraph\">My first general impression is that C# is more readable in general. Not just the code itself, but the errors, names of methods and keywords seem to be closer to english than Java. Apparently Java is better for concurrency, polymorphism and for enterprise web development but I didn&#8217;t get far enough to experiment those. For a beginner like me, C# seems to be more friendly.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Tired</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Apart from all that I still taught dance classes from 4 to 10 so I&#8217;m exhausted. Will talk about today&#8217;s podcast tomorrow.</p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31073,
            Title = "LEGACY: Time to Step Up",
            Slug = "time-to-step-up",
            Description = "Apprenticeship I had a meeting with my programmer friend and we’ve decided we’ll give it a try to see if I’ll be able to help him. The only way that’s possible is if I catch up...",
            CardImgUrl = "legacy-time-to-step-up.png",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/07/06/time-to-step-up/",
            ReleaseDate = new DateTime(2020, 7, 6),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\"><strong>Apprenticeship</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I had a meeting with my programmer friend and we&#8217;ve decided we&#8217;ll give it a try to see if I&#8217;ll be able to help him. The only way that&#8217;s possible is if I catch up on a TON of knowledge ASAP to be able to dive into his projects. He works on hardcore stuff like the internal systems for an insurance company, so now we&#8217;re talking about the real deal.</p>\n\n\n\n<p class=\"wp-block-paragraph\">The first challenge is that he codes on <a href=\"http://Asp.NET\">Asp.NET</a> with C# and I&#8217;ve never seen it before so I&#8217;ll have to start having a look at those from scratch. I&#8217;m not going to abandon Java but this is too great of an opportunity to pass and even though it&#8217;s good to stick to one language at first, I expect these pivots to help me learn faster and be a good programmer in general regardless of the language.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Also, it&#8217;s too good of an opportunity to pass. Not many people are willing to provide mentorship for an inexperienced developer. Plus he&#8217;s one of the nicest people I know, it&#8217;s a pleasure to spend time with him. Obviously I don&#8217;t want to waste his time and I want to show results ASAP but being realistic I don&#8217;t think that will happen in the next couple of months. Not only I need to learn the above mentioned stuff but also I need to get back and deeper into Angular, including the RxJs stuff.<br>All of this will require tightening up my lifestyle. Less coffee catch ups, less procrastination and following a strict schedule to the minute. It&#8217;s a fantastic opportunity and I need to get it right. It&#8217;s my passport to the future. To the geographical freedom that I want so bad.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>First Hurdle</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">The first issue is finding a way to emulate windows on my Mac. It&#8217;s quite a complex challenge for my standards and I&#8217;m trying two approaches. The first is to revive an old HP Windows 8 computer . The second is to run a program called Parallels that allows me to run a &#8220;Virtual Windows Machine&#8221; on my Mac.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I bought a cheap and comprehensive course on C# on Udemy but I couldn&#8217;t start coding because it required me to be running the IDE on a Windows machine. So hopefully I&#8217;ll be able to achieve this by tomorrow so I can write code on C#.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Podcast</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Ok I won&#8217;t get into too much detail but these are the last two podcasts I listened to. Both are highly recommended but If I had to pick one I&#8217;d pick Eric Ripert for the tips about how to deal with anger. He&#8217;s a french chef that was education based on teacher abuse and when trying to replicate that approach in America he failed and had to change as a person and a teacher: &#8220;You can&#8217;t have anger inside you and be happy&#8221;<br></p>\n\n\n\n<figure class=\"wp-block-embed-spotify wp-block-embed is-type-rich wp-embed-aspect-21-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<div class=\"embed-spotify\"><iframe title=\"Spotify Embed: #268: Eric Ripert -- Lessons in Mastery and Mindfulness\" style=\"border-radius: 12px\" width=\"100%\" height=\"152\" frameborder=\"0\" allowfullscreen allow=\"autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture\" loading=\"lazy\" src=\"https://open.spotify.com/embed/episode/5dXYofRmtNMtGJ40RL7Vwq?utm_source=oembed\"></iframe></div>\n</div></figure>\n\n\n\n<figure class=\"wp-block-embed-spotify wp-block-embed is-type-rich wp-embed-aspect-21-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<div class=\"embed-spotify\"><iframe title=\"Spotify Embed: #246: Building Strength, Improving Mindset, and Becoming the World&amp;apos;s Fittest Man - Jason Khalipa\" style=\"border-radius: 12px\" width=\"100%\" height=\"152\" frameborder=\"0\" allowfullscreen allow=\"autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture\" loading=\"lazy\" src=\"https://open.spotify.com/embed/episode/6WcGs1xx1n8wKaghBz13qr?utm_source=oembed\"></iframe></div>\n</div></figure>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31074,
            Title = "LEGACY: DJ Kakah",
            Slug = "dj-kakah",
            Description = "Java Training Today I only coded for 5 pomodoros (2h15). I didn’t go through much in my training up but I learned to refactor sessions into abstract sessions to avoid repetition...",
            CardImgUrl = "legacy-dj-kakah.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/07/05/dj-kakah/",
            ReleaseDate = new DateTime(2020, 7, 5),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\"><strong>Java Training</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Today I only coded for 5 pomodoros (2h15). I didn&#8217;t go through much in my training up but I learned to refactor sessions into abstract sessions to avoid repetition of code, which is a powerful tool of objected oriented programming. It&#8217;s the first time I come across this content in a decent-sized app so I can understand it&#8217;s application and importance. </p>\n\n\n\n<p class=\"wp-block-paragraph\">Tomorrow I have an important meeting that might a watershed in my programming trajectory. There&#8217;s the chance I&#8217;ll agree to start an apprenticeship. Looking forward to it!!</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Socialising</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">One of the reasons why I didn&#8217;t code today was because I spent close to four hours in three different catch-ups with friends. Getting closer to people is one of the quickest and easiest paths to happiness and I&#8217;m successfully following my plan of being more sociable. As an only child and an introvert I was always ok by myself, I never felt lonely or alone, so I was always careless about nurturing friendships.</p>\n\n\n\n<p class=\"wp-block-paragraph\">This carelessness has been improving in the last couple of years but now It&#8217;s going to be an important and hopefully constant part of my life. I want to be surrounded by friends on my death-bed.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Podcast and Arts</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;m going to postpone talking about podcasts one more time because I haven&#8217;t finished Friday&#8217;s yet.</p>\n\n\n\n<p class=\"wp-block-paragraph\">In terms of arts, the only exposure I&#8217;m having right now is to music and not much is making me tick. The things that are striking a chord within me at the moment are Zouk sets, especially by the fantastic DJ Kakah and some isolated tunes found here and there on my researches.</p>\n\n\n\n<figure class=\"wp-block-embed-spotify wp-block-embed is-type-rich wp-embed-aspect-9-16 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<div class=\"embed-spotify\"><iframe title=\"Spotify Embed: Spotlight\" style=\"border-radius: 12px\" width=\"100%\" height=\"152\" frameborder=\"0\" allowfullscreen allow=\"autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture\" loading=\"lazy\" src=\"https://open.spotify.com/embed/track/0EtcGmf2mVZbHWq2ZGP3t7?si=b_-4cZk-RK-pz_XdhmU&amp;utm_source=oembed\"></iframe></div>\n</div></figure>\n\n\n\n<figure class=\"wp-block-embed-soundcloud aligncenter wp-block-embed is-type-rich wp-embed-aspect-1-1 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<div class=\"embed-soundcloud\"><iframe loading=\"lazy\" title=\"DJ LIVE SET - ZURICH ZOUK CONGRESS (OCT 27th 2018) by Dj Kakah\" width=\"723\" height=\"400\" scrolling=\"no\" frameborder=\"no\" allow=\"autoplay; encrypted-media\" src=\"https://w.soundcloud.com/player/?visual=true&#038;url=https%3A%2F%2Fapi.soundcloud.com%2Ftracks%2F520960089&#038;show_artwork=true&#038;maxheight=1000&#038;maxwidth=723\"></iframe></div>\n</div></figure>\n\n\n\n<p class=\"wp-block-paragraph\"><br></p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Today&#8217;s Input</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I started a couple of days ago and I&#8217;ll be on it for a while. It&#8217;s a series about computer science by the amazing crash course youtube channel. Amazing delivery. Lots of excellent content presented in a fun way by an excellent host. I&#8217;m totally hooked.</p>\n\n\n\n<figure class=\"wp-block-embed-youtube wp-block-embed is-type-rich wp-embed-aspect-16-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<span class=\"embed-youtube\" style=\"text-align:center; display: block;\"><iframe loading=\"lazy\" class=\"youtube-player\" width=\"723\" height=\"407\" src=\"https://www.youtube.com/embed/gI-qXk7XojA?version=3&#038;rel=1&#038;showsearch=0&#038;showinfo=1&#038;iv_load_policy=1&#038;fs=1&#038;hl=en&#038;autohide=2&#038;wmode=transparent&#038;listType=playlist&#038;list=PL8dPuuaLjXtNlUrzyH5r6jN9ulIgZBpdo\" allowfullscreen=\"true\" style=\"border:0;\" sandbox=\"allow-scripts allow-same-origin allow-popups allow-presentation allow-popups-to-escape-sandbox\"></iframe></span>\n</div></figure>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31075,
            Title = "LEGACY: Applying for an apprenticeship",
            Slug = "applying-for-an-apprenticeship",
            Description = "Coding The title of this section isn’t Java Training tonight because for the first time in a few days I dug into something other than Java. Here’s the back story. I have a dance...",
            CardImgUrl = "legacy-applying-for-an-apprenticeship.jpeg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/07/05/applying-for-an-apprenticeship/",
            ReleaseDate = new DateTime(2020, 7, 5),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\"><strong>Coding</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">The title of this section isn&#8217;t Java Training tonight because for the first time in a few days I dug into something other than Java.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Here&#8217;s the back story. I have a dance student and friend that is a web developer, with a strong Angular and C# knowledge. I&#8217;ve been taking advice from him since I started coding and after a year of learning how to code I feel like I&#8217;m in a better place to help him with some of his work. In his words, he can&#8217;t keep up with it all.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I figure it would good to have an experienced coder&#8217;s mentorship while working on real projects with real responsibilities. However his projects are all in Angular and C#, which means I might have to learn some of that stuff, along with cloud services like Azure to be able to help him.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I love the idea of having a mentor and becoming an apprentice to someone way more experienced like him. Of course I know I&#8217;ll have to earn it and actually help him. But I&#8217;ll do whatever it takes. I don&#8217;t expect to have any compensation other than the experience and knowledge gained from i<br>We have a meeting on Monday to discuss how to go about it.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Sleepy</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;m up past midnight for the first time in a long time so I&#8217;m very tired. I&#8217;ll write about today&#8217;s input tomorrow.</p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31076,
            Title = "LEGACY: Eric Weinstein",
            Slug = "eric-weinstein",
            Description = "Java Training Even though I didn’t have one of the most productive days , I was able to slowly advance on my study app. I’m almost a quarter through it, and the repetition is in...",
            CardImgUrl = "legacy-eric-weinstein.png",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/07/03/eric-weinstein/",
            ReleaseDate = new DateTime(2020, 7, 3),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\"><strong>Java Training</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Even though I didn&#8217;t have one of the most productive days , I was able to slowly advance on my study app. I&#8217;m almost a quarter through it, and the repetition is incrementing my understanding of Java Programming Language and some of its frameworks. Overall none of the libraries and frameworks I&#8217;m using feel so scary right now. I feel I&#8217;m getting ready to tackle Spring Framework in August.</p>\n\n\n\n<p class=\"wp-block-paragraph\">If I keep the current pace, I&#8217;ll finish this course in about 3 weeks, but I want to increase the amount of daily study hours so I can decrease that time to two weeks. I have put systems in place to optimise my time and avoid distraction. Each minute spent on my phone or preparing meals detracts from study time.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Oh and as of today the libraries are allowing people to sit down, so I&#8217;ll probably spend some time at Toowong Library studying. I have been waiting for this opportunity for a long time.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><br><strong>Book and Podcast</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Other than catching up with a friend for a super stimulating coffee catch-up I only had time for gym, a longer than desired nap and listening to my podcast and audible book.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I absolutely loved yet another Tim Ferriss episode. This time the interviewee was Eric Weinstein. A quick research on Google tells me he&#8217;s a bit further to the right of the political spectrum than I would usually tolerate but at least he has reasonable arguments. Some bullet points:</p>\n\n\n\n<ul class=\"wp-block-list\"><li>The strong belief on the importance of thinking for yourself.</li><li>His approach to language learning</li><li>The phenomenon of &#8220;thought police&#8221; over the internet</li><li>The concept of &#8220;high agency&#8221;, people that have the ability to innovate</li><li>Grow or Die</li><li>Small but super impactful innovations such as the wheeled luggage</li><li>Learning disabled vs teaching disabled</li></ul>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;m definitely listening to this one again.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;ve also advanced on &#8220;Pride and Prejudice&#8221;. It&#8217;s indeed a fantastic book. I&#8217;m totally absorbed in the intricacies of the gossip around the Bennett daughters. But I confess I&#8217;m using the help of <a href=\"https://www.sparknotes.com/lit/pride/\">some websites</a> to keep track of the characters and have an interpretation of the story. There&#8217;s excellent material out there with detailed analysis of the story.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Today&#8217;s Input</strong></p>\n\n\n\n<figure class=\"wp-block-embed-spotify wp-block-embed is-type-rich wp-embed-aspect-21-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<div class=\"embed-spotify\"><iframe title=\"Spotify Embed: #131: Eric Weinstein on Challenging “Reality,” Working with Peter Thiel, and Destroying Education to Save It\" style=\"border-radius: 12px\" width=\"100%\" height=\"152\" frameborder=\"0\" allowfullscreen allow=\"autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture\" loading=\"lazy\" src=\"https://open.spotify.com/embed/episode/3lrRh3osNRsIYp3m812SFC?utm_source=oembed\"></iframe></div>\n</div></figure>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31077,
            Title = "LEGACY: Paul Levesque",
            Slug = "paul-levesque",
            Description = "Java Training Progress is slow and steady. I managed to code for 10 pomodoros (4h15′) using hibernate and jsp. I’m really grateful to have found this course because it gives us...",
            CardImgUrl = "legacy-paul-levesque.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/07/02/paul-levesque/",
            ReleaseDate = new DateTime(2020, 7, 2),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\"><strong>Java Training</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Progress is slow and steady. I managed to code for 10 pomodoros (4h15&#8242;) using hibernate and jsp. I&#8217;m really grateful to have found this course because it gives us an insight in the architecture of a large java application, using all the principles of object oriented programming. The tools are slightly less complicated to understand every day, but I&#8217;ll only have total understanding of them in a couple of months after I finish the project, build it again, and use its model to create a different application.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Unproductive Day</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">It wasn&#8217;t a very productive day. I didn&#8217;t achieve much other than study and even succumbed to a 70% cocoa chocolate bar at local supermarket. The morning was wasted due to lack of attention and my nap in the afternoon took too long. At least gym in the morning was solid.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Three Weeks of Residency</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">It&#8217;s been three weeks since I got the great news. I&#8217;m happy that I settled in Toowong and established good foundations to move on, with systems and routines in place to facilitate study. The only missing piece in the equation is being allowed to study in a library. I&#8217;m been building my study endurance quite successfully but libraries will provide a change of environment that I believe will enhance my study. I&#8217;m aiming to be able to study for 8hs a day eventually and I think it&#8217;s achievable.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Podcast and Arts</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I gave up on the Rolling Stones&#8217; list of best albums as it was mostly commercial stuff. I&#8217;ll still have a look at some of those names albums as I&#8217;m sure there&#8217;s valuable stuff amongst the repetitive tunes, but for aesthetic experiences I&#8217;ll gravitate towards alternative lists.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Today&#8217;s podcast was with Paul Levesque, a professional wrestler. WWE is something that I&#8217;ve never been attracted to, so this is one of those podcasts that serve as a visit to learn from the different. </p>\n\n\n\n<p class=\"wp-block-paragraph\">Someone successful in an area completely unrelated to my interests. Of course there are takeaways, such as:</p>\n\n\n\n<ul class=\"wp-block-list\"><li>The importance of being &#8220;spectacular&#8221; in his industry</li><li>The story they tell is more important than the fancy moves (applies to dancing)</li><li>Keys to longevity in his sport</li><li>Floyd Mayweather Jr.&#8217;s story about pre-fight routines</li><li>&#8220;We&#8217;re just wrestling in our underwear, what are we so worked up about&#8221;, he often says in business meetings as a member of the board of WWE. Can be applied to most situations most times, as most of what we do don&#8217;t involve life-threatening irreversible decision-making.</li></ul>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31078,
            Title = "LEGACY: Pride and Prejudice",
            Slug = "pride-and-prejudice",
            Description = "Java Training First day of the month and I studied Java for 13 pomodoros (5h30″). I haven’t studied for that long in a long time. I’ll try as hard as I can to maintain an averag...",
            CardImgUrl = "legacy-pride-and-prejudice.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/07/01/pride-and-prejudice/",
            ReleaseDate = new DateTime(2020, 7, 1),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\"><strong>Java Training</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">First day of the month and I studied Java for 13 pomodoros (5h30&#8243;). I haven&#8217;t studied for that long in a long time. I&#8217;ll try as hard as I can to maintain an average of 4hs a day in July.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I spent the day working on my study project, working on the connection of the view with the database using Hibernate and testing everything with JUnit and also touching on a little bit of servlets and jsp. I&#8217;m still moving slowly, as all of these technologies are new to me, but I know in a month time I&#8217;ll be way more comfortable, just like what happened with Angular and JavaFX. My goal is to be comfortably working with Spring, Hibernate, Servlets and Angular by the end of the year, with 2021 dedicated to mastering services like Azure or AWS.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Podcast</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">The latest Tim Ferriss Podcast is with Hugh Jackman. What a fantastic character and and inspiring conversation. I&#8217;ll probably listen to it a few times. So many good principles, actionable advice and an overall good energy coming from Wolverine. And he&#8217;s got this pure Aussie way of being kind that&#8217;s hard to explain but I feel every day here Down Under.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Arts</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I finished listening to Halsey&#8217;s album and started Selena Gomez&#8217; new album, but it didn&#8217;t strike a chord. I&#8217;ll jump through the songs tomorrow and finish it soon. Nothing wrong with it, just not my cup of tea. I&#8217;m starting to think I picked a playlist with only mainstream music that won&#8217;t add much aesthetic value to my life. Or maybe I&#8217;m being a music snob? I don&#8217;t know.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I also started listening to the super well-regarded &#8220;Pride and Prejudice&#8221; by Jane Austin. It&#8217;s a book the figures in most lists of most important literary works in english language so I had to check it out. I love it so far. Somehow it makes me feel immersed in rural England during Industrial Revolution. It will be interesting to draw a parallel between those and current times from a human standpoint. Looking forward to dive into it!</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Today&#8217;s Input</strong></p>\n\n\n\n<figure class=\"wp-block-embed-spotify wp-block-embed is-type-rich wp-embed-aspect-9-16 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<div class=\"embed-spotify\"><iframe title=\"Spotify Embed: Rare\" style=\"border-radius: 12px\" width=\"100%\" height=\"352\" frameborder=\"0\" allowfullscreen allow=\"autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture\" loading=\"lazy\" src=\"https://open.spotify.com/embed/album/3YPFaTR7WMi1Hd4NVKdCJx?utm_source=oembed\"></iframe></div>\n</div></figure>\n\n\n\n<figure class=\"wp-block-embed-spotify wp-block-embed is-type-rich wp-embed-aspect-21-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<div class=\"embed-spotify\"><iframe title=\"Spotify Embed: #444: Hugh Jackman on Best Decisions, Daily Routines, The 85% Rule, Favorite Exercises, Mind Training, and Much More\" style=\"border-radius: 12px\" width=\"100%\" height=\"152\" frameborder=\"0\" allowfullscreen allow=\"autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture\" loading=\"lazy\" src=\"https://open.spotify.com/embed/episode/3WXafxuJS11IvovMQj6mSK?si=avDjdptfRbKdiYj15ywtaA&amp;utm_source=oembed\"></iframe></div>\n</div></figure>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31079,
            Title = "LEGACY: Eric Schmidt",
            Slug = "eric-schmidt",
            Description = "Tuesdays are my biggest days at work so I didn’t have a lot of time to do much more than gym and 1 hour of coding. Java Training Today I created my first servlet. Of course not...",
            CardImgUrl = "legacy-eric-schmidt.jpeg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/06/30/eric-schmidt/",
            ReleaseDate = new DateTime(2020, 6, 30),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">Tuesdays are my biggest days at work so I didn&#8217;t have a lot of time to do much more than gym and 1 hour of coding.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Java Training</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Today I created my first servlet. Of course not without some annoying configuration problem that&#8217;s stopping me from loading pictures. It was a tiny day of coding, but any ground gained is valuable. I&#8217;ve also watched a couple of videos about Test Driven Development.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Podcast</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I listened to a podcast I had already listened before. The guy&#8217;s name is Eric Schmidt, a software engineer that &#8216;s one of the main players behind the growth of Google. An excellent interview that I recommend to anyone interested in coding and the tech world in general.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Not only his story is very inspirational and many actionable advice can be taken, but the interview was also very informative about the inner-workings of tech companies and Silicon Valley.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Arts</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Today I&#8217;ve read an important passage of Meditations by Marcus Aurelius where he advises one to, when inflicted pain, not to add stories to it, as much of suffering happens not because of external stimuli, but due to internal turmoil, often unfounded.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Throughout the day I listened to the album &#8220;Manic&#8221; by Halsey. I like it better than yesterday&#8217;s, more digestible for my unsophisticated musical taste, but I&#8217;ll listen to it tomorrow again before posting my favourite songs.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Today&#8217;s Input</strong></p>\n\n\n\n<figure class=\"wp-block-embed-spotify wp-block-embed is-type-rich wp-embed-aspect-9-16 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<div class=\"embed-spotify\"><iframe title=\"Spotify Embed: Manic\" style=\"border-radius: 12px\" width=\"100%\" height=\"352\" frameborder=\"0\" allowfullscreen allow=\"autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture\" loading=\"lazy\" src=\"https://open.spotify.com/embed/album/68enXe5XcJdciSDAZr0Alr?si=SVjYONy3SF-EEm9Z1sD8WQ&amp;utm_source=oembed\"></iframe></div>\n</div></figure>\n\n\n\n<figure class=\"wp-block-embed-spotify wp-block-embed is-type-rich wp-embed-aspect-21-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<div class=\"embed-spotify\"><iframe title=\"Spotify Embed: #367: Eric Schmidt — Lessons from a Trillion-Dollar Coach\" style=\"border-radius: 12px\" width=\"100%\" height=\"152\" frameborder=\"0\" allowfullscreen allow=\"autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture\" loading=\"lazy\" src=\"https://open.spotify.com/embed/episode/3JWYGOLTj8A6e2B2NovbBL?utm_source=oembed\"></iframe></div>\n</div></figure>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31080,
            Title = "LEGACY: JUnit Debut",
            Slug = "junit-debut",
            Description = "I had a fairly productive day and I’m really happy a friend of mine reminded me of the importance of power naps. I was extremely sleepy at around 3pm and a 30 min nap completely...",
            CardImgUrl = "legacy-junit-debut.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/06/29/junit-debut/",
            ReleaseDate = new DateTime(2020, 6, 29),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">I had a fairly productive day and I&#8217;m really happy a friend of mine reminded me of the importance of power naps. I was extremely sleepy at around 3pm and a 30 min nap completely reenergised me so I got a lot done at the night time. I have to be consistent with those as it will increase my productivity and study capacity significantly.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Java Training</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Returning to Hibernate today after a good night of sleep wasn&#8217;t too bad. I have to remember that frameworks are always scary at first but once you spend some time with them you get used to it all. Today I learned the basics of yet another Java tool, J-Unit, which is a library made for Test Driven Development.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I can&#8217;t stress enough that this is the best course I&#8217;ve come across so far. Not only the instructor follows all best practices of the industry, he also uses a project for teaching (which I think is underrated) and explains everything thoroughly, which caters to beginners like me or to advanced users who may speed the videos up to pick up the important parts.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Arts</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I have a very consistent routine and given my priority in life right now is to study, all I do is sit on my computer or go to work. So I&#8217;ll provide variety in my life by immersing myself in the world of arts again. I used to be way better at this, always searching for new high quality music, literature and arts in general but it slowly faded as I got into the world of self-improvement and latin dance.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I read some self-help books that changed my life but now I&#8217;m ready to go back to literature using the incredible Audible, which allows me to get to know way more works that it&#8217;d be possible by just reading.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Also, being a dance teacher I had to listen to latin music most of the time for the last few years but in this new chapter of my life I&#8217;ll dive into the best of the music that&#8217;s being released now or that&#8217;s been released in the past few years so I can create a nice soundtrack for my life. I used to be really good at it, thanks to Alvaro Pereira Junior, music critic at Folha de Sao Paulo (the biggest newspaper in Brazil, who used to curate the latest music. He was responsible for some life-changing music in my life.</p>\n\n\n\n<p class=\"wp-block-paragraph\">The first work of my new artsy phase is the Album Fetch the Bolt Cutters by American singer Fiona Apple. It was a little bit beyond my musical tastes but I did save a couple of songs. My favourite track, &#8220;Ladies&#8221;, is not as untraditional as the rest of the album.</p>\n\n\n\n<figure class=\"wp-block-embed-spotify wp-block-embed is-type-rich wp-embed-aspect-9-16 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<div class=\"embed-spotify\"><iframe title=\"Spotify Embed: Fetch The Bolt Cutters\" style=\"border-radius: 12px\" width=\"100%\" height=\"352\" frameborder=\"0\" allowfullscreen allow=\"autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture\" loading=\"lazy\" src=\"https://open.spotify.com/embed/album/0fO1KemWL2uCCQmM22iKlj?si=eN0lxE2FSu2TuZeckrZy9g&amp;utm_source=oembed\"></iframe></div>\n</div></figure>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Podcast and Book</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Today&#8217;s podcast was with Murray Carter, a Canadien knives-maker. He has fantastic stories about his time in Japan. I find stories of craftsmanship fascinating and this one isn&#8217;t different. It&#8217;s obviously super inspiring right now as I&#8217;m learning the craft of programming. The podcast also made resurface curiosity about Japan and the importance of learning languages in general. I HAVE to visit one day.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;ve also continued &#8220;Meditations&#8221; by Marcus Aurelius. It&#8217;s a fantastic book to live by. Super simple and to the point. If anyone is having existential issues in life I can&#8217;t help but think reading this book over and over wouldn&#8217;t bring some tranquility.</p>\n\n\n\n<figure class=\"wp-block-embed-spotify wp-block-embed is-type-rich wp-embed-aspect-21-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<div class=\"embed-spotify\"><iframe title=\"Spotify Embed: #236: The Alien of Extraordinary Ability\" style=\"border-radius: 12px\" width=\"100%\" height=\"152\" frameborder=\"0\" allowfullscreen allow=\"autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture\" loading=\"lazy\" src=\"https://open.spotify.com/embed/episode/0Dnk8SRHmSbrvxPPmizB9j?si=_leBkwfHQ_KXHcC1s3HvxQ&amp;utm_source=oembed\"></iframe></div>\n</div></figure>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Today&#8217;s input</strong></p>\n\n\n\n<figure class=\"wp-block-embed-spotify wp-block-embed is-type-rich wp-embed-aspect-21-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<div class=\"embed-spotify\"><iframe title=\"Spotify Embed: #236: The Alien of Extraordinary Ability\" style=\"border-radius: 12px\" width=\"100%\" height=\"152\" frameborder=\"0\" allowfullscreen allow=\"autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture\" loading=\"lazy\" src=\"https://open.spotify.com/embed/episode/0Dnk8SRHmSbrvxPPmizB9j?si=_leBkwfHQ_KXHcC1s3HvxQ&amp;utm_source=oembed\"></iframe></div>\n</div></figure>\n\n\n\n<p class=\"wp-block-paragraph\"><a href=\"https://www.youtube.com/watch?v=0pfJ67R_RuA\">https://www.youtube.com/watch?v=0pfJ67R_RuA</a><br></p>\n\n\n\n<figure class=\"wp-block-embed-youtube wp-block-embed is-type-rich wp-embed-aspect-16-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<span class=\"embed-youtube\" style=\"text-align:center; display: block;\"><iframe loading=\"lazy\" class=\"youtube-player\" width=\"723\" height=\"407\" src=\"https://www.youtube.com/embed/21T5VngB6D8?version=3&#038;rel=1&#038;showsearch=0&#038;showinfo=1&#038;iv_load_policy=1&#038;fs=1&#038;hl=en&#038;autohide=2&#038;start=135&#038;wmode=transparent\" allowfullscreen=\"true\" style=\"border:0;\" sandbox=\"allow-scripts allow-same-origin allow-popups allow-presentation allow-popups-to-escape-sandbox\"></iframe></span>\n</div></figure>\n\n\n\n<figure class=\"wp-block-embed-youtube wp-block-embed is-type-rich wp-embed-aspect-16-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<span class=\"embed-youtube\" style=\"text-align:center; display: block;\"><iframe loading=\"lazy\" class=\"youtube-player\" width=\"723\" height=\"407\" src=\"https://www.youtube.com/embed/PMR0ld5h938?version=3&#038;rel=1&#038;showsearch=0&#038;showinfo=1&#038;iv_load_policy=1&#038;fs=1&#038;hl=en&#038;autohide=2&#038;wmode=transparent\" allowfullscreen=\"true\" style=\"border:0;\" sandbox=\"allow-scripts allow-same-origin allow-popups allow-presentation allow-popups-to-escape-sandbox\"></iframe></span>\n</div></figure>\n\n\n\n<figure class=\"wp-block-embed-youtube wp-block-embed is-type-rich wp-embed-aspect-16-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<span class=\"embed-youtube\" style=\"text-align:center; display: block;\"><iframe loading=\"lazy\" class=\"youtube-player\" width=\"723\" height=\"407\" src=\"https://www.youtube.com/embed/0pfJ67R_RuA?version=3&#038;rel=1&#038;showsearch=0&#038;showinfo=1&#038;iv_load_policy=1&#038;fs=1&#038;hl=en&#038;autohide=2&#038;wmode=transparent\" allowfullscreen=\"true\" style=\"border:0;\" sandbox=\"allow-scripts allow-same-origin allow-popups allow-presentation allow-popups-to-escape-sandbox\"></iframe></span>\n</div></figure>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31081,
            Title = "LEGACY: Hibernate Nightmare",
            Slug = "111",
            Description = "Java Training Today was one of those days that test the resilience of a programmer. I spent 95% of my coding hours handling project configuration problems and 5% coding. I’m wat...",
            CardImgUrl = "legacy-111.png",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/06/28/111/",
            ReleaseDate = new DateTime(2020, 6, 28),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\"><strong>Java Training</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Today was one of those days that test the resilience of a programmer. I spent 95% of my coding hours handling project configuration problems and 5% coding. I&#8217;m watching a JSP/Servlets course on Udemy based on a project that uses Hibernate and Maven and configuring the whole thing feels very intricate. It&#8217;s form after page after form after page of configurations. I wonder how someone would be able to figure all of those things out without tutorials.</p>\n\n\n\n<p class=\"wp-block-paragraph\">The answer for that is compounded experience I suppose. Nobody learned all of those things at once. They picked up that knowledge throughout many years of head-banging and keyboard-punching. And I know for sure all I have to do is stick to it and I&#8217;ll be mastering these skills soon too.<br>I&#8217;m glad I&#8217;m starting to go deep into Java. I&#8217;m learning tools that will make me an excellent back-end coder. It might be painful but I&#8217;ll have a strong, diversified portfolio in the next few months. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Exercising</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">After another week without missing a single session I took the day off this Sunday. But not quite. I started commuting to work using a bike so the first leg counts as exercise. But after only doing it for the 3rd time my knee already hurts. I&#8217;ll have to calm down a bit and alternate more bus and bike rides so my knees get used to the effort. I can&#8217;t go from zero to 50 rides a month just like that.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>World War II</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I didn&#8217;t listen to any podcasts today, but in the end of the day I read and watched a couple of things about WW2. It&#8217;s impossible not to get fascinated by those six years. I started with a couple of videos of D-day footage, then some about the german POWs in England and the US, read about the fall of Budapest to the Russians and finished reading about Auschwitz. The pictures of the death camp prisoners arriving with their families is powerful. We can never ever forget it so we don&#8217;t do it again.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><br><strong>Today&#8217;s Input</strong></p>\n\n\n\n<figure class=\"wp-block-embed-youtube wp-block-embed is-type-rich wp-embed-aspect-16-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<span class=\"embed-youtube\" style=\"text-align:center; display: block;\"><iframe loading=\"lazy\" class=\"youtube-player\" width=\"723\" height=\"407\" src=\"https://www.youtube.com/embed/3RfMzlS8OKM?version=3&#038;rel=1&#038;showsearch=0&#038;showinfo=1&#038;iv_load_policy=1&#038;fs=1&#038;hl=en&#038;autohide=2&#038;wmode=transparent\" allowfullscreen=\"true\" style=\"border:0;\" sandbox=\"allow-scripts allow-same-origin allow-popups allow-presentation allow-popups-to-escape-sandbox\"></iframe></span>\n</div></figure>\n\n\n\n<figure class=\"wp-block-embed-youtube wp-block-embed is-type-rich wp-embed-aspect-16-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<span class=\"embed-youtube\" style=\"text-align:center; display: block;\"><iframe loading=\"lazy\" class=\"youtube-player\" width=\"723\" height=\"407\" src=\"https://www.youtube.com/embed/nM6CzrQ2_BM?version=3&#038;rel=1&#038;showsearch=0&#038;showinfo=1&#038;iv_load_policy=1&#038;fs=1&#038;hl=en&#038;autohide=2&#038;wmode=transparent\" allowfullscreen=\"true\" style=\"border:0;\" sandbox=\"allow-scripts allow-same-origin allow-popups allow-presentation allow-popups-to-escape-sandbox\"></iframe></span>\n</div></figure>\n\n\n\n<figure class=\"wp-block-embed-youtube wp-block-embed is-type-rich wp-embed-aspect-16-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<span class=\"embed-youtube\" style=\"text-align:center; display: block;\"><iframe loading=\"lazy\" class=\"youtube-player\" width=\"723\" height=\"407\" src=\"https://www.youtube.com/embed/jUvcmGbtHWA?version=3&#038;rel=1&#038;showsearch=0&#038;showinfo=1&#038;iv_load_policy=1&#038;fs=1&#038;hl=en&#038;autohide=2&#038;wmode=transparent\" allowfullscreen=\"true\" style=\"border:0;\" sandbox=\"allow-scripts allow-same-origin allow-popups allow-presentation allow-popups-to-escape-sandbox\"></iframe></span>\n</div></figure>\n\n\n\n<figure class=\"wp-block-embed-youtube wp-block-embed is-type-rich wp-embed-aspect-16-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<span class=\"embed-youtube\" style=\"text-align:center; display: block;\"><iframe loading=\"lazy\" class=\"youtube-player\" width=\"723\" height=\"407\" src=\"https://www.youtube.com/embed/8qTVMu8JeW8?version=3&#038;rel=1&#038;showsearch=0&#038;showinfo=1&#038;iv_load_policy=1&#038;fs=1&#038;hl=en&#038;autohide=2&#038;wmode=transparent\" allowfullscreen=\"true\" style=\"border:0;\" sandbox=\"allow-scripts allow-same-origin allow-popups allow-presentation allow-popups-to-escape-sandbox\"></iframe></span>\n</div></figure>\n\n\n\n<p class=\"wp-block-paragraph\"></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31082,
            Title = "LEGACY: 1 Year Of Code",
            Slug = "1-year-of-code",
            Description = "Very interesting day! Java Training I just realised it’s been a year since I started my coding journey. I’ll write a post about that in detail, but it’s been an excellent year a...",
            CardImgUrl = "blog3.png",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/06/27/1-year-of-code/",
            ReleaseDate = new DateTime(2020, 6, 27),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">Very interesting day!</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Java Training</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I just realised it&#8217;s been a year since I started my coding journey. I&#8217;ll write a post about that in detail, but it&#8217;s been an excellent year and I&#8217;m sure I found my calling. I&#8217;ve never been so pumped up about anything in life as I am now. I&#8217;ve had long spells of excitement with poker and football, but there was always doubt about the future in those activities. With coding, I know it&#8217;s a lifelong commitment. I&#8217;ll code till the end.🙂</p>\n\n\n\n<p class=\"wp-block-paragraph\">Today I made a slight course correction. I&#8217;ve established that my number one priority is to have a strong portfolio that showcases my skills with projects that are common in the industry. I&#8217;ll keep developing apps to scratch my own itches but I think I have create a solid collection of works that are relevant in the industry and will get me hired. My objective is to have at least 12 strong projects in my 2 year coding anniversary. I don&#8217;t want to have any portfolio. I need to have a &#8220;wow, we need to hire him now&#8221; factor. And I&#8217;ll get there.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;m very exhausted so I&#8217;ll talk about the new Udemy course I bought and today&#8217;s podcast tomorrow.</p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31083,
            Title = "LEGACY: Creating a Portfolio",
            Slug = "creating-a-portfolio",
            Description = "Today I opened a new front of work and started working on my portfolio. I suspect a professional-looking and informative portfolio might tip the scale on my favour when I apply...",
            CardImgUrl = "legacy-creating-a-portfolio.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/06/26/creating-a-portfolio/",
            ReleaseDate = new DateTime(2020, 6, 26),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">Today I opened a new front of work and started working on my portfolio. I suspect a professional-looking and informative portfolio might tip the scale on my favour when I apply for jobs, so I&#8217;ll invest a lot of energy into building something appealing.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Obviously I&#8217;ll keep working on the contents of the portfolio, especially the Java stuff and will polish it based on portfolio reviews on youtube. Today I watched this one:<br></p>\n\n\n\n<figure class=\"wp-block-embed-youtube wp-block-embed is-type-rich wp-embed-aspect-16-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<span class=\"embed-youtube\" style=\"text-align:center; display: block;\"><iframe loading=\"lazy\" class=\"youtube-player\" width=\"723\" height=\"407\" src=\"https://www.youtube.com/embed/BiTuzeyDx6Y?version=3&#038;rel=1&#038;showsearch=0&#038;showinfo=1&#038;iv_load_policy=1&#038;fs=1&#038;hl=en&#038;autohide=2&#038;start=638&#038;wmode=transparent\" allowfullscreen=\"true\" style=\"border:0;\" sandbox=\"allow-scripts allow-same-origin allow-popups allow-presentation allow-popups-to-escape-sandbox\"></iframe></span>\n</div></figure>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Java Training</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I planned to start studying Spring today but I got really busy working on my budget app, so I&#8217;ll probably start tomorrow. The budget app will be similar to the sleep app but I&#8217;ll try to dig further into complex search queries and building charts for presentation. I&#8217;ll also try to make it look prettier. The sleep app looks like some 90&#8217;s desktop app.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Podcast and Book</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Today I listened to David Yarrow&#8217;s interview on Tim Ferriss show. He&#8217;s a photographer and hedge fund manager. His thought process is a little bit hard to follow, but he&#8217;s another great dude with the plus of being scottish. The scots I know have great sense of humor and don&#8217;t take themselves too seriously, too qualities I appreciate a lot. Some bullet points:</p>\n\n\n\n<ul class=\"wp-block-list\"><li>Looking for the meaning of your craft: &#8220;I was taking just another picture the world didn&#8217;t need&#8221;.</li><li>&#8220;Rock bottom was the solid foundation from which I built my life&#8221;</li><li>The need of third party validation</li><li>Not falling into the rabbit hole of being preoccupied with the severity of circumstances</li></ul>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31084,
            Title = "LEGACY: Nick Szabo – Master of Cryptocurrency",
            Slug = "nick-szabo-master-of-cryptocurrency",
            Description = "Java Training Today I created my first successful .jar file, which means I coded an application from scratch to deployment. It’s a very ugly sleep log app but I’m very proud of...",
            CardImgUrl = "legacy-nick-szabo-master-of-cryptocurrency.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/06/25/nick-szabo-master-of-cryptocurrency/",
            ReleaseDate = new DateTime(2020, 6, 25),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\"><strong>Java Training</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Today I created my first successful .jar file, which means I coded an application from scratch to deployment. It&#8217;s a very ugly sleep log app but I&#8217;m very proud of it. It will be interesting looking at it ten years from now when I&#8217;m building fancy stuff.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I promised myself I was going to start building my budget app today but it took me a long time to troubleshoot the jar file creation and I ended up running out of time.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;ll probably make a tutorial about it in the near future, but it will probably be a side project, as I still have to learn important things like Spring and Hibernate frameworks. In practice my next big goals are to be able to create web and mobile apps.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Two Weeks as a Permanent Residen</strong>t</p>\n\n\n\n<p class=\"wp-block-paragraph\">It&#8217;s interesting that at the same time that I got my residency I also got down to having ZERO dollars (literally). Covid-19 destroyed what was left of my savings and for a couple of months now I&#8217;ve been living from pay check to pay check, with very little room for contingencies. At the same time that it&#8217;s a bit scary, it makes me think that I&#8217;m starting from scratch. I have a blank canvas in front of me and I&#8217;do my best to make the most of it.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;ve established a very solid routine and I&#8217;m laying the foundations for my future investing energy in my education and friendships, the things that will carry me through the rest of my life</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>It&#8217;s hard</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">It&#8217;s hard to see your loved ones suffering. I&#8217;ve been really good at maintaining my mental fortitude during the difficulties of the past year but I had a hard time today seeing my grandma in pain from a fall and my mom suffering because of that. It&#8217;s probably my only fear. Being or seeing my loved ones in pain. I&#8217;m definitely not afraid of death or of getting old. But acute suffering is something that hits me hard. My respect for people who work directly with suffering. It can&#8217;t be easy.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Podcast</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Today&#8217;s podcast was with Nick Szabo. I won&#8217;t write much about it because the topics were so above my head so I&#8217;ll have to listen to it again. Nick is a specialist in cryptocurrency and blockchain technologies and he guarantees the world as we know it will change very dramatically very soon. Cryptocurrency has the power to change the way we exchange stuff rendering all sorts of financial careers obsolete. I&#8217;ll be writing more about it soon once I do more research.<br></p>\n\n\n\n<figure class=\"wp-block-embed-spotify wp-block-embed is-type-rich wp-embed-aspect-21-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<div class=\"embed-spotify\"><iframe title=\"Spotify Embed: #244: The Quiet Master of Cryptocurrency -- Nick Szabo\" style=\"border-radius: 12px\" width=\"100%\" height=\"152\" frameborder=\"0\" allowfullscreen allow=\"autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture\" loading=\"lazy\" src=\"https://open.spotify.com/embed/episode/20lvcYTdBm8awd9ueF9QH9?utm_source=oembed\"></iframe></div>\n</div></figure>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31085,
            Title = "LEGACY: Volunteering Work",
            Slug = "volunteering-work",
            Description = "Java Training I barely had time to code today but when I did I advanced a bit more on my JavaFX training, learning how to create charts with data from a database.I’ve decided to...",
            CardImgUrl = "legacy-volunteering-work.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/06/24/volunteering-work/",
            ReleaseDate = new DateTime(2020, 6, 24),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\"><strong>Java Training</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I barely had time to code today but when I did I advanced a bit more on my JavaFX training, learning how to create charts with data from a database.<br>I&#8217;ve decided to start my budget app tomorrow to start implementing more functionalities since the queries will be more complicated. I might even simultaneously start my coding tracker app so I can always switch between projects when I&#8217;m getting tired to get an energy boost.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Volunteering</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I did a very small volunteering web-development job for a non-profit organisation in New Zealand. It was really tiny and it took me half an hour to complete but it feels great to help someone with nothing in return. I&#8217;ll definitely include volunteering hours in my IT practices more often.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Sleep</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">In the past few months I&#8217;ve been realising I sleep way more if I go to bed at 11. I&#8217;m not sure how it&#8217;s possible that if I go to bed at 9 or 10 I&#8217;ll struggle to sleep 6h, but If it happens at 11 I&#8217;ll probably sleep at least 7hs. How does that make sense?</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Gym</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I completed 3 weeks without missing a single gym session. Since the gyms reopened I&#8217;ve been very disciplined. I&#8217;m very proud. However now I need to include more cardios training in my routine. I&#8217;m getting paid tomorrow so I&#8217;ll start using the City Bikes to go to and from work, which will save me some money and make me healthier.🙂</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Podcast</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Today&#8217;s podcast was with BIll Rasmussen, co-founder of ESPN. Some key bullet-points.</p>\n\n\n\n<ul class=\"wp-block-list\"><li>The story of how he started his career including sports scores in the weather report</li><li>The story of ESPN and how everyone said he&#8217;d fail in the beginning</li><li>The difference in the philosophy between ABC and NBC back in the day: &#8220;don&#8217;t rock the boat&#8221; vs &#8220;always try new ideas&#8221;</li><li>Calling the top cable companies thinking nobody would agree to meet and all agreed</li><li>Having a short and simple mission-statement</li></ul>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Today&#8217;s Input</strong></p>\n\n\n\n<figure class=\"wp-block-embed-spotify wp-block-embed is-type-rich wp-embed-aspect-21-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<div class=\"embed-spotify\"><iframe title=\"Spotify Embed: #258: From Long-Shot to $50 Billion Empire - Bill Rasmussen\" style=\"border-radius: 12px\" width=\"100%\" height=\"152\" frameborder=\"0\" allowfullscreen allow=\"autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture\" loading=\"lazy\" src=\"https://open.spotify.com/embed/episode/45GjqCIsZ0AppfOhamxEGG?utm_source=oembed\"></iframe></div>\n</div></figure>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31086,
            Title = "LEGACY: Michael Gervais",
            Slug = "michael-gervais",
            Description = "Java Training I Had a very busy day at so I could only study for 6 pomodoros (2:30) but I made some progress in understanding how form validation works with JavaFX. This is one...",
            CardImgUrl = "legacy-michael-gervais.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/06/23/michael-gervais/",
            ReleaseDate = new DateTime(2020, 6, 23),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\"><strong>Java Training</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I Had a very busy day at so I could only study for 6 pomodoros (2:30) but I made some progress in understanding how form validation works with JavaFX. </p>\n\n\n\n<p class=\"wp-block-paragraph\">This is one of those subjects that every developer has to deal with. Since when I first started fiddling with JavaScript I was already playing around with forms and I don’t think it will ever go away.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Tomorrow I might start working on my budget app so I can learn more advanced functionalities such as magic a login system and more complicated queries to the database</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Podcast and boo</strong>k</p>\n\n\n\n<p class=\"wp-block-paragraph\">Today’s podcast was with Michael Gervais, psychology specialised in sports. So much great advice. Some bullet points:</p>\n\n\n\n<ul class=\"wp-block-list\"><li>&nbsp;You don’t need motivation techniques if you do what makes you tick&nbsp;</li><li>Meditation won&#8217;t necessarily teach you to avoid thinking, but it will teach how to come back from thinking to focus</li><li>Paying true attention on personal interactions</li><li>Success: Having a sense of peace while being useful to your community.</li><li>To search for authenticity, moving as deep as you can to places that are uncomfortable.</li></ul>\n\n\n\n<p class=\"wp-block-paragraph\">Unfortunately I&#8217;m too exhausted to write about the books I&#8217;m reading today:</p>\n\n\n\n<p class=\"wp-block-paragraph\"><a href=\"https://www.amazon.com.au/Meditations-Marcus-Aurelius/dp/0140449337/ref=asc_df_0140449337/?tag=googleshopdsk-22&amp;linkCode=df0&amp;hvadid=341773624021&amp;hvpos=&amp;hvnetw=g&amp;hvrand=8170733919429135968&amp;hvpone=&amp;hvptwo=&amp;hvqmt=&amp;hvdev=c&amp;hvdvcmdl=&amp;hvlocint=&amp;hvlocphy=9069099&amp;hvtargid=pla-448425242835&amp;psc=1\">Meditations by Marcus Aurelius</a></p>\n\n\n\n<p class=\"wp-block-paragraph\"><a href=\"https://www.amazon.com.au/Habits-Highly-Effective-People-Powerful-ebook/dp/B07WF972WK/ref=sr_1_2?crid=QS1BDC5MSAL&amp;dchild=1&amp;keywords=7+habits+of+highly+effective+people&amp;qid=1592919081&amp;s=books&amp;sprefix=7+%2Cstripbooks%2C357&amp;sr=1-2\">7 Habits of Highly Effective People<br></a></p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Today&#8217;s input:</strong></p>\n\n\n\n<figure class=\"wp-block-embed-youtube wp-block-embed is-type-rich wp-embed-aspect-16-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<span class=\"embed-youtube\" style=\"text-align:center; display: block;\"><iframe loading=\"lazy\" class=\"youtube-player\" width=\"723\" height=\"407\" src=\"https://www.youtube.com/embed/tZvjSl9dswg?version=3&#038;rel=1&#038;showsearch=0&#038;showinfo=1&#038;iv_load_policy=1&#038;fs=1&#038;hl=en&#038;autohide=2&#038;start=152&#038;wmode=transparent\" allowfullscreen=\"true\" style=\"border:0;\" sandbox=\"allow-scripts allow-same-origin allow-popups allow-presentation allow-popups-to-escape-sandbox\"></iframe></span>\n</div></figure>\n\n\n\n<figure class=\"wp-block-embed-spotify wp-block-embed is-type-rich wp-embed-aspect-21-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<div class=\"embed-spotify\"><iframe title=\"Spotify Embed: #256: How to Overcome Anxiety and Stress - with Adviser to Olympians, Michael Gervais\" style=\"border-radius: 12px\" width=\"100%\" height=\"152\" frameborder=\"0\" allowfullscreen allow=\"autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture\" loading=\"lazy\" src=\"https://open.spotify.com/embed/episode/0C1XPe4tRamlOzt7OYLnvU?utm_source=oembed\"></iframe></div>\n</div></figure>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31087,
            Title = "LEGACY: Mark Bell",
            Slug = "mark-bell",
            Description = "Java Training Today I was able to code for 8 pomodoros (3h20) and I gained some ground on my sleep app and built the bulk of the functionalities I want. As I said yesterday I de...",
            CardImgUrl = "legacy-mark-bell.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/06/22/mark-bell/",
            ReleaseDate = new DateTime(2020, 6, 22),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\"><strong>Java Training</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Today I was able to code for 8 pomodoros (3h20) and I gained some ground on my sleep app and built the bulk of the functionalities I want. As I said yesterday I decided to query the database based on certain criteria instead of creating another database for each week, month or whatever else I wanted. I&#8217;ll probably keep working on it for a week until I start my next app.<br>I was watching videos about the importance of portfolios to get the first developer job. Looks like it&#8217;s one of the most important items of your resume as it&#8217;s an opportunity to show my skills. I&#8217;ll keep pushing the envelope with increasingly complex functionalities until I&#8217;m so good they can&#8217;t ignore me. By the way, there&#8217;s a book with this name. One of the best I&#8217;ve read. I highly recommend it.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Podcast and Book</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">In the morning I was able to follow all my morning routines and decided to vary a little bit with my podcasts again, this time with a specialist in weightlifting. His name Mark Bell and he owns an extremely successful gym in Sacramento, CA. To be honest I&#8217;m not a big fan of guys that clearly take steroids. Tim had two or three of those and they were great interviews but for me it&#8217;s hard to consider someone that advocates &#8220;strength training&#8221; when they&#8217;re cheating the system with something proved extremely unhealthy. Especially when they don&#8217;t admit it.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Having said that, I love his obsession with his craft and of course there&#8217;s stuff to learn from him in terms of the specifics of lifting. And close to the end he defines success as doing the right thing for a long period of time, mentioning his dad, who he&#8217;s never seen looking to another woman, however gorgeous she was, in respect to his wife.</p>\n\n\n\n<p class=\"wp-block-paragraph\">A few days ago I started reading &#8220;7 Habits of Highly Successful People&#8221;. I&#8217;ve read about a quarter of it and it sounds very repetitive for someone who&#8217;s been reading these types of books so far, but I&#8217;ve had so many well-read people recommend it that I&#8217;ll keep going. I&#8217;ll be posting some of the things I&#8217;ve been marking in the next few days.</p>\n\n\n\n<p class=\"wp-block-paragraph\">There&#8217;s something I haven&#8217;t mentioned yet as well but I listen to this show by an amazing Brazilian journalist called Luis Nassif. He&#8217;s able to summarise and explain what&#8217;s going on in Brazilian economy and politics so I don&#8217;t need to spend too much time reading anything else.<br>By the way, congratulations to me! I&#8217;ve posted for 8 days! And I have a pretty solid routine right now so I think I&#8217;ll be able to keep post daily. Let&#8217;s see!</p>\n\n\n\n<p class=\"wp-block-paragraph\"><br><strong>Today&#8217;s inputs</strong></p>\n\n\n\n<figure class=\"wp-block-embed-spotify wp-block-embed is-type-rich wp-embed-aspect-21-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<div class=\"embed-spotify\"><iframe title=\"Spotify Embed: #252: Inside the World of SuperTraining - Mark Bell\" style=\"border-radius: 12px\" width=\"100%\" height=\"152\" frameborder=\"0\" allowfullscreen allow=\"autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture\" loading=\"lazy\" src=\"https://open.spotify.com/embed/episode/52N1iLGL6qYjHsv34fGeGa?utm_source=oembed\"></iframe></div>\n</div></figure>\n\n\n\n<figure class=\"wp-block-embed-youtube wp-block-embed is-type-rich wp-embed-aspect-16-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<span class=\"embed-youtube\" style=\"text-align:center; display: block;\"><iframe loading=\"lazy\" class=\"youtube-player\" width=\"723\" height=\"407\" src=\"https://www.youtube.com/embed/BZLLP7Gk3ps?version=3&#038;rel=1&#038;showsearch=0&#038;showinfo=1&#038;iv_load_policy=1&#038;fs=1&#038;hl=en&#038;autohide=2&#038;wmode=transparent\" allowfullscreen=\"true\" style=\"border:0;\" sandbox=\"allow-scripts allow-same-origin allow-popups allow-presentation allow-popups-to-escape-sandbox\"></iframe></span>\n</div></figure>\n\n\n\n<figure class=\"wp-block-embed-youtube wp-block-embed is-type-rich wp-embed-aspect-16-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<span class=\"embed-youtube\" style=\"text-align:center; display: block;\"><iframe loading=\"lazy\" class=\"youtube-player\" width=\"723\" height=\"407\" src=\"https://www.youtube.com/embed/l7ByJtQ8bv4?version=3&#038;rel=1&#038;showsearch=0&#038;showinfo=1&#038;iv_load_policy=1&#038;fs=1&#038;hl=en&#038;autohide=2&#038;wmode=transparent\" allowfullscreen=\"true\" style=\"border:0;\" sandbox=\"allow-scripts allow-same-origin allow-popups allow-presentation allow-popups-to-escape-sandbox\"></iframe></span>\n</div></figure>\n\n\n\n<figure class=\"wp-block-embed-youtube wp-block-embed is-type-rich wp-embed-aspect-16-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<span class=\"embed-youtube\" style=\"text-align:center; display: block;\"><iframe loading=\"lazy\" class=\"youtube-player\" width=\"723\" height=\"407\" src=\"https://www.youtube.com/embed/TK_vuyJTqfA?version=3&#038;rel=1&#038;showsearch=0&#038;showinfo=1&#038;iv_load_policy=1&#038;fs=1&#038;hl=en&#038;autohide=2&#038;wmode=transparent\" allowfullscreen=\"true\" style=\"border:0;\" sandbox=\"allow-scripts allow-same-origin allow-popups allow-presentation allow-popups-to-escape-sandbox\"></iframe></span>\n</div></figure>\n\n\n\n<figure class=\"wp-block-embed-youtube wp-block-embed is-type-rich wp-embed-aspect-16-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<span class=\"embed-youtube\" style=\"text-align:center; display: block;\"><iframe loading=\"lazy\" class=\"youtube-player\" width=\"723\" height=\"407\" src=\"https://www.youtube.com/embed/0JmHEbrP4ug?version=3&#038;rel=1&#038;showsearch=0&#038;showinfo=1&#038;iv_load_policy=1&#038;fs=1&#038;hl=en&#038;autohide=2&#038;start=3169&#038;wmode=transparent\" allowfullscreen=\"true\" style=\"border:0;\" sandbox=\"allow-scripts allow-same-origin allow-popups allow-presentation allow-popups-to-escape-sandbox\"></iframe></span>\n</div></figure>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31088,
            Title = "LEGACY: Quiet Sunday",
            Slug = "quiet-sunday",
            Description = "Java Training I was able to code for 6 Pomodoros today. Right now I’m working on retrieving weekly data from my sleep records on my Sleep App but I decided to change approaches....",
            CardImgUrl = "legacy-quiet-sunday.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/06/21/quiet-sunday/",
            ReleaseDate = new DateTime(2020, 6, 21),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\"><strong>Java Training</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I was able to code for 6 Pomodoros today. Right now I&#8217;m working on retrieving weekly data from my sleep records on my Sleep App but I decided to change approaches. I was trying to create a database for each week but I&#8217;ll try an approach where I just query the database per week instead. Instead of creating a switch with hundreds of week cases I&#8217;ll just create a week column on the database and then query based on weeks and months. I think it&#8217;s a more economic and less resources-demanding approach. I&#8217;ll keep working on it tomorrow.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Quiet Sunday</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I didn&#8217;t have a super eventful Sunday. After coding I had a quick 25 min power nap, which gave me some energy but then I just went to work and caught up with three friends. After coding, this is the thing I love the most. Sitting down with friends and having intellectually stimulating conversations.<br>I took the day off of exercising, I read very little and I only listened to a small portion of a podcast with Tim Ferriss himself.</p>\n\n\n\n<p class=\"wp-block-paragraph\">T<strong>oday&#8217;s inputs</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I watched some videos with fantastic ideas for Java projects (especially the second one). Read an article about Trump&#8217;s rallies and listened to to Tim Ferriss Show Episode 299 with highly actionable strategies for life. </p>\n\n\n\n<figure class=\"wp-block-embed-youtube wp-block-embed is-type-rich wp-embed-aspect-16-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<span class=\"embed-youtube\" style=\"text-align:center; display: block;\"><iframe loading=\"lazy\" class=\"youtube-player\" width=\"723\" height=\"407\" src=\"https://www.youtube.com/embed/7XIduOKTaM0?version=3&#038;rel=1&#038;showsearch=0&#038;showinfo=1&#038;iv_load_policy=1&#038;fs=1&#038;hl=en&#038;autohide=2&#038;wmode=transparent\" allowfullscreen=\"true\" style=\"border:0;\" sandbox=\"allow-scripts allow-same-origin allow-popups allow-presentation allow-popups-to-escape-sandbox\"></iframe></span>\n</div></figure>\n\n\n\n<figure class=\"wp-block-embed-youtube wp-block-embed is-type-rich wp-embed-aspect-16-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<span class=\"embed-youtube\" style=\"text-align:center; display: block;\"><iframe loading=\"lazy\" class=\"youtube-player\" width=\"723\" height=\"407\" src=\"https://www.youtube.com/embed/LijQVp1br6o?version=3&#038;rel=1&#038;showsearch=0&#038;showinfo=1&#038;iv_load_policy=1&#038;fs=1&#038;hl=en&#038;autohide=2&#038;wmode=transparent\" allowfullscreen=\"true\" style=\"border:0;\" sandbox=\"allow-scripts allow-same-origin allow-popups allow-presentation allow-popups-to-escape-sandbox\"></iframe></span>\n</div></figure>\n\n\n\n<figure class=\"wp-block-embed is-type-rich\"><div class=\"wp-block-embed__wrapper\">\n<div class=\"embed-thenewyorktimes\"><iframe title=\"Trump Rally Fizzles as Attendance Falls Short of Campaign’s Expectations\" src=\"https://www.nytimes.com/svc/oembed/html/?url=https%3A%2F%2Fwww.nytimes.com%2F2020%2F06%2F20%2Fus%2Fpolitics%2Ftulsa-trump-rally.html\" scrolling=\"no\" frameborder=\"0\" allowtransparency=\"true\" style=\"border:none;max-width:500px;min-width:300px;min-height:550px;display:block;width:100%;\"></iframe></div>\n</div></figure>\n\n\n\n<figure class=\"wp-block-embed-spotify wp-block-embed is-type-rich wp-embed-aspect-21-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<div class=\"embed-spotify\"><iframe title=\"Spotify Embed: #299: How to Secure Financial Freedom, Maximize Productivity, and Protect Your Health\" style=\"border-radius: 12px\" width=\"100%\" height=\"152\" frameborder=\"0\" allowfullscreen allow=\"autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture\" loading=\"lazy\" src=\"https://open.spotify.com/embed/episode/72W5NdG6zre5d7g2DfZA8a?utm_source=oembed\"></iframe></div>\n</div></figure>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31089,
            Title = "LEGACY: Karlie Kloss",
            Slug = "karlie-kloss",
            Description = "Java Training Unfortunately I only had time for 4 pomodoros (1h55′) but I made some progress with my sleep app. I was able to successfully increase the separation of concerns. I...",
            CardImgUrl = "legacy-karlie-kloss.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/06/20/karlie-kloss/",
            ReleaseDate = new DateTime(2020, 6, 20),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\"><strong>Java Training</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Unfortunately I only had time for 4 pomodoros (1h55&#8242;) but I made some progress with my sleep app. I was able to successfully increase the separation of concerns. I had a class getting bloated with methods dealing with too many variations of queries to the DB.</p>\n\n\n\n<p class=\"wp-block-paragraph\">In terms of user interface, for the first time I was able to switch between scenes on JavaFX, which gives me an infinite amount of possibilities to deal with the data. I&#8217;ll keep trying to perfect the sleep app for about a week before starting another one.</p>\n\n\n\n<p class=\"wp-block-paragraph\">What I have in mind for the next app is very simple. I&#8217;ll track and store data related to the amount of time I study. It will be a very simple app that will store data from a session upon its end. An interesting challenge. Sessions still look scary to me and I&#8217;m not even sure it&#8217;s possible to do it without the use of some framework. I&#8217;d like to study java for at least another couple of months before trying to learn a frame work. But I might start using libraries like Apache before that</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Religion and Politic</strong>s</p>\n\n\n\n<p class=\"wp-block-paragraph\">Today I had a somewhat heated discussion with my mom over philosophy and religion. We have fundamentally different views of metaphysics and whenever we go down that road it doesn&#8217;t end well. I have to promise myself I&#8217;ll refrain to debate religion with her or anyone. There&#8217;s nothing to gain from it. Especially considering that everyone will perish regardless of their faith (or lack thereof).</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Podcast</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">The last few podcasts I listened to were all from successful businessmen. I diversified a bit listening to Karlie Kloss (episode 307). She&#8217;s a supermodel in her twenties. I wasn&#8217;t expecting to identify with much of her trajectory but as soon as the podcast started, surprise! She&#8217;s a coder! haha. And not only that. She has a company that runs bootcamps for girls aged 13-18. Tell me about having an impact in the world. Enabling thousands of young girls to learn what many believe to be the next literacy. Fantastic stuff.<br>Obviously her thinking and world views aren&#8217;t as sophisticated as most of the interviewees of Tim&#8217;s podcast but I did extract a few good points</p>\n\n\n\n<ul class=\"wp-block-list\"><li>Considerations about learning to code and opening a company</li><li>Having a &#8220;who to talk to&#8221; list and not just a &#8220;to do&#8221; list</li><li>The importance of staying grounded and disciplined even after becoming extremely successful</li></ul>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Nap</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I have to create the habit of napping more often. My least productive time of the day is from 2-5. I feel extremely sluggish, especially in the days where I wake up from 3:30 to 5:30. I used to think a full-fledged &#8220;siesta&#8221; was necessary, but after having done it a couple of times I realise a &#8220;power nap&#8221; is reinvigorating enough to make me way more focused from the afternoon on.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Today&#8217;s Inputs</strong></p>\n\n\n\n<ul class=\"wp-block-list\"><li>A small video about uses of Raspberry PI</li></ul>\n\n\n\n<figure class=\"wp-block-embed-youtube wp-block-embed is-type-rich wp-embed-aspect-16-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<span class=\"embed-youtube\" style=\"text-align:center; display: block;\"><iframe loading=\"lazy\" class=\"youtube-player\" width=\"723\" height=\"407\" src=\"https://www.youtube.com/embed/ZXpGNBzHKRY?version=3&#038;rel=1&#038;showsearch=0&#038;showinfo=1&#038;iv_load_policy=1&#038;fs=1&#038;hl=en&#038;autohide=2&#038;wmode=transparent\" allowfullscreen=\"true\" style=\"border:0;\" sandbox=\"allow-scripts allow-same-origin allow-popups allow-presentation allow-popups-to-escape-sandbox\"></iframe></span>\n</div></figure>\n\n\n\n<ul class=\"wp-block-list\"><li>A scary article about a handful of deaths of black men by hanging in America recently. Too much of a coincidence in my opinion.</li></ul>\n\n\n\n<figure class=\"wp-block-embed aligncenter is-type-rich\"><div class=\"wp-block-embed__wrapper\">\n<div class=\"embed-thenewyorktimes\"><iframe title=\"In California, Hanging Deaths of Two Black Men Summon a Dark History and F.B.I. Scrutiny\" src=\"https://www.nytimes.com/svc/oembed/html/?url=https%3A%2F%2Fwww.nytimes.com%2F2020%2F06%2F19%2Fus%2Fhanging-deaths-california.html\" scrolling=\"no\" frameborder=\"0\" allowtransparency=\"true\" style=\"border:none;max-width:500px;min-width:300px;min-height:550px;display:block;width:100%;\"></iframe></div>\n</div></figure>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31090,
            Title = "LEGACY: Ricardo Semler",
            Slug = "ricardo-semler",
            Description = "Java Training What a fantastic day!! I studied for around 3:20 (8 Pomodoros) and for the first time I felt like I was actually CREATING in Java. It’s such a fantastic sensation....",
            CardImgUrl = "legacy-ricardo-semler.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/06/19/ricardo-semler/",
            ReleaseDate = new DateTime(2020, 6, 19),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\"><strong>Java Training</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">What a fantastic day!! I studied for around 3:20 (8 Pomodoros) and for the first time I felt like I was actually CREATING in Java. It&#8217;s such a fantastic sensation. It&#8217;s the feeling of having a powerful magic wand in my hands. I can literally create anything I want and I&#8217;m only scratching the surface of the surface.</p>\n\n\n\n<p class=\"wp-block-paragraph\">All my experiences trying to create anything with code, since my teenage-hood making making my first websites, always felt somewhat constrained but this time I really feel like the sky is the limit. Now I understand why coders have no problem staying home on the computer while everyone else is having fun.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Now, down to the concrete stuff. I&#8217;m still using the app I created in the tutorial as the foundation for my sleep app but today I created some important modifications. I was able to calculate the duration of my sleep and attach it to the database. Then I wrote some code to store the entries in separate databases by week and populated a second table with the entries of the week. This involved operations with times, which scares me a little bit, so it&#8217;s excellent training for me.Tomorrow I&#8217;ll try to create a search button so I can access the different weeks and also create a monthly record. I&#8217;m extremely excited.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Gym and Podcast</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">During my gym session today I listened to another great podcast, with Ricardo Semler. Basically what I&#8217;m doing with these podcasts is to go back on the Tim Ferriss&#8217; Show list and find the ones I haven&#8217;t listened to yet. I always stayed away from the ones that seemed overly business-oriented but they&#8217;re turning out to contain many pearls<br>Ricardo is a very well-read entrepreneur and has strong views on management and work ethics and a very sophisticated overall take on life. Some of his highlights:</p>\n\n\n\n<ul class=\"wp-block-list\"><li>Asking 3 consecutive why&#8217;s about everything you do</li><li>Burn all past to be able to move forward</li><li>Having free time to actually understand what you want to do</li><li>Successfully wasting time</li><li>Living in the present, moments can&#8217;t never be taken away from you</li></ul>\n\n\n\n<p class=\"wp-block-paragraph\">Obviously these are just bullet points that don&#8217;t make justice to the actual podcast. I highly recommend it.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Input List</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Today I was able to have complete control over what I read. I didn&#8217;t read or watch anything impulsively. It felt great not to be drawn into some headline.<br></p>\n\n\n\n<figure class=\"wp-block-embed-spotify wp-block-embed is-type-rich wp-embed-aspect-21-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<div class=\"embed-spotify\"><iframe title=\"Spotify Embed: #229: Ricardo Semler -- The Seven-Day Weekend and How to Break the Rules\" style=\"border-radius: 12px\" width=\"100%\" height=\"152\" frameborder=\"0\" allowfullscreen allow=\"autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture\" loading=\"lazy\" src=\"https://open.spotify.com/embed/episode/0jvsv1112St7e4VJIVv1Qs?si=SwsAwSQYSzahof7qr5illA&amp;utm_source=oembed\"></iframe></div>\n</div></figure>\n\n\n\n<figure class=\"wp-block-embed-youtube wp-block-embed is-type-rich wp-embed-aspect-16-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<span class=\"embed-youtube\" style=\"text-align:center; display: block;\"><iframe loading=\"lazy\" class=\"youtube-player\" width=\"723\" height=\"407\" src=\"https://www.youtube.com/embed/6rxWc-TNIJI?version=3&#038;rel=1&#038;showsearch=0&#038;showinfo=1&#038;iv_load_policy=1&#038;fs=1&#038;hl=en&#038;autohide=2&#038;start=326&#038;wmode=transparent\" allowfullscreen=\"true\" style=\"border:0;\" sandbox=\"allow-scripts allow-same-origin allow-popups allow-presentation allow-popups-to-escape-sandbox\"></iframe></span>\n</div></figure>\n\n\n\n<figure class=\"wp-block-embed-youtube wp-block-embed is-type-rich wp-embed-aspect-16-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<span class=\"embed-youtube\" style=\"text-align:center; display: block;\"><iframe loading=\"lazy\" class=\"youtube-player\" width=\"723\" height=\"407\" src=\"https://www.youtube.com/embed/xfBWk4nw440?version=3&#038;rel=1&#038;showsearch=0&#038;showinfo=1&#038;iv_load_policy=1&#038;fs=1&#038;hl=en&#038;autohide=2&#038;start=1&#038;wmode=transparent\" allowfullscreen=\"true\" style=\"border:0;\" sandbox=\"allow-scripts allow-same-origin allow-popups allow-presentation allow-popups-to-escape-sandbox\"></iframe></span>\n</div></figure>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31091,
            Title = "LEGACY: John Paul DeJoria",
            Slug = "john-paul-dejoria",
            Description = "Java Training I managed to study for 3hs (7 pomodoros)!! I want to consistently do at least twice as long but considering I’ve barely studied for a week this was great. I finish...",
            CardImgUrl = "blog2.png",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/06/18/john-paul-dejoria/",
            ReleaseDate = new DateTime(2020, 6, 18),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\"><strong>Java Training</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I managed to study for 3hs (7 pomodoros)!! I want to consistently do at least twice as long but considering I&#8217;ve barely studied for a week this was great. I finished replicating the small app I created with the help of a tutorial and now I&#8217;m using it as a foundation to build my first app, a sleep tracker.</p>\n\n\n\n<p class=\"wp-block-paragraph\">When I started diving into the modifications I want to make I felt like a kid who&#8217;s just learned how to swim in a pool and is dropped in the middle of the ocean. From now on it&#8217;s on me. I felt stuck but breaking through will provide the best possible lerning. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>One Week of Permanent Residency</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;m still living in the afterglow of receiving my residency. But the anxiety isn&#8217;t completely gone yet. A small part of me still expects the worse every time I open my e-mail. A new e-mail from immigration stating &#8220;Visa Revoked&#8221; or something.</p>\n\n\n\n<p class=\"wp-block-paragraph\">To be honest, something like that would catch me off-guard but as a follower of stoicism I always try to think of the worst case scenarios so the bad things that will inevitably happen on my life don&#8217;t knock me out. It&#8217;s a very good mindset. Thinking that everything we have right now could disappear (and it could), not only prevents a total implosion of oneself if it happens but it also creates more appreciation for these things.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Gym and Podcast</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Today was the beginning of my third week back to the gym after covid, without missing a session. I only rested on the Sundays. And while I trained I listened to the newest episode on Tim Ferriss Podcast, with the entrepreneur John Paul DeJoria, co-founder of Paul Mitchell and Patrón spirits. Another fantastic character. His story is the typical American dream tale, going from poverty to billionaire.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><br>He&#8217;s a fantastic salesman and he sounds like one, so at the beginning I didn&#8217;t think it was great, but the interview has some pearls for sales, entrepreneurship and life management. The biggest one for me, worded in a way I haven&#8217;t heard before is: &#8220;Some people you have to love from afar&#8221;. That&#8217;s fantastic advice. All of us have people that are good to us and that we appreciate but that aren&#8217;t good company or just incompatible. And it&#8217;s ok to exclude them from our lives. We don&#8217;t need to be rude or mean, we just need to drift and love them from distance.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Input List</strong></p>\n\n\n\n<ul class=\"wp-block-list\"><li>Tim Ferriss &#8211; John Paul deJoria</li></ul>\n\n\n\n<figure class=\"wp-block-embed-spotify wp-block-embed is-type-rich wp-embed-aspect-21-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<div class=\"embed-spotify\"><iframe title=\"Spotify Embed: #441: John Paul DeJoria — From Homelessness to Building Paul Mitchell and Patrón Tequila\" style=\"border-radius: 12px\" width=\"100%\" height=\"152\" frameborder=\"0\" allowfullscreen allow=\"autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture\" loading=\"lazy\" src=\"https://open.spotify.com/embed/episode/0LMxIFFxvbuKt2qXU2z8Vr?utm_source=oembed\"></iframe></div>\n</div></figure>\n\n\n\n<ul class=\"wp-block-list\"><li>A Fantastic article about how a hypothetical China-India war would play out from a military standpoint. It&#8217;s good to know China has a somewhat powerful counterpart so close.</li></ul>\n\n\n\n<p class=\"wp-block-paragraph\"><a href=\"https://edition.cnn.com/2020/06/17/asia/india-china-military-comparison-hnk-intl-scli/index.html\">https://edition.cnn.com/2020/06/17/asia/india-china-military-comparison-hnk-intl-scli/index.html</a></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31092,
            Title = "LEGACY: Artificial Meat",
            Slug = "artificial-meat",
            Description = "Hi! I had a day off from work so I had the opportunity to train in Java for 6 pomodoros. I use the Pomodoro Technique splitting my work in blocks of 25 minutes. The breaks aren’...",
            CardImgUrl = "legacy-artificial-meat.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/06/17/artificial-meat/",
            ReleaseDate = new DateTime(2020, 6, 17),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">Hi! I had a day off from work so I had the opportunity to train in Java for 6 pomodoros. I use the <a href=\"https://en.wikipedia.org/wiki/Pomodoro_Technique\">Pomodoro Technique</a> splitting my work in blocks of 25 minutes. The breaks aren&#8217;t necessarily 5 minutes as in the original technique, but whatever time it takes to complete another task in between the blocks (i.e. prepping food or putting my clothes in the washing machine).<br>But having done it before, the version with the 5 minutes breaks is very effective as we don&#8217;t lose the focus on the main activity too much. The objective for tomorrow is to improve on that number and study for at least 7 pomodoros.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>My First Real Java App</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;m working in a very simple desktop application. Basically I want to track my sleeping hours. I want an app that will give the weekly, monthly and yearly average within a click. It&#8217;s an interesting entry level app that scratches a personal itch, plus gives me some basic ideas about databases, java user interface, java core and the relation between them. I haven&#8217;t found many courses that teach while building something meaningful and challenging enough to serve as a vehicle for learning from scratch. <a href=\"https://twitter.com/maxedapps\">Maximillian Schwarzmuller</a> is the best I&#8217;ve seen so far.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Todays input</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Today I finished <a href=\"https://en.wikipedia.org/wiki/Steve_Jurvetson\">Steve Jurvetson</a>&#8216;s episode on Tim Ferriss podcast. What an inspiring guy! It was so good I had to start again to take better notes. He&#8217;s a venture capitalist that knows a lot about the latest tech to find opportunities for investment. And his opinions are highly curated having a technical background himself (electrical engineering at Stanford), so it&#8217;s worth having a look.<br>Some of the things I didn&#8217;t know much about were quantum computers and the advances in the science of synthetic meat production, which could change the planet so profoundly. He mentioned that the human circle of empathy is ever-increasing. From families, to tribes, to nations, to humans and in the future, to animals. Let&#8217;s hope he&#8217;s right.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Input List</strong></p>\n\n\n\n<ul class=\"wp-block-list\"><li>Tim Ferriss 317 &#8211; Steve Jurvetson (<a href=\"https://open.spotify.com/episode/4x2aqLgj6rrmscfKBfiysH\">https://open.spotify.com/episode/4x2aqLgj6rrmscfKBfiysH</a>)</li><li>Video about synthetic meat (<a href=\"https://www.youtube.com/watch?v=VYXw_-vJFBA\">https://www.youtube.com/watch?v=VYXw_-vJFBA</a>)</li><li>Video about deep learning (<a href=\"https://www.youtube.com/watch?v=6M5VXKLf4D4\">https://www.youtube.com/watch?v=6M5VXKLf4D4</a>)</li><li>Article about synthetic meat (<a href=\"https://theconversation.com/cultured-meat-could-create-more-problems-than-it-solves-127702\">https://theconversation.com/cultured-meat-could-create-more-problems-than-it-solves-127702</a>)</li></ul>\n\n\n\n<p class=\"wp-block-paragraph\"></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31093,
            Title = "LEGACY: BJ Fogg",
            Slug = "bj-fogg",
            Description = "Looks like it will be easier for me to write before going, to bed so I’ve changed the original plan of posting during the morning. I want this to be a closure for my day so I ca...",
            CardImgUrl = "legacy-bj-fogg.jpeg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/06/16/bj-fogg/",
            ReleaseDate = new DateTime(2020, 6, 16),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">Looks like it will be easier for me to write before going, to bed so I&#8217;ve changed the original plan of posting during the morning. I want this to be a closure for my day so I can use it for reflexion and to have the feeling that whatever happened that day is resolved and I&#8217;m next for the next one.<br>Again, unfortunately I did close to zero coding. It was a massive and exhausting Tuesday due to work. </p>\n\n\n\n<p class=\"wp-block-paragraph\">We&#8217;re finally back teaching at the studio, which was great, but my endurance has dropped significantly during Covid crisis and I was super tired before my second class finished. But in general everything went ok. It was good to see some of my students and now I&#8217;m ready to nurture those classes again.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;m too tired to talk about the book I started reading yesterday but here&#8217;s what I consumed today. </p>\n\n\n\n<ul class=\"wp-block-list\"><li>Jim Kwik&#8217;s Blog #182 &#8211; BJ Fogg</li></ul>\n\n\n\n<p class=\"wp-block-paragraph\"><a href=\"https://open.spotify.com/episode/4x2aqLgj6rrmscfKBfiysH\">https://open.spotify.com/episode/4x2aqLgj6rrmscfKBfiysH</a> &#8211; <strong>Fantastic small interview about this fascinating scientist that talks about habit formation and interruption, a subject I would be of much value to anyone</strong>. I&#8217;ll need another post to talk about his fascinating guy. </p>\n\n\n\n<ul class=\"wp-block-list\"><li>Tim Ferriss 317 &#8211; Steve Jurvetson</li></ul>\n\n\n\n<p class=\"wp-block-paragraph\"><a href=\"https://open.spotify.com/episode/4A9q6NajBHGg4Eszrez8Zz?si=pYTGGWEPQSi5uAlv3I7cjQ\">https://open.spotify.com/episode/4A9q6NajBHGg4Eszrez8Zz?si=pYTGGWEPQSi5uAlv3I7cjQ</a> &#8211; <strong>At first I thought this podcast would be too heavy on investments and venture capitalists&#8217; chat. I was surprised by the amazing energy Steve has and the passion for future technology. Things are moving so fast it&#8217;s hard to catch up.</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Ok I&#8217;m so tired I&#8217;m almost fainting. Be back tomorrow!</p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31094,
            Title = "LEGACY: The UQ Dream",
            Slug = "the-uq-dream",
            Description = "I had a great day despite not having too much time to code. I only coded for a little bit, not working on any particular project but following along the book “Head First Java“....",
            CardImgUrl = "legacy-the-uq-dream.png",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/06/15/the-uq-dream/",
            ReleaseDate = new DateTime(2020, 6, 15),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">I had a great day despite not having too much time to code. I only coded for a little bit, not working on any particular project but following along the book &#8220;<a href=\"https://www.amazon.com.au/Head-First-Java-Kathy-Sierra/dp/0596009208\">Head First Java</a>&#8220;. I haven&#8217;t coded properly in about 5 days but I&#8217;m not overly concerned. The volume will increase again once I&#8217;m all settled in my new home.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I did caught up with two friends, which is one of the things I like to do the most. Cultivating relationships is absolute priority from now on. Somehow I didn&#8217;t have the headspace for that before, maybe feeling I didn&#8217;t have much to offer due to my generally low energy. Now being a PERMANENT RESIDENT (I love these words), I have the impression I have a lot more to give and I&#8217;m nurturing friendships that hopefully will last forever.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;ve also started looking into study options and I realised that financially my dream of going back to university is not as far as it initially seemed. If I take the minimum amount of credits the possibility of starting fresh at Uni as early as in the first semester of 2021 is real. And I want to go to the UQ. Maybe I&#8217;m being naive and it&#8217;s impossible to get in there at my age, but something fascinates me about St. Lucia&#8217;s UQ Campus (not even sure the computer science course is down there, lol). But that&#8217;s my intention, my short term goal. Computer Science at the UQ. I like the sound of that.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Ok it&#8217;s 9:22pm, time to go to bed. I want to implement the habit of winding down and preparing the next day instead of just going to bed whenever I feel tired. And that&#8217;s what I&#8217;ll do now. Wrap-up the day, organise the space, go over tomorrow&#8217;s calendar and get things ready for the start of a successful Tuesday. We&#8217;re back to the studio teaching solo-dancing classes tomorrow, the first time after Covid-19 quarantine, and I can&#8217;t wait to teach in person again.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Back tomorrow!</p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31095,
            Title = "LEGACY: Hi there!",
            Slug = "hi-there",
            Description = "Hi there! My name is Pablo, and I’m a 38 years old Brazilian living in Brisbane, Australia. I’ve had many blogs before, but I decided to start this one to document this importan...",
            CardImgUrl = "legacy-hi-there.png",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/06/15/hi-there/",
            ReleaseDate = new DateTime(2020, 6, 15),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">Hi there! My name is Pablo, and&nbsp;I&#8217;m a 38 years&nbsp;old Brazilian living&nbsp;in Brisbane, Australia. I&#8217;ve had many blogs before, but&nbsp;I decided to start this one to document this important chapter in my life.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Last Thursday, June 11th 2020 I got granted permanent residency in Australia, after living here for five and a half years. Now that I&#8217;m officially a resident in this fantastic country I have nothing in my mind other than doing the most with this fantastic opportunity life is giving me. Australia&nbsp;is&nbsp;a country of immense opportunities and I consider myself extremely lucky to have the chance to live here.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Moving forward from the stress of securing residency I want to get back to studying&nbsp;formally, so&nbsp;I can give back to Australia and contribute to the world while collecting friends and having a fantastic time.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I have a fun and rewarding job as a dance teacher but as much as I love my job I don&#8217;t see myself doing in the long run (which is no secret to my bosses). My job as a&nbsp;dance&nbsp;teacher feeds many of core needs: community, connection, learning, physicality. And of course, it also pays the bills.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I want to post every single day. I&#8217;ve always loved writing, but&nbsp;after listening to an interview with writer Seth&nbsp;Godin&nbsp;I was convinced I had to introduce this habit in my daily routine.&nbsp;I&#8217;ll explain the reasons later as I don&#8217;t want this intro post to be too long, but the most important thing I want to achieve from it is to have a solid metrics of discipline. Everything I want to achieve in life requires discipline and posting here will help me develop and document it.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I honestly don&#8217;t expect anyone to read it in the beginning, but&nbsp;I think there will be valuable material in this space throughout the years. This is a lifelong project, and&nbsp;I plan to be posting every day till the day I die.</p>\n\n\n\n<p class=\"wp-block-paragraph\">So let&#8217;s get started! It&#8217;s a pleasant Monday, end of the afternoon&nbsp;(best&nbsp;time of the day&nbsp;in&nbsp;my opinion) and I&#8217;m currently sitting at the office at the dance studio where I work. I&#8217;ll post again tonight with some of my visions for the future.</p>\n\n\n\n<p class=\"wp-block-paragraph\">See you then!!</p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31096,
            Title = "LEGACY: Java Foundations Certified Junior Associate",
            Slug = "java-foundations-certified-junior-associate",
            Description = "Hi! I’m back after close to two months! I’ve been absent of the blog but I’ve been very active with my Java learning. I studied almost every day until two weeks ago. I made the...",
            CardImgUrl = "legacy-java-foundations-certified-junior-associate.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/05/23/java-foundations-certified-junior-associate/",
            ReleaseDate = new DateTime(2020, 5, 23),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">Hi! I&#8217;m back after close to two months! I&#8217;ve been absent of the blog but I&#8217;ve been very active with my Java learning. I studied almost every day until two weeks ago. I made the stupid mistake of buying Civ 5 (the computer game) , which led me to buying Civ 6. </p>\n\n\n\n<p class=\"wp-block-paragraph\">These games are fantastic. I haven&#8217;t played them in about 7 years and I missed them so much. The problem is that it&#8217;s extremely addictive and you&#8217;re always going for that &#8220;just one more turn&#8221;. If you&#8217;re not careful you can spend your entire day clicking the &#8220;Next Turn&#8221; button for one more. The first week was really bad. In the second I was aware of the problem and decreased it. Now I&#8217;m still decreasing it and picking up with the coding again.</p>\n\n\n\n<p class=\"wp-block-paragraph\">During the time I was productive I learned a lot about multi-threading, type casting, error handling and how to write better code. I used the help of Code Ranch and had some really helpful people over there reviewing my code, which I&#8217;ve never had before. I can&#8217;t stress enough how important that was. That led me to the code review session of Stack Exchange, which is an absolute bliss of a forum. You ask them to tear your code apart and they&#8217;ll do it (get ready to realise you know nothing, it will be a reality check). Along with the theory and practice training I can safely add code reviews as an indispensable tool for learning code (and probably other subjects).</p>\n\n\n\n<p class=\"wp-block-paragraph\">My latest decision was to take my first Java certification. It will be the easiest. At least it seems to be on the easy side considering the difficulty of CodeGym&#8217;s exercises. I&#8217;ve seen advice by good Java people on the web not to take it but it&#8217;s not that expensive and I think it will be easy enough to boost my confidence. I&#8217;ll give myself a month to prepare. And I will document the preparation in this space. I&#8217;ll try to post every day but even if I don&#8217;t I&#8217;ll post my activities on the days I didn&#8217;t post.</p>\n\n\n\n<p class=\"wp-block-paragraph\">The test Syllabus has 13 sections. I&#8217;ll try to cover 1 per day and that will leave me a bunch of time for mock tests and complementary material. Not only this test will be important to get the certification but to put structures in place for test preparation and study flow. So let&#8217;s get it going!!! </p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31097,
            Title = "LEGACY: CodeGym – Java Syntax Done!",
            Slug = "codegym-java-syntax-done",
            Description = "It took me one month to complete the first part of CodeGym’s Java Course. The course is divided in four phases: Syntax, Core, Multithreading and Collections. I’m very satisfied...",
            CardImgUrl = "legacy-codegym-java-syntax-done.jpeg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/04/04/codegym-java-syntax-done/",
            ReleaseDate = new DateTime(2020, 4, 4),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">It took me one month to complete the first part of CodeGym&#8217;s Java Course. The course is divided in four phases: Syntax, Core, Multithreading and Collections. I&#8217;m very satisfied with the course because it&#8217;s based on exercises. Some of them are easy, but for most of them you&#8217;ll need to research somewhere else. Many users complain in the comments, but that&#8217;s actually an advantage of the course. Thankfully in my short journey as a developer I realised pretty early on that the life of a coder is 5% coding and 95% looking for answers on the web. </p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;m pretty sure I&#8217;ll have to go back to the first part of the course for consultation often. I have no illusions about knowing the Syntax well. But I do think I have a good general understanding of how it works and what to search when I have a specific problem.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Something I recommend for anyone trying this course is to create some sort of cheat sheet. I had to research for the same thing over and over as some of the exercises required the same code or something similar to it. I&#8217;ll create a very detailed cheat sheet for the second part of the course. It&#8217;s easy to feel tempted to just keep pushing on, but the time I&#8217;ll spend creating those explanations will save me a lot of time further down the road.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Another suggestion is: Read all the articles. I only started doing it at Level 7 and I regret not doing it before because it offers complimentary explanation about the topics. The basic lessons cover the basics of each topic but the articles will dig deeper and help you fill the gaps in your understanding.</p>\n\n\n\n<p class=\"wp-block-paragraph\">And the last thing is something I learned a few months ago when learning basic Javascript: Don&#8217;t leave an exercise without understanding what EACH LINE OF CODE DOES. I know it can be frustrating to be stuck in a single exercise for 2 hours, but we have to remember: when looking at a piece of code for 2 hours (or more), trying stuff and researching every word/concept, THAT TIME IS NOT BEING WASTED. It&#8217;s actually helping us learn. There&#8217;s no point finishing an exercise without understanding it. </p>\n\n\n\n<p class=\"wp-block-paragraph\">As I said a few posts ago I will also read the books suggested by CodeGym but I haven&#8217;t started yet. Actually, I did read the intro for &#8220;Thinking in Java&#8221; but they recommended doing the seminar &#8220;Thinking in C&#8221; first, which I want to do before reading the Java one. I don&#8217;t feel it&#8217;s a step back because I&#8217;ll keep learning with CodeGym for at least another year. </p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;ll challenge myself to post every second day (at least) for the duration of the Java Core section to talk about my experience. I know nobody reads this now, but when I&#8217;m a successful developer and people start reading my blog I want them to know I also started from scratch and I what the journey was like.</p>\n\n\n\n<p class=\"wp-block-paragraph\">See you tomorrow!! (Or the day after)</p>\n\n\n\n<p class=\"wp-block-paragraph\"></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31098,
            Title = "LEGACY: ArrayList",
            Slug = "arraylist",
            Description = "Posting a bit late today because I’m working in the morning. As I said a few times I’m very lucky to be able to keep working. Millions of people in Australia aren’t able to work...",
            CardImgUrl = "legacy-arraylist.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/03/25/arraylist/",
            ReleaseDate = new DateTime(2020, 3, 25),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">Posting a bit late today because I’m working in the morning. As I said a few times I’m very lucky to be able to keep working. Millions of people in Australia aren’t able to work with the new restrictions to businesses and gatherings. Hopefully the money I’m making now will provide resources for me to survive until the end of this crisis without going into debt. I’m predicting everything will be back to normal in about 2 months max. </p>\n\n\n\n<p class=\"wp-block-paragraph\">ArrayList</p>\n\n\n\n<p class=\"wp-block-paragraph\">I only had about 3 hours of free time for coding and I continued pushing through Lesson 7, this time studying the ArrayLists. I still don’t quite understand the difference between Lists and ArrayLists but hopefully that will come with time. I did understand some differences between Arrays and ArrayLists. ArrayLists are more versatile. They have way more methods and possibilities. And they are soooo much fun to deal with. I’m loving the challenges provided by CodeGym.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Podcast</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">I’m still listening to the same podcast as yesterday. Jocko’s Podcast Episode 216 about Reg Curtis’ book, Memory Endures. Some unbelievable combat descriptions. I highly recommend you take a look at it.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Now time to go back to work so hopefully I’ll <strong>shut up and code</strong> in the afternoon. </p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31099,
            Title = "LEGACY: I love arrays",
            Slug = "i-love-arrays",
            Description = "Yesterday I couldn’t code for as many hours as I wanted, but for a good reason. I was working from 12 to 830pm. As I’ve been saying, every work hour these days is extremely valu...",
            CardImgUrl = "legacy-i-love-arrays.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/03/24/i-love-arrays/",
            ReleaseDate = new DateTime(2020, 3, 24),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">Yesterday I couldn&#8217;t code for as many hours as I wanted, but for a good reason. I was working from 12 to 830pm. As I&#8217;ve been saying, every work hour these days is extremely valuable. It was a big day with lots of video recording and live streaming of dance classes and it felt good to go out of isolation and meet work mates. However it was very sad to be the usually booming Boundary Street in West End, Brisbane, completely empty. It&#8217;s an once-in-a-lifetime situation, very very weird. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Studying Arrays</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">All the time I had to study was dedicated to arrays. I just love working with them, don&#8217;t ask me why. And the more I understand how Java handles them, the more I like it. There&#8217;s still a long way to go, though. The course I&#8217;m doing has 4 Levels, with 10 lessons each. And I&#8217;m only on lesson 7 of Level 1. I can&#8217;t wait to learn everything that&#8217;s ahead of me.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Podcast</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">My current podcast companion is Jocko&#8217;s Podcast &#8211; Episode 216, about Reg Curtis&#8217; book: <a href=\"https://www.amazon.co.uk/Memory-Endures-Grenadier-Guardsman-Parachute/dp/0993205305\">&#8220;Memory Endures, The Story of a Grenadier Guardsman and Pioneer of the Parachute Regiment, 1937-1945&#8221;</a>. It&#8217;s a fantastic story. This man has seen unbelievable amounts of action in World War II. This episode is another one of those that helps us keep perspective of how good our lives are even amidst the craziness of Covid-19.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Now Shut Up and Code!!</p>\n\n\n\n<p class=\"wp-block-paragraph\"></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31100,
            Title = "LEGACY: Thinking in C",
            Slug = "thinking-in-c",
            Description = "Yesterday I started reading Bruce Eckel’s “Thinking in Java“, and in the first part of the book whoever learns C will have a much easier time learning Java and C++. I decided I’...",
            CardImgUrl = "legacy-thinking-in-c.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/03/23/thinking-in-c/",
            ReleaseDate = new DateTime(2020, 3, 23),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">Yesterday I started reading Bruce Eckel&#8217;s &#8220;<a href=\"https://www.amazon.com/Thinking-Java-4th-Bruce-Eckel/dp/0131872486\">Thinking in Java</a>&#8220;, and in the first part of the book whoever learns C will have a much easier time learning Java and C++. I decided I&#8217;ll add C to my studies. My main learning will still be Java, using <a href=\"http://www.codegym.cc\">CodeGym</a> platform, but I&#8217;ll also study the Thinking in C seminar. It&#8217;s widely available online and I&#8217;ll be using <a href=\"http://ix.cs.uoregon.edu/~norris/cis330books/ThinkingInC/Index.html\">this version</a>, found on the University of Oregon website. </p>\n\n\n\n<p class=\"wp-block-paragraph\">Yesterday I finally finished the chapter on objects and I have a little more understanding of static modifiers, definitely a better understanding of loops. I&#8217;m absolutely loving the course and can&#8217;t wait for the next chapter: Arrays!! </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Tough Times</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Even though yesterday was a great day at work, since I had a few solid hours streaming dance classes live, Australian Premier Scott Morrison unleashed <a href=\"https://www.bbc.com/news/world-australia-51992357\">severe measures </a>to stop Covid-19 spread, including closure of all restaurants, pubs and GYMS. This is hardcore. But necessary, I suppose. Things are getting worse daily and the only way it could get worse is if we have a war, but I don&#8217;t think that&#8217;s the case. </p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;ll use this opportunity to grow as much as I can as a programmer and as a dancer and will have to find creative ways to workout and home and maybe find someone&#8217;s gym to keep working out in the next few months.  It will be also a great exercise in living frugally and having as little as possible, with ultimately leads to a stronger character.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Now shut up and code, Pablo!</p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31101,
            Title = "LEGACY: Java Books",
            Slug = "java-books",
            Description = "This Saturday was very productive in terms of Study. Even though I got stuck in one exercise, I always consider that the hours spent trying to crack down a challenge are worth i...",
            CardImgUrl = "legacy-java-books.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/03/22/java-books/",
            ReleaseDate = new DateTime(2020, 3, 22),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">This Saturday was very productive in terms of Study. Even though I got stuck in one exercise, I always consider that the hours spent trying to crack down a challenge are worth it. I don&#8217;t consider it wasted time at all. It&#8217;s a form a training, just as going to the gym (which I also did yesterday, leg day, hurra!). </p>\n\n\n\n<p class=\"wp-block-paragraph\">Having said that, I&#8217;m still struggling to understand what the &#8220;static&#8221; modifiers do. I&#8217;ll spend sometime looking into it today and hopefully I&#8217;ll finish Lesson 6. Lesson 7 is about arrays, which I love, so I&#8217;m looking forward to it, but I understand it might have to wait till tomorrow. </p>\n\n\n\n<p class=\"wp-block-paragraph\">Today fortunately I&#8217;ll get back to work, running online classes for my dance studio. In these extremely uncertain Covid-19 days, every dime will important for survival until this is all over.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Books</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">One of the good things about CodeGym is that they give good tips for articles and books and I&#8217;m already creating a little digital library with the books I want to read. I&#8217;d love to have the hard copies but they&#8217;re incredibly expensive, so I&#8217;ll stick to the pdf versions. My list so far: </p>\n\n\n\n<ul class=\"wp-block-list\"><li>Thinking in Java &#8211; Bruce Eckel</li><li>Head First Java &#8211; Kathy Sierra</li><li>Clean Code &#8211; Robert C. Martin</li></ul>\n\n\n\n<p class=\"wp-block-paragraph\">Ok, now back to studying! </p>\n\n\n\n<p class=\"wp-block-paragraph\">Shut up and code, Pablo!</p>\n\n\n\n<p class=\"wp-block-paragraph\"></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31102,
            Title = "LEGACY: Studying Arrays in Java",
            Slug = "studying-arrays-in-java",
            Description = "Unfortunately yesterday I couldn’t dedicate a lot of hours to coding due to work things I had to do. The total hours spent banging my head against Java were only about four. I m...",
            CardImgUrl = "legacy-studying-arrays-in-java.jpeg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/03/21/studying-arrays-in-java/",
            ReleaseDate = new DateTime(2020, 3, 21),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">Unfortunately yesterday I couldn&#8217;t dedicate a lot of hours to coding due to work things I had to do. The total hours spent banging my head against Java were only about four. I made some progress and did all the exercises in the &#8220;Objects&#8221; chapter of the course, but got stuck in the last one, where I had to create an input inside an loop. I&#8217;ve done that before, so that&#8217;s ok, but the exercise also involved pushing the inputs into an array to do an operation with them. I&#8217;m hoping to learn that today.</p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Good News</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Looks like the dance studio I work for was able to keep many of its customers and we&#8217;re going to start having classes online just to keep people in the program. I know it&#8217;s not a long term solution for partner dancing, but at least money will keep dripping in to help us all survive until this is all over. </p>\n\n\n\n<p class=\"wp-block-paragraph\">However that means I might not sprint to finish Section 1 of the Java course, which has 10 chapters that are increasingly complex. So I&#8217;ll allow myself two weeks instead of one to complete it. I don&#8217;t want to make the same mistake I did in my first Javascript course where I finished the course very fast and later I realised I didn&#8217;t retain much. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Scary Numbers</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">We had 90 cases of Covid-19 in Queensland in the last couple of days, which is a significant increase. Apparently night clubs were packed with young people last night and malls were very busy with elderly. It seems like many people aren&#8217;t taking this too seriously in my area. Let&#8217;s hope we&#8217;re not punished with a dramatic increase in the numbers as it&#8217;s happening in Europe. </p>\n\n\n\n<p class=\"wp-block-paragraph\"></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31103,
            Title = "LEGACY: Objects",
            Slug = "objects",
            Description = "I’m writing at 5:35 am. My sleep is all over the place at the moment. A few days ago I went to bed at 4am, then at 3, then at 1 and last night at 11. I have to find some stabili...",
            CardImgUrl = "legacy-objects.png",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/03/20/objects/",
            ReleaseDate = new DateTime(2020, 3, 20),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">I&#8217;m writing at 5:35 am. My sleep is all over the place at the moment. A few days ago I went to bed at 4am, then at 3, then at 1 and last night at 11. I have to find some stability with my sleep to assure my brain is always nice and fresh to absorb all I need to learn to become a developer. </p>\n\n\n\n<p class=\"wp-block-paragraph\">Yesterday was a day of self-doubt. The voice inside my head kept saying that maybe I&#8217;m too old to be trying to become a software engineer. The problem is that I&#8217;m not only doing this to change careers. I&#8217;m doing it because I love programming. Yeah, the prospect of making a lot of money does contribute to my drive. But money is far from being the biggest motivation for my programming challenge. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Learning about objects</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">In yesterday&#8217;s studies, I spent all of my time with Java, finishing the loops chapter and going into objects. I new the concept of objects from my javascript studies, but I still find it fascinating. I love to deal with data and the possibility objects allow for data handling. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Input</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">My source of input at the moment is Jocko Podcast&#8217;s most recent episode with Jonny Kim. This guy is a former navy seal, a doctor and an astronaut. Whaaaat? His story is fascinating and if anyone ever read this blog I highly recommend you listen to it: <a href=\"https://jockopodcast.com/2020/03/18/221-the-unimaginable-path-of-jonny-kim-seal-combat-medic-doctor-astronaut/\">The Unimaginable Path of Jonny Kim</a>. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>Today</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Today I&#8217;ll only have the morning free, so I&#8217;ll use my power hours to get a lot of coding done. I&#8217;ll try to go as far as possible with the objects and hopefully even get done with Chapter 5. </p>\n\n\n\n<p class=\"wp-block-paragraph\">Now shut up and code, dude!</p>\n\n\n\n<p class=\"wp-block-paragraph\"></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31104,
            Title = "LEGACY: Java Certification",
            Slug = "java-certification",
            Description = "Yesterday I found out there’s a Java Certification! I still haven’t done heavy research about it, but it seems like a nice goal to have. I’m not sure how much having a certifica...",
            CardImgUrl = "legacy-java-certification.png",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/03/19/java-certification/",
            ReleaseDate = new DateTime(2020, 3, 19),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">Yesterday I found out there&#8217;s a <a href=\"https://education.oracle.com/oracle-certification-path/pFamily_48\">Java Certification</a>! I still haven&#8217;t done heavy research about it, but it seems like a nice goal to have. I&#8217;m not sure how much having a certification improves my chances of getting a job, but even if it doesn&#8217;t, I love the intellectual challenge. The subscription to educational material offered by Oracle has unrealistic prices for me, so I&#8217;m not going down that road, but I&#8217;ll definitely stick to Java in 2020.</p>\n\n\n\n<p class=\"wp-block-paragraph\">The main area of study of yesterday was for and while loops. Before going to sleep I got stuck in an exercise where I had to create an input inside a loop, which is very interesting. Can&#8217;t wait to find out how that works today. </p>\n\n\n\n<p class=\"wp-block-paragraph\">I was also able to go to the gym for the second day in a row, which is a huge accomplishment after 8 days of no gym due to my flu. </p>\n\n\n\n<p class=\"wp-block-paragraph\">For today, I want to do a solid 8 pomodoros of Java and potentially touch on a couple of WordPress projects I&#8217;m developing for friends. Hopefully go to the gym to keep the good run and that&#8217;s about it.  I apologise (to myself) for posting 1130am instead of 9am as promised but I didn&#8217;t want to use an alarm clock because I want to get all sleep I can during this break but I ended up sleeping for nine hours! My body probably needed it. </p>\n\n\n\n<p class=\"wp-block-paragraph\">Now shut up and code!</p>\n\n\n\n<p class=\"wp-block-paragraph\">Back tomorrow.  </p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31105,
            Title = "LEGACY: Toughest Time of My Life",
            Slug = "toughest-time-of-my-life",
            Description = "We’re in the middle of Covid-19 crisis and bracing ourselves for it’s spread in Australia. The dance studio I work for is closing doors for an undetermined amount of time, which...",
            CardImgUrl = "legacy-toughest-time-of-my-life.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/03/18/toughest-time-of-my-life/",
            ReleaseDate = new DateTime(2020, 3, 18),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">We&#8217;re in the middle of Covid-19 crisis and bracing ourselves for it&#8217;s spread in Australia. The dance studio I work for is closing doors for an undetermined amount of time, which means technically I have no work. That&#8217;s not to mention gigs that have been cancelled. And before the announcement of the closure I had a heavy flu for a week, which prevented me from working, forcing me to use all my leave.</p>\n\n\n\n<p class=\"wp-block-paragraph\">The worst part is that I have close to zero savings. Due to circumstances I was forced to dispose of my savings and I calculate in a couple of weeks time I&#8217;ll be hat in hand to make sure I have enough for subsistence. I&#8217;ve done many stupid things in my life, but I was never in debt. And now it looks like that will be the case, unless a cure or the vaccine is found very quick.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;m aware that lots of people are going through the same and most probably worse than me, as I live in a rich country, I have good health and my family is ok. I&#8217;ve done a lot of work in that are to keep things in perspective and not to think I&#8217;m the unluckiest person in the world. However it&#8217;s a new low for me. </p>\n\n\n\n<p class=\"wp-block-paragraph\">After a couple of months without visiting it, I&#8217;ve resorted to <a href=\"https://jockopodcast.com/\">Jocko&#8217;s Podcast</a> again. It&#8217;s a fantastic source of perspective, as it discusses the lives of people that went through tough times,  with focus on military history. The last episode I listened to was with Rose Schindler, an Auschwitz survivor, co-author of <a href=\"https://www.amazon.com/Two-Who-Survived-Surviving-Holocaust-ebook/dp/B07X4XH3QZ\">&#8220;Two Who Survived&#8221;</a>, which I still have to read. It&#8217;s impossible not to think that what I&#8217;m going through right now is nothing after hearing her story. </p>\n\n\n\n<p class=\"wp-block-paragraph\"><strong>My Plan</strong></p>\n\n\n\n<p class=\"wp-block-paragraph\">Of course I&#8217;m not going to sit down and wait for the best. The positive side of all this is that I&#8217;ll have tons of time in my hands and I have to do something useful with it. My biggest plan for this period is to come out on the other end as a better programmer. </p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;ve decided to focus on Java from now on. Not for any specific reason but mainly because after listening from advice from a friend and doing some research I realised that as much as Angular is awesome and I&#8217;ll keep diving into it as my Front-End framework, my possibilities in the long run will be better if I know a robust back-end language well. From what I understand, it doesn&#8217;t really matter which language it is, as long as you stick to it and become fluent. So I&#8217;m going to stick with Java.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I subscribed to <a href=\"https://codegym.cc/\">Code Gym</a>, and my progress has been relatively slow so far, but now I intend to really dive into it. It&#8217;s a very well structured course with a lot (really, a lot) of exercises, which I think is the best way for learning. I&#8217;ll work as hard as I can to get done with the first part of the course, the Syntax, <strong>in a week.</strong> </p>\n\n\n\n<p class=\"wp-block-paragraph\">And because I have so much time in my hands I&#8217;ll post on the blog daily. The sole purpose is to create the discipline. As of now I don&#8217;t think anyone is reading this anyways. I&#8217;ll be posting at 9am Brisbane Time every day. </p>\n\n\n\n<p class=\"wp-block-paragraph\">Back tomorrow! </p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31106,
            Title = "LEGACY: Building My First App",
            Slug = "building-my-first-app",
            Description = "After a month and a half learning Angular, I’ve decided to build my first web app. It will be a platform for people to learn brazilian portuguese. That means I’ll be combining t...",
            CardImgUrl = "legacy-building-my-first-app.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/02/24/building-my-first-app/",
            ReleaseDate = new DateTime(2020, 2, 24),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"has-text-align-justify wp-block-paragraph\">After a month and a half learning Angular, I&#8217;ve decided to build my first web app. It will be a platform for people to learn brazilian portuguese. That means I&#8217;ll be combining two of my biggest passions: Languages and Coding. </p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">The idea is to create clever games for people to memorise key concepts in brazilian portuguese. It will start very small with just a small words game that will test the user&#8217;s knowledge of key brazilian portuguese words. I love this project because it&#8217;s extremely useful, it has a well-established niche, it will demand the practice of very important concepts in Angular, such as Material and advanced concepts of state management with RxJS and NgRx and above all, it&#8217;s extremely scalable. </p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">I don&#8217;t have a clear idea of how exactly things are going to be in the app, but I&#8217;ll be able to fine tune the app with the help of a few friends that are interested in learning portuguese. I&#8217;ll ask for feedback on user experience. In the ideal world it will be a product that I&#8217;ll be able to sell. But as Tim Ferriss often says, you should choose a project based on the skills you learn and the networking potential and my choice will be incredibly helpful in terms of skills. Which means that even If I never sell my app, I&#8217;ll have learned a lot. </p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">I&#8217;ll give myself a deadline of one month to have a webservice ready to sell. Recently I realised the importance of setting audacious deadlines for oneself when creating a small website for a client (my first paid gig). A tight deadline makes you work in a very focused way and it increases productivity. It&#8217;s one of the lessons I learned from the book &#8220;Mastery&#8221;. </p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">I&#8217;ll be posting my progress twice a week in this blog. I love the idea of posting everyday but it just means wasting a lot of time I could be using to code. I want to learn as fast as I can throughout 2020 so I can eventually combine coding with another passion of mine: Teaching. I love the possibilities Udemy offers and I get very good feedback from my dance teaching. I&#8217;d love to transfer those skills into coding. But obviously I can&#8217;t teach something I don&#8217;t know very well. So I&#8217;ll be pushing myself to get to that level in 2020. I&#8217;ll learn a lot about Angular and product development. Exciting times ahead!!!</p>\n\n\n\n<p class=\"wp-block-paragraph\"></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31107,
            Title = "LEGACY: January Review",
            Slug = "january-review",
            Description = "January was a very important month. I found out I want to be an Angular developer and dove deep into its intricacies. I didn’t really appreciate all Angular has to offer before...",
            CardImgUrl = "legacy-january-review.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/01/31/january-review/",
            ReleaseDate = new DateTime(2020, 1, 31),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">January was a very important month. I found out I want to be an Angular developer and dove deep into its intricacies. I didn&#8217;t really appreciate all Angular has to offer before reading a lot about its differences in relation to other technologies and after going going back to straight HTML for a little project to learn Sass. </p>\n\n\n\n<p class=\"wp-block-paragraph\">I did feel overwhelmed in the beginning and had to start from scratch, taking it a little bit easier and trying to really learn every concept before moving to the next one. If you have gaps in the understanding of how a basic building block of Angular works, it will catch up with you later on.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Obviously I still don&#8217;t have the fluency to just sit down and right code without relying on my checklists, but I&#8217;m really happy with my progress. I have a basic understanding of how the frame work operates. Seems to me like the features I have to learn from now on are built on top of the foundation I created in January. </p>\n\n\n\n<p class=\"wp-block-paragraph\">I decided to create a budget app and document in detail the process of building it so I can have it as my own blueprint for the creation of Angular Apps. I decided for the budget app because it scratches my own itch (I never found a free app with all the characteristics I wanted and because it will serve as a good apprenticeship project to get into enterprise level projects in the future. It has a huge amount of data, that I have to collect, modify and display and it will also allow me to interact with calendars, which are a big feature in most enterprise apps. </p>\n\n\n\n<ul class=\"wp-block-list\"><li>In February I want to: </li><li>Make progress in the creation of reactive forms</li><li>Create fluency in dealing with firebase</li><li>Learn more about styling of an Angular app with Angular Material</li><li>Better understand pipes</li><li>Learn authentication and Route Protection in Angular</li><li>Learn how to deploy an Angular App</li></ul>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;ve also established a nice workflow and created/modified routines that allow me to stay efficient at work while carving out the hours to study. The book &#8220;The Power of Habit&#8221; was a game changer. I&#8217;ll probably read it many times to internalise it. But now I came across an even better book: &#8220;Mastery&#8221;, by Robert Greene. I&#8217;ve only read about 10% of it and I can already tell it&#8217;s one of the best books I&#8217;ve ever read. I highly recommend it to anyone learning anything or anyone interested in self-growth. Fantastic stuff. I&#8217;ll write more about it later. </p>\n\n\n\n<p class=\"wp-block-paragraph\">Some metrics that I want to beat this Month:</p>\n\n\n\n<ul class=\"wp-block-list\"><li>Gym: 21 Sessions + 2 Cardio</li><li>Classes taught: 55</li><li>Pomodoros of coding: 205, which means an average of 3h10&#8242; of coding per day. </li></ul>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;ll aggressively work to increase that to at least 4 hours a day. I need to decrease my rest periods and cram my non-essential activities into shorter chunks of time to free up more time fore coding. Plus I have to increase the quality of these pomodoros. I think about 10-15% of them weren&#8217;t free of distraction. That has to change. Any pomodoro will have to be 100% free of distractions. Looking forward to next month!</p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31108,
            Title = "LEGACY: The Importance of Checklists",
            Slug = "the-importance-of-checklists",
            Description = "It’s been twenty days since my post about learning angular and the progress has been slow but steady. I’ve studied pretty much every day, with the exceptions of the 11th and 18t...",
            CardImgUrl = "legacy-the-importance-of-checklists.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/01/23/the-importance-of-checklists/",
            ReleaseDate = new DateTime(2020, 1, 23),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"has-text-align-justify wp-block-paragraph\">It’s been twenty days since my post about learning angular and the progress has been slow but steady. I’ve studied pretty much every day, with the exceptions of the 11th and 18th, when, two Saturdays full of work when I just didn’t have time for anything else.&nbsp;</p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">I’ve been watching all lessons of the course very slowly, making sure I understand everything and how it would be useful for the different apps I have in mind. It’s very easy to get bored when you aren’t understanding a subject, so usually I can measure my learning by the amount of boredom.&nbsp;</p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">The course I’m doing goes through everything with so much detail that sometimes it can take 2 hours of classes just to implement a single functionality. Two hours in my case mean at least 10 hours of studying because I’m going back and forth in slow motion to understand everything.&nbsp;</p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">I’m learning a lot about how to learn and one of the things I realised is very important is to create checklists. Often times the idea behind a functionality is fairly simple but it takes as many as 20 or 30 steps to implement it. And the time it takes to create a check-list will pay off saving a bunch of time in the feature when you’re lost trying to create your own app and don’t remember exactly where was what.</p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">Plus these check-lists will be paramount to expedite the process of creating apps later on. In 2018 I read a book called <a href=\"https://www.amazon.com.au/Checklist-Manifesto-How-Things-Right/dp/0312430000\">Checklist Manifesto: How to Get Things Right,</a> a very interesting read about how checklists improve processes in many areas such as aviation, medicine and construction. The point is, it doesn’t matter how good you are at you do, you just can’t memorise all the information you need to get the job done. And having checklists will free brainspace for the things that really matter: creativity, design, the big picture, problem solving, etc.&nbsp;</p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">Checklists, for example, are part of the reason why commercial aviation is so safe. No pilot can memorise all procedures for all scenarios an aircraft my get exposed to. But they’re highly trained to use checklists for those scenarios. And these checklists keep being updated whenever new data arrives. </p>\n\n\n\n<figure class=\"wp-block-image size-large\"><img src=\"https://shutupandcodeblog.files.wordpress.com/2020/01/screen-shot-2020-01-23-at-8.59.02-pm.png?w=742\" alt=\"\" class=\"wp-image-156\" /></figure>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">Now, speaking of my current journey in Angular, I just finished the sections related to display and navigation (the front-end stuff), and now I’m delving slowly into middleware tools, such as dealing with Forms and HTTP requests, which is very exciting, as I’m going to learn how to connect my websites to Firebase. I can’t wait to see how many possibilities it will open for the implementation of all ideas I have. </p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31109,
            Title = "LEGACY: Learning Angular: Slow is Smooth and Smooth is Fast",
            Slug = "learning-to-code-from-scratch",
            Description = "I’m writing because I’m having a monstrous anxiety attack (or at least the closest I’ve had to one). Three days ago I purchased this course to learn Angular: Angular 8, the Comp...",
            CardImgUrl = "legacy-learning-to-code-from-scratch.png",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2020/01/04/learning-to-code-from-scratch/",
            ReleaseDate = new DateTime(2020, 1, 4),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"has-text-align-justify wp-block-paragraph\">I&#8217;m writing because I&#8217;m having a monstrous anxiety attack (or at least the closest I&#8217;ve had to one). Three days ago I purchased this course to learn Angular: <a href=\"https://www.udemy.com/course/the-complete-guide-to-angular-2/\">Angular 8, the Complete Guide</a>. It&#8217;s an extremely in-depth course by an excellent teacher: <a href=\"https://www.udemy.com/user/maximilian-schwarzmuller/\">Maximilian Schwarzmuller</a>. I decided to learn Angular because a friend that is helping me in my code journey is an Angular specialist. So, not only I have the opportunity to learn in person from someone that already knows it really well, but I also have the chance to ask for help when I inevitably have questions &#8211; which I&#8217;ve probably been doing too much, sorry Chris. 😀</p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">However I spent these three days in front of my laptop feeling like an absolute idiot. Actually, in the first day, when I was just creating the components and learning some basic functionalities for the application I was creating in the course project &#8211; a very dynamic recipe book &#8211; I felt good about my progress. </p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">However, as soon as the Databinding part started, where we learn how to share data amongst components, things got a little bit darker. I quickly realised that if I even flinched I would miss an important piece of information. Maximilian teaches at a good pace, but for someone that has been developing for as little as six months like me, there was no way I was going to follow along without stopping every five seconds to process what he was saying. That experience &#8211; along with a few articles I&#8217;ve recently read about how to learn code &#8211; showed me how important it is not to rush things and try to process every bit of code that&#8217;s being written before moving to the next part. &#8220;Slow is Smooth and Smooth is Fast&#8221;, as someone once said. </p>\n\n\n\n<blockquote class=\"wp-block-quote is-style-large is-layout-flow wp-block-quote-is-layout-flow\"><p>&#8220;Slow is Smooth and Smooth is Fast&#8221;</p><cite>Unknown</cite></blockquote>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">But having a lot of time in my hands during my break from work, of course I pushed through and moved on to the next section, the &#8220;Directives&#8221;, which are attributes for DOM manipulation. Having recently learned how to manipulate the DOM using Vanilla Javascript I was feeling that in Angular I had to use 10 steps as many as I have to use in JS to achieve the same thing. And then I started thinking: &#8220;What&#8217;s the point?&#8221;. I could be doing the same thing with JS in a much easier way.  That&#8217;s when I got up from my chair consumed with anxiety, as frustrated as I&#8217;ve ever been in my short developer career. </p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">What saved me was finding this thread on Quora: <a href=\"https://www.quora.com/Is-it-just-me-or-is-Angular-too-hard\">Is It Me Or Angular Is Just Too Hard?</a>. It&#8217;s a very interesting discussion amongst experienced developers about the pros and cons of working with angular. This particular part instantly decreased my anxiety: </p>\n\n\n\n<blockquote class=\"wp-block-quote is-layout-flow wp-block-quote-is-layout-flow\"><p>But, I really don’t like Angular. I don’t feel productive in Angular. I feel I fight Angular more than it helps me. It feels overly complicated. To compare to another environment it would be as if I’m forced to pick up C# ( generally easy language to learn) but then have to use every advanced C# practices to just get a simple “hello world” going.</p><p>Expect a learning curve of at least a month or two. I confess I’m not the fastest learner because I’m one who needs to have a deep understanding of a framework before I feel comfortable using it. <strong>I feel for any new JavaScript developer who picks up Angular.&nbsp;</strong></p><cite>Andy Jarrell</cite></blockquote>\n\n\n\n<figure class=\"wp-block-image size-large\"><img src=\"https://shutupandcodeblog.files.wordpress.com/2020/01/screen-shot-2020-01-04-at-5.37.30-pm.png?w=1024\" alt=\"\" class=\"wp-image-149\" /></figure>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">Suddenly I wasn&#8217;t feeling stupid anymore. But after reading the rest of the thread I understood that the learning curve is very steep because basically we&#8217;re learning how to build very complex applications with functionalities I don&#8217;t even know yet and elegantly solving problems I never came across. It&#8217;s like learning how to build an enormous foundation for a huge sky-scrapper with state-of-the art technology while only knowing how to build a wooden hut on top of it. </p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">Well, apparently I&#8217;ll have to grow into Angular. It sounds like a good plan to me to dive into a very complex piece of technology that will open many doors in the future instead of sticking to easy-to-learn frameworks/APIs that anyone will be able to pick up very quickly. And even if Angular is abandoned and not used at some point in time, which I don&#8217;t think it will happen, it will teach me a lot about how to learn, how to manage my time and general concepts of computer programming/web development. </p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">At the same time, the last few days taught me a lot about how I easily get distracted by the web. Often times I catch myself opening tabs with articles totally unrelated to coding and obviously &#8211; as I think most people &#8211; in the whirlwind of social media apps. I will have to tackle that. But that&#8217;s subject for another post. </p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">I&#8217;m ready to embark in the Angular adventure. I&#8217;ll just manage my expectations and go slowly. Way more slowly than I previously planned. And because I need to increase my portfolio relatively quickly, I plan to keep building websites on the side, using less complex technologies. </p>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;m excited to see where this approach will take me. </p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31110,
            Title = "LEGACY: My First Algorithm!!",
            Slug = "my-first-algorithm",
            Description = "Yesterday was an awesome day. I put together my first piece of algorithm!! The decision to go back to javascript fundamentals was absolutely correct. I started from scratch, tak...",
            CardImgUrl = "legacy-my-first-algorithm.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2019/12/27/my-first-algorithm/",
            ReleaseDate = new DateTime(2019, 12, 27),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"has-text-align-justify wp-block-paragraph\">Yesterday was an awesome day. I put together my first piece of algorithm!! The decision to go back to javascript fundamentals was absolutely correct. I started from scratch, taking lots of notes and not moving forward unless I understood the previous concepts. Lots of things make way more sense now than six months ago when I first did this course. It&#8217;s very exciting to thing of what it&#8217;s going to be like in another six months when I look back If I continue with this approach.</p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">I learned to display data on html from javascript, which is extremely useful in webdesign, using <a href=\"https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Template_literals\">Template Literals</a>. I also tried to solve a long standing problem of mine, which is to log the hours I sleep and give me the average of a certain period of time effortlessly. I&#8217;m pretty sure it&#8217;s a little monster of a piece of code and I&#8217;ll laugh about it later but I&#8217;m very proud. It was the first time I created an algorithm without the help of any tutorials. I just used what I was learning on this course: <a href=\"https://www.udemy.com/course/modern-javascript-from-the-beginning/?couponCode=TRAVERSYMEDIA\">Modern Javascript From The Beginning</a> (highly recommend it). </p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">I can&#8217;t recommend this enough. Brad Traversy has great teaching style and it&#8217;s like he&#8217;s talking to a buddy when you&#8217;re learning from him. 🙂  Today my objective is to learn how to get the user input from html and receive back my average sleep hours. The next step will be to log it into a database using Node.js. </p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">It just feels great to have written orders to a computer for the first time. I really feel like a programmer! Haha. Not a pro programmer yet, because I&#8217;m not getting paid, but definitely a programmer. More than learning the language, I&#8217;m learning how to think when building something, which seems to be one of the most important things to learn.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Well, shut up and code Pablo! Time to get back to work.  </p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31111,
            Title = "LEGACY: Starting Javascript From Scratch",
            Slug = "starting-javascript-from-scratch",
            Description = "I’ve got tons of time in the next couple of weeks and after doing some stuff with Angular, typescript and trying to learn Sass and get more familiar with Node, I feel it’s time...",
            CardImgUrl = "legacy-starting-javascript-from-scratch.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2019/12/25/starting-javascript-from-scratch/",
            ReleaseDate = new DateTime(2019, 12, 25),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"has-text-align-justify wp-block-paragraph\">I&#8217;ve got tons of time in the next couple of weeks and after doing some stuff with Angular, typescript and trying to learn Sass and get more familiar with Node, I feel it&#8217;s time to concentrate my efforts in learning Javascript properly.</p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">The first thing I did when I decided to pursue programming was a Javascript course at Coder Academy and I did learn a lot there, but I also remember having this anxiety to keep pushing and trying to finish the course quickly. </p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">Having had to go out there into the real production world and creating websites, it became clear that not knowing javascript properly is a liability and I can only go so far without knowing it properly. Now that I&#8217;m planning to go deeper into Angular to create more sophisticated applications, it will be very important to have some experience in JS, with more theory, more projects and understanding every line of code I ever write, pacing myself.</p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">At 37 I have this sense of urgency, but the reality is that without good fundamentals, I&#8217;m not going too far. And also, &#8220;we overestimate what can be done in a day and underestimate what can be done in a few years&#8221;. I love this phrase I came across at a couple of &#8220;Tim Ferriss&#8221; podcasts and I have to apply it&#8217;s wisdom here. </p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">I have huge plans for the coming decade and I&#8217;ll be coming back to discuss them here. One of them is to post more frequently haha.</p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">See you soon!</p>\n\n\n\n<p class=\"wp-block-paragraph\"></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31112,
            Title = "LEGACY: I love shadows",
            Slug = "i-love-shadows",
            Description = "Since my last post I’ve published my first two websites. The first is a very simple static page for a small accounting company in the South of Brazil, which I’m quite proud of....",
            CardImgUrl = "legacy-i-love-shadows.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2019/11/16/i-love-shadows/",
            ReleaseDate = new DateTime(2019, 11, 16),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"has-text-align-justify wp-block-paragraph\">Since my last post I&#8217;ve published my first two websites. The first is a very simple static page for a small accounting company in the South of Brazil, which I&#8217;m quite proud of. I think the result is pretty decent for a first attempt. Here&#8217;s the address. <a href=\"http://contabilidadeportoalegre.com.br/\">http://contabilidadeportoalegre.com.br/</a>. I used straight html and CSS with flexbox. The most complicated feature was the rotating banner using javascript. </p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">The second one is for a book author that wants to promote his book on a static webpage. For this one I used bootstrap for the first time (and loved it), and started playing with fonts. I still have to figure out browser compatibility as it&#8217;s slightly misadjusted in my android. Plus for both websites I can already see stuff I can do to improve the design. </p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">I found out about SHADOWS!! haha. I&#8217;m such a noob! But the reality is that a simple shadow effect makes a huge difference in the looks of a header (or any text really). I&#8217;ll be using a lot of those in my new project.</p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">My third project involves way more responsibility than the previous ones. It&#8217;s the website for a big dance event in Brisbane, which means the success of the event depends in some extent to the quality of the website. Also, it&#8217;s my first project in english and all my friends will see it. It will be the disclosure of my work to the community I live in. Plus it&#8217;s time sensitive, as the tickets for the event need to be sold and the website helps promote it. The pressure is on!!</p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">I&#8217;m changing strategies for this blog. I&#8217;m planning to post once a week to keep consistency but without using a bunch of time I could be using with actual work. After all, this is the motto and title of this blog: <strong>Shut up and code!!!</strong></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31113,
            Title = "LEGACY: Owned by forms",
            Slug = "owned-by-forms",
            Description = "Even though I haven’t been posting, I have been succeeding in carving out time for coding. I made great progress on my Bootstrap Journey, having completed one of the projects I’...",
            CardImgUrl = "legacy-owned-by-forms.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2019/10/17/owned-by-forms/",
            ReleaseDate = new DateTime(2019, 10, 17),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"has-text-align-justify wp-block-paragraph\">Even though I haven&#8217;t been posting, I have been succeeding in carving out time for coding. I made great progress on my Bootstrap Journey, having completed one of the projects I&#8217;m working on, a static page for the promotion of a book. It&#8217;s still not live but I think it will happen soon.</p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">After that I went back to my previous project, the website for a small accounting business and after putting together the design part I start working on the forms. After a couple of days I figured out how to build them, but the more I learned the more I found out how much I didn&#8217;t know. </p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">When I read this in a couple of years, it&#8217;s going to sound ridiculous, but&#8230; It turns out there are many stages of dealing with a form. The easieast one is the design. You could literally make a form in 10 minutes using basic HTML or Bootstrap. Things get slightly more complicated when trying to validate it. It took me a couple of days to figure out how to do that using javascript and then using Bootstrap alone. It turns out even the browser will help you do validation to an extent. </p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">But digging deeper I also found out it&#8217;s important to validate forms on the server for security reasons. This is when things started getting complicated. For almost a week I&#8217;ve been working on how to get server-side validation done. I&#8217;m still not sure how it relates to deploying it and sending the data somewhere. If I&#8217;m sending the data to my e-mail, using node.js for example, do I validate it on the same file I&#8217;m using to code the e-mail stuff? Or I should use different files? I couldn&#8217;t find a tutorial that talks about all the stages of assembling and dealing with a form. At least not using javascript. I know it can be done using other languages, but for whatever reason I didn&#8217;t want to deviate from JS right now. I feel it&#8217;s better to keep digging until it clicks than to try to shift to a completely different language.</p>\n\n\n\n<p class=\"wp-block-paragraph\">It feels great to write again!!!  Be back soon I hope. </p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31114,
            Title = "LEGACY: Back to work!",
            Slug = "back-to-work",
            Description = "Hello! Again I got side-tracked with all my non-coding life and didn’t manage to code as much as I wanted and to keep posting in the blog. Even though my initial idea of posting...",
            CardImgUrl = "legacy-back-to-work.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2019/10/01/back-to-work/",
            ReleaseDate = new DateTime(2019, 10, 1),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">Hello! Again I got side-tracked with all my non-coding life and didn’t manage to code as much as I wanted and to keep posting in the blog. Even though my initial idea of posting daily (or close to daily) didn’t work as planned, my ‘failure’ serves as feedback for my current lack of focus in my pursuit to become a developer.</p>\n\n\n\n<p class=\"wp-block-paragraph\">However, today is the first day of the moment and it seems like the perfect date to get back on track of writing here. The blog was always about keeping track of my discipline in regards to learning this new trade and I hope in October I’m able to do way more than I did in September.&nbsp;</p>\n\n\n\n<p class=\"wp-block-paragraph\">Two things will be very important to achieve that. Maybe I even mentioned this before in this blog, but I’m not going to read every post to check if I did: The first is to block out time in my calendar for coding and the second is to keep track of the hours I’m coding on a spreadsheet.</p>\n\n\n\n<p class=\"wp-block-paragraph\">So as I’m showing in the below picture, I blocked 2h30 to code tomorrow. It’s not a lot of time, but it’s enough to get some stuff done and restart. I’ll come back at night and write here the overview of what I got done and some other new things that have been happening.</p>\n\n\n\n<p class=\"wp-block-paragraph\">See you tomorrow!</p>\n\n\n\n<p class=\"wp-block-paragraph\"></p>\n\n\n\n<figure class=\"wp-block-image size-large\"><img src=\"https://shutupandcodeblog.files.wordpress.com/2019/10/screen-shot-2019-10-01-at-12.45.25-am.png?w=1024\" alt=\"\" class=\"wp-image-108\" /></figure>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31115,
            Title = "LEGACY: It feels good!",
            Slug = "94",
            Description = "Yesterday after posting on the blog I painfully restarted to code. It’s so hard to restart after stopping for a long time. That’s why we have to be really careful not to break a...",
            CardImgUrl = "legacy-94.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2019/09/06/94/",
            ReleaseDate = new DateTime(2019, 9, 6),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\" style=\"text-align:justify;\">Yesterday after posting on the blog I painfully restarted to code. It&#8217;s so hard to restart after stopping for a long time. That&#8217;s why we have to be really careful not to break a good habit or cut a certain flow. Going back into it can be very hard. And after so much time we can also forget how feel we good about a certain activity. About 10 minutes into coding I already felt very very good. There&#8217;s something about coding that just feels incredibly rewarding. It might be something related to dopamine releases related to trial and error. The instant and constant feedback loop is inebriating.</p>\n\n\n\n<p class=\"wp-block-paragraph\" style=\"text-align:justify;\">It also felt great to finish the draft of my first website. I made the styling for the footer. The interactions between CSS and HTML are sinking in and I feel I have it&#8217;s basic understanding down path. Tomorrow I&#8217;ll show the draft to my client and see what they think. They&#8217;ll probably ask for modifications, but I think that&#8217;s going to teach me how to interact with client&#8217;s needs and demands. </p>\n\n\n\n<p class=\"wp-block-paragraph\" style=\"text-align:justify;\">I have very restricted time to do any coding today, so I&#8217;ll try to do one hour before going to sleep to keep the average I established in the previous post. Chat later!!</p>\n\n\n\n<p class=\"wp-block-paragraph\"></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31116,
            Title = "LEGACY: I’m back!",
            Slug = "im-back",
            Description = "Two weeks ago I wrote my last post when I was leaving for a dance event and unfortunately it was the last thing I did related to coding. After a super busy weekend without any c...",
            CardImgUrl = "legacy-im-back.png",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2019/09/05/im-back/",
            ReleaseDate = new DateTime(2019, 9, 5),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"has-text-align-justify wp-block-paragraph\">Two weeks ago I wrote my last post when I was leaving for a dance event and unfortunately it was the last thing I did related to coding. After a super busy weekend without any contact with anything other than dancing, I had only a day gap before my next trip to Airlie Beach (North of Australia), for vacation and a bit of teaching. I made the mistake of not taking a laptop with me, which again made it&nbsp; impossible to do anything related to computer programming.&nbsp;</p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">I have only myself to blame as I’m not being able to tailor my life in a way that allows space for learning this new skill. It’s very easy to get distracted by things that are important but aren’t PRIORITY. And how do we differentiate those? I think the easiest way is to make a priority of the things that will lead to fulfilling our long term goals. I could spend all day doing important things like cleaning, improving my budget, organising my clothes, meal prep, and they all need to be done, of course. But they don’t need to be done so much in detail that don’t leave space for anything else.&nbsp;</p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">Today is Thursday and from today until Sunday I’ll be incredibly busy with dance. So my objective will be to do at least 1 hour of coding every day. From Monday I’ll be able to increase that time as I’ll go back to my normal routine.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Now shut up and code Pablo!!</p>\n\n\n\n<p class=\"wp-block-paragraph\"></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31117,
            Title = "LEGACY: Rediscovering Excel!",
            Slug = "days-11-and-12-rediscovering-excel",
            Description = "I started this blog close to two weeks ago and it’s time to regroup and assess my performance so I can make adjustments to move forward. One of the things I failed to fix comple...",
            CardImgUrl = "legacy-days-11-and-12-rediscovering-excel.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2019/08/21/days-11-and-12-rediscovering-excel/",
            ReleaseDate = new DateTime(2019, 8, 21),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"has-text-align-justify wp-block-paragraph\">I started this blog close to two weeks ago and it&#8217;s time to regroup and assess my performance so I can make adjustments to move forward.</p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">One of the things I failed to fix completely was my sleep. In the first week I had less than 6h a day. In the first few days I had as little as 4hs a day, sometimes in 2h bouts. That CANNOT be good. In the second week it improved a bit, but my flu disrupted my sleep once again. It felt great to finally have a good 8 hours of non-sick sleep last night. I feel recharged. </p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">To help me keep track of my sleep I created a very simple spreadsheet on excel. The joy of the of being a programmer is getting computers to do work for you and even something as simple as an excel table makes me proud, now that I&#8217;m in a coding career.  Excel can do lots of things that apps do, they just lack the design. But design alone won&#8217;t help you stay disciplined in the long run. If you&#8217;re driven to keep track of your sleep, budget, coffee intake or whatever, a spreadsheet will go a long way.  My next little excel projects will be tables to keep track of my coding hours, budget and coffee intake.</p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">I know there are heaps of spreadsheets available out there but I just like the idea of creating them myself and adjusting them perfectly to my needs. &#8220;Scratching my own itch&#8221; is a recurrent concept amongs creators. I heard that phrase many times listening to Tim Ferriss podcasts. Sometimes we might think we need an idea coming out of the skies to create a product that will be successful, but by creating something to help ourselves, we are very likely to be helping others who have the same needs.</p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">Buuuut, speaking of coding hours, my average was very close to 2hs a day, which in fact isn&#8217;t too bad. With my new spreadsheet I&#8217;ll keep closer  track of these hours. I&#8217;ll have the modest goal of maintaining the same average in the next couple of weeks. And the reason is that I&#8217;ll have 10 out of the next 14 days away from home. I&#8217;ll be in a dance festival down in the Gold Coast for 3 days, then vacationing/teaching up in Whitsundays for 5 days, then in Sydney to deal with documents in the Brazilian embassy for 2 days.  But even if I&#8217;m not coding, I&#8217;ll try to watch videos and read coding related stuff to stay on track.</p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">I&#8217;ve been slowly progressing on my website and I&#8217;m really happy about it! The top menu is completed and now I&#8217;m working on the footer. I&#8217;m in the middle of the process of incorporating a Google Maps API into it. The whole thing is a LOT OF FUN. I love that I can divide the projects into subprojects and focus in one at a time. I&#8217;m learning A TON from the experience of creating a website from scratch. Can&#8217;t wait to have it finished and show it to my client.</p>\n\n\n\n<p class=\"wp-block-paragraph\"></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31118,
            Title = "LEGACY: Still Sick",
            Slug = "day-10-still-sick",
            Description = "My routine is an absolute mess now due to having the flu. The pillars of human functioning (exercise, sleep, eating) have been compromised and I’m all over the place. The only p...",
            CardImgUrl = "legacy-day-10-still-sick.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2019/08/19/day-10-still-sick/",
            ReleaseDate = new DateTime(2019, 8, 19),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">My routine is an absolute mess now due to having the flu. The pillars of human functioning (exercise, sleep, eating) have been compromised and I&#8217;m all over the place.  The only positive side is that because I didn&#8217;t go to work once again this Sunday I could sit down for a few hours and work on my website.</p>\n\n\n\n<p class=\"wp-block-paragraph\">In about 4 hours, I didn&#8217;t accomplish much, though. I fixed the position of a few boxes using flexbox and created a space above the header for the contact details of my &#8220;client&#8221;. However I didn&#8217;t do it very elegantly html-wise and it&#8217;s causing a bit of a headache.  I want to tackle that today and add an address with a Google Maps feature for the footer and that&#8217;s it. I&#8217;ll be ready to show my client and start adding their content. </p>\n\n\n\n<p class=\"wp-block-paragraph\">However I already decided that once this website is ready I&#8217;ll create the next one using bootstrap. I want to learn how to use it. It&#8217;s very common to see bootstrap references when inspecting websites. </p>\n\n\n\n<p class=\"wp-block-paragraph\">And apparently it&#8217;s good to be learning React.js in 2019, acording to a few places I researched, so I&#8217;ll start looking into that.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Here are the videos I watched today while commuting. The first one talks about the different javascript frameworks. </p>\n\n\n\n<figure class=\"wp-block-embed is-type-rich is-provider-youtube wp-block-embed-youtube wp-embed-aspect-16-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<span class=\"embed-youtube\" style=\"text-align:center; display: block;\"><iframe loading=\"lazy\" class=\"youtube-player\" width=\"723\" height=\"407\" src=\"https://www.youtube.com/embed/pEbIhUySqbk?version=3&#038;rel=1&#038;showsearch=0&#038;showinfo=1&#038;iv_load_policy=1&#038;fs=1&#038;hl=en&#038;autohide=2&#038;wmode=transparent\" allowfullscreen=\"true\" style=\"border:0;\" sandbox=\"allow-scripts allow-same-origin allow-popups allow-presentation allow-popups-to-escape-sandbox\"></iframe></span>\n</div></figure>\n\n\n\n<p class=\"wp-block-paragraph\">The second one focus on how to find a job as a WebDev without experience. </p>\n\n\n\n<figure class=\"wp-block-embed is-type-rich is-provider-youtube wp-block-embed-youtube wp-embed-aspect-16-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<span class=\"embed-youtube\" style=\"text-align:center; display: block;\"><iframe loading=\"lazy\" class=\"youtube-player\" width=\"723\" height=\"407\" src=\"https://www.youtube.com/embed/ebJ0XBOjowo?version=3&#038;rel=1&#038;showsearch=0&#038;showinfo=1&#038;iv_load_policy=1&#038;fs=1&#038;hl=en&#038;autohide=2&#038;wmode=transparent\" allowfullscreen=\"true\" style=\"border:0;\" sandbox=\"allow-scripts allow-same-origin allow-popups allow-presentation allow-popups-to-escape-sandbox\"></iframe></span>\n</div></figure>\n\n\n\n<p class=\"wp-block-paragraph\">And the last, about working as a freelancer (I didn&#8217;t finish this one)</p>\n\n\n\n<figure class=\"wp-block-embed is-type-rich is-provider-youtube wp-block-embed-youtube wp-embed-aspect-16-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<span class=\"embed-youtube\" style=\"text-align:center; display: block;\"><iframe loading=\"lazy\" class=\"youtube-player\" width=\"723\" height=\"407\" src=\"https://www.youtube.com/embed/m2N3tmJ_A0Q?version=3&#038;rel=1&#038;showsearch=0&#038;showinfo=1&#038;iv_load_policy=1&#038;fs=1&#038;hl=en&#038;autohide=2&#038;start=477&#038;wmode=transparent\" allowfullscreen=\"true\" style=\"border:0;\" sandbox=\"allow-scripts allow-same-origin allow-popups allow-presentation allow-popups-to-escape-sandbox\"></iframe></span>\n</div></figure>\n\n\n\n<p class=\"wp-block-paragraph\">I think I&#8217;m just past the worst phase of my flu and I had a terrible night of sleep last night, so I&#8217;ll try my best to get some coding done today.</p>\n\n\n\n<p class=\"wp-block-paragraph\">C ya!</p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31119,
            Title = "LEGACY: Flu :(",
            Slug = "day-9-flu",
            Description = "I had a decent day of coding this Friday, finishing the rotating banner for my website. However I was a bit disppointed the banner isn’t responsive so I’ll probably try a differ...",
            CardImgUrl = "legacy-day-9-flu.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2019/08/18/day-9-flu/",
            ReleaseDate = new DateTime(2019, 8, 18),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"has-text-align-justify wp-block-paragraph\">I had a decent day of coding this Friday, finishing the rotating banner for my website. However I was a bit disppointed the banner isn&#8217;t responsive so I&#8217;ll probably try a different approach. Apparently it can be done using jquery or bootstrap, which I haven&#8217;t used yet, so it could be good exercise. </p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">I still don&#8217;t think I can do a lot of stuff on my own but I&#8217;m starting to understand what I need to use and when. I&#8217;m still unsure about how much code I actually need to memorise, since everything I need is always readily avaiable in my archives, but I guess I&#8217;ll figure that out soon.  What&#8217;s certain is that I won&#8217;t think of speed when developing projects. I&#8217;d rather take a long time in a project and fully understand it. </p>\n\n\n\n<figure class=\"wp-block-embed is-type-rich is-provider-youtube wp-block-embed-youtube wp-embed-aspect-16-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<span class=\"embed-youtube\" style=\"text-align:center; display: block;\"><iframe loading=\"lazy\" class=\"youtube-player\" width=\"723\" height=\"407\" src=\"https://www.youtube.com/embed/TLF6r1R6EDw?version=3&#038;rel=1&#038;showsearch=0&#038;showinfo=1&#038;iv_load_policy=1&#038;fs=1&#038;hl=en&#038;autohide=2&#038;start=1854&#038;wmode=transparent\" allowfullscreen=\"true\" style=\"border:0;\" sandbox=\"allow-scripts allow-same-origin allow-popups allow-presentation allow-popups-to-escape-sandbox\"></iframe></span>\n</div></figure>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">This is the video that I used for the rotating banner. It was quite a long piece code, with lots of CSS/Javascript/HTML mixed together to make the banner work. </p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">Saturday was a big day (I&#8217;m writing at the end of the day) and due to work and having the flu I couldn&#8217;t get anything done, so I&#8217;ll just have a look into one of the other possibilities for a rotating banner before I go to sleep. Not a lot of time, but it helps keep the consistency. </p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31120,
            Title = "LEGACY: Make your bed every day!",
            Slug = "day-8-make-your-bed-every-day",
            Description = "Hello folks!! Yesterday I had a day off at work, which allowed me to put a nice 4h30 into coding. It felt great! I finally completed the skeleton of my website and started tryin...",
            CardImgUrl = "legacy-day-8-make-your-bed-every-day.jpeg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2019/08/16/day-8-make-your-bed-every-day/",
            ReleaseDate = new DateTime(2019, 8, 16),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">Hello folks!! Yesterday I had a day off at work, which allowed me to put a nice 4h30 into coding. It felt great! I finally completed the skeleton of my website and started trying to create a rotating banner using javascript. That&#8217;s my goal for today.  The total of hours dedicated to coding this week was 1h50&#8242;, which is not too bad, but I want to increase that by decreasing distractions.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Yesterday at the gym I watched a cool video about discipline. It&#8217;s one of my favourite topics as it&#8217;s something I&#8217;ve been struggling it and I find one of the most important values in life. Very good advice by retired Admiral William H. McRaven !</p>\n\n\n\n<figure class=\"wp-block-embed is-type-rich is-provider-youtube wp-block-embed-youtube wp-embed-aspect-16-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<span class=\"embed-youtube\" style=\"text-align:center; display: block;\"><iframe loading=\"lazy\" class=\"youtube-player\" width=\"723\" height=\"407\" src=\"https://www.youtube.com/embed/jYV9er3coh4?version=3&#038;rel=1&#038;showsearch=0&#038;showinfo=1&#038;iv_load_policy=1&#038;fs=1&#038;hl=en&#038;autohide=2&#038;wmode=transparent\" allowfullscreen=\"true\" style=\"border:0;\" sandbox=\"allow-scripts allow-same-origin allow-popups allow-presentation allow-popups-to-escape-sandbox\"></iframe></span>\n</div></figure>\n\n\n\n<p class=\"wp-block-paragraph\">I&#8217;ve also been listening to this amazing podcast by Dan Carlin. I&#8217;m totally hooked. It&#8217;s about History and the first few episodes are about World War I. The guy is an amazing story teller. Hignly recommend it! </p>\n\n\n\n<p class=\"wp-block-paragraph\">Now shut up and code Pablo!!</p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31121,
            Title = "LEGACY: My first “fail” day",
            Slug = "days-6-and-7-my-first-fail-day",
            Description = "I didn’t do any coding yesterday! Had a massive day at work (even though it was a public holiday in Australia), and caught up on my sleep, but for the first time I started this...",
            CardImgUrl = "legacy-days-6-and-7-my-first-fail-day.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2019/08/15/days-6-and-7-my-first-fail-day/",
            ReleaseDate = new DateTime(2019, 8, 15),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"has-text-align-justify wp-block-paragraph\">I didn&#8217;t do any coding yesterday! Had a massive day at work (even though it was a public holiday in Australia), and caught up on my sleep, but for the first time I started this blog I didn&#8217;t post or work on any coding. Even after sleeping for a total of 9 hours last night my average since I started this blog is only <strong>5h40</strong>. That shows how much I needed to sleep yesterday. </p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">Wednesday was one of those debacle days where things just cascade for the worse and nothing gets done. Eating was poor, sleeping not great, didn&#8217;t exercise or code. At least got some important stuff done at work.</p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">Also, Tuesday I spent 2h30 solid hours working on my first website. That takes my average time coding since I started the blog to 1h30 approximately. <strong>I HAVE TO INCREASE THAT</strong>. An average of 4hs is the minimum in my opintion. By the way, I didn&#8217;t mention this, but I did have a few websites before. In my early twenties I remember having a few websites about football, porn and books. They were all made with HTML only. I remember applying CSS style that I got somewhere from the internet but that&#8217;s about it.</p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">It felt really good to actually be doing something that will be out there in the world. I think the sense of usefulness is really important to keep me motivated for the daily grind of learning how to code. As much as I love random exercises and understand how important they are, I&#8217;ll probably try to get as much &#8220;real life&#8221; practice as possible.</p>\n\n\n\n<p class=\"wp-block-paragraph\">This is the tutorial I used to create my first website. It doesn&#8217;t use any framework because I wanted to learn how to build something from scratch using CSS. I&#8217;ll probably be finishing it in the next few days If I don&#8217;t get distracted. I highly recommend this guy&#8217;s tutorials. His channel is called <a href=\"https://www.youtube.com/channel/UC29ju8bIPH5as8OGnQzwJyA\">Traversy Media</a>. </p>\n\n\n\n<figure class=\"wp-block-embed is-type-rich is-provider-youtube wp-block-embed-youtube wp-embed-aspect-16-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<span class=\"embed-youtube\" style=\"text-align:center; display: block;\"><iframe loading=\"lazy\" class=\"youtube-player\" width=\"723\" height=\"407\" src=\"https://www.youtube.com/embed/Wm6CUkswsNw?version=3&#038;rel=1&#038;showsearch=0&#038;showinfo=1&#038;iv_load_policy=1&#038;fs=1&#038;hl=en&#038;autohide=2&#038;wmode=transparent\" allowfullscreen=\"true\" style=\"border:0;\" sandbox=\"allow-scripts allow-same-origin allow-popups allow-presentation allow-popups-to-escape-sandbox\"></iframe></span>\n</div></figure>\n\n\n\n<p class=\"wp-block-paragraph\">Ok, shut up and code Pablo! Goals for today: To code for at least 4 hours and get closer to finishing my website. </p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31122,
            Title = "LEGACY: Defeated by Snickers",
            Slug = "day-5-defeated-by-snickers",
            Description = "Hey folks! Again a busy day at work and didn’t have a lot of time to code. Still trying to catch up on my sleep I had a 2 hour nap during the day but unfortunately only 3 hours...",
            CardImgUrl = "legacy-day-5-defeated-by-snickers.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2019/08/13/day-5-defeated-by-snickers/",
            ReleaseDate = new DateTime(2019, 8, 13),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"has-text-align-justify wp-block-paragraph\">Hey folks! Again a busy day at work and didn’t have a lot of time to code. Still trying to catch up on my sleep I had a 2 hour nap during the day but unfortunately only 3 hours last night. The good news is the after 3 days absent I went to the gym again for a back workout. I was starving at night before gym and ended up succumbing to the temptation of buying two double snicker bars. But other than that I ate pretty healthy.</p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">I did spend some time commuting, where I finished watching the video I was working with in the last couple of days and watched a couple of others. The first was about common mistakes new programmers make. It’s super fun and I highly recommend this guy Jarvis Johnson. It made me feel good because I share his views and already had his tips somewhat ingrained in my programmer mindset.&nbsp;<br></p>\n\n\n\n<figure class=\"wp-block-embed is-type-rich is-provider-youtube wp-block-embed-youtube wp-embed-aspect-16-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<span class=\"embed-youtube\" style=\"text-align:center; display: block;\"><iframe loading=\"lazy\" class=\"youtube-player\" width=\"723\" height=\"407\" src=\"https://www.youtube.com/embed/YV8DldSzZvQ?version=3&#038;rel=1&#038;showsearch=0&#038;showinfo=1&#038;iv_load_policy=1&#038;fs=1&#038;hl=en&#038;autohide=2&#038;wmode=transparent\" allowfullscreen=\"true\" style=\"border:0;\" sandbox=\"allow-scripts allow-same-origin allow-popups allow-presentation allow-popups-to-escape-sandbox\"></iframe></span>\n</div></figure>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">Then I started watching this amazing tutorial about how to make a to-do-list app using javascript. It’s exactly the type of thing I want to learn, with all the interactions between css, html and javascript. I’ll definitely dive into it after I finish my current project.&nbsp;</p>\n\n\n\n<figure class=\"wp-block-embed is-type-rich is-provider-youtube wp-block-embed-youtube wp-embed-aspect-16-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<span class=\"embed-youtube\" style=\"text-align:center; display: block;\"><iframe loading=\"lazy\" class=\"youtube-player\" width=\"723\" height=\"407\" src=\"https://www.youtube.com/embed/b8sUhU_eq3g?version=3&#038;rel=1&#038;showsearch=0&#038;showinfo=1&#038;iv_load_policy=1&#038;fs=1&#038;hl=en&#038;autohide=2&#038;wmode=transparent\" allowfullscreen=\"true\" style=\"border:0;\" sandbox=\"allow-scripts allow-same-origin allow-popups allow-presentation allow-popups-to-escape-sandbox\"></iframe></span>\n</div></figure>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">Programming wise I had 40 minutes only, at the end of the day. I’m not proud of the small amount of time I managed to block for coding, but was proud that I pushed through and worked on my learning for 4 consecutive days now. Consistency is key.&nbsp;</p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">Right now I’ll focus on finishing the website I started about a month ago. I offered to do it for free for a small accounting firm back in Brazil thinking it would be a great exercise to put together a simple business website without the responsibilities of an online store. So that’s what I’ll be doing in the next 3 hours. 🙂</p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31123,
            Title = "LEGACY: Shut up and Code",
            Slug = "day-4-shut-up-and-code",
            Description = "I’ll keep this post short because I want to code a lot this Monday as I finally have some free time. I finally had a solid night of sleep and my average in the last 4 days jumpe...",
            CardImgUrl = "legacy-day-4-shut-up-and-code.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2019/08/12/day-4-shut-up-and-code/",
            ReleaseDate = new DateTime(2019, 8, 12),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\">I&#8217;ll keep this post short because I want to code a lot this Monday as I finally have some free time. I finally had a solid night of sleep and my average in the last 4 days jumpe to 5h20. Still below ideal, but it will improve this week.</p>\n\n\n\n<p class=\"wp-block-paragraph\">I could have done a better job at eating, as I&#8217;ve had chocolate in the end of the day but for the fourth consecutive day I didn&#8217;t buy it, which is great. I had 3 coffees, which is within the normal intake.</p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">Because Sunday is my busiest day at work, I couldn&#8217;t dedicate a lot of time for coding. I did the third exercise from yesterday&#8217;s video: a program to replace the letters in a string with the next letter of the alphabet. I had previously done a similar challenge at free code camp and the solution used a &#8220;for&#8221; loop, but this time the solution used the .map method. From now on I&#8217;ll pay more attention to trying to solve the same exercise in different ways instead of jumping to the next challenge so I can develop a wider toolkit. Adding yesterday&#8217;s hour of coding took my average since the blog started to 1h30 a day. </p>\n\n\n\n<figure class=\"wp-block-embed is-type-rich is-provider-youtube wp-block-embed-youtube wp-embed-aspect-16-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<span class=\"embed-youtube\" style=\"text-align:center; display: block;\"><iframe loading=\"lazy\" class=\"youtube-player\" width=\"723\" height=\"407\" src=\"https://www.youtube.com/embed/N65RvNkZFGE?version=3&#038;rel=1&#038;showsearch=0&#038;showinfo=1&#038;iv_load_policy=1&#038;fs=1&#038;hl=en&#038;autohide=2&#038;wmode=transparent\" allowfullscreen=\"true\" style=\"border:0;\" sandbox=\"allow-scripts allow-same-origin allow-popups allow-presentation allow-popups-to-escape-sandbox\"></iframe></span>\n</div></figure>\n\n\n\n<p class=\"wp-block-paragraph\">Now shut up and code Pablo!!</p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31124,
            Title = "LEGACY: Meeting Larry Page and Linus Torvalds",
            Slug = "day-3-meeting-larry-page-and-linus-torvalds",
            Description = "It’s a chilly Sunday morning here in Brisbane and again I had to sleep very little due to work. I had about 3 h of sleep last night. After last post I had another 2h30 in the af...",
            CardImgUrl = "legacy-day-3-meeting-larry-page-and-linus-torvalds.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2019/08/11/day-3-meeting-larry-page-and-linus-torvalds/",
            ReleaseDate = new DateTime(2019, 8, 11),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"has-text-align-justify wp-block-paragraph\">It’s a chilly Sunday morning here in Brisbane and again I had to sleep very little due to work. I had about 3 h of sleep last night. After last post I had another 2h30 in the afternoon, which takes my average to 4h25’ in the last couple of days.</p>\n\n\n\n<p class=\"wp-block-paragraph\">Diet wise, I didn’t have sweets, except for a bit of sweet wine. I did my 10 minutes of meditation after napping, which was awesome. It has such a great impact on my day!</p>\n\n\n\n<p class=\"wp-block-paragraph\">During commute, I watched a couple of videos of Larry Page (founder of Google), one of Linus Torvalds, a very interesting one about how to get hired by Google:</p>\n\n\n\n<figure class=\"wp-block-embed is-type-rich is-provider-youtube wp-block-embed-youtube wp-embed-aspect-16-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<span class=\"embed-youtube\" style=\"text-align:center; display: block;\"><iframe loading=\"lazy\" class=\"youtube-player\" width=\"723\" height=\"407\" src=\"https://www.youtube.com/embed/zhUgaKb0s5A?version=3&#038;rel=1&#038;showsearch=0&#038;showinfo=1&#038;iv_load_policy=1&#038;fs=1&#038;hl=en&#038;autohide=2&#038;wmode=transparent\" allowfullscreen=\"true\" style=\"border:0;\" sandbox=\"allow-scripts allow-same-origin allow-popups allow-presentation allow-popups-to-escape-sandbox\"></iframe></span>\n</div></figure>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">And another one with tips on how to learn coding. A couple of tips that stood out were: “Don’t memorise code”, which is something that always occurs to me when I’m tackling projects. And the other is something along the lines of: “It’s ok to get stuck in a project”. The idea is that it’s better to spend a week in a project and fully understand it than to do 7 projects in 7 days and don’t know too well what was going on. Good Stuff.</p>\n\n\n\n<figure class=\"wp-block-embed is-type-rich is-provider-youtube wp-block-embed-youtube wp-embed-aspect-16-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<span class=\"embed-youtube\" style=\"text-align:center; display: block;\"><iframe loading=\"lazy\" class=\"youtube-player\" width=\"723\" height=\"407\" src=\"https://www.youtube.com/embed/X4rU02088Xc?version=3&#038;rel=1&#038;showsearch=0&#038;showinfo=1&#038;iv_load_policy=1&#038;fs=1&#038;hl=en&#038;autohide=2&#038;wmode=transparent\" allowfullscreen=\"true\" style=\"border:0;\" sandbox=\"allow-scripts allow-same-origin allow-popups allow-presentation allow-popups-to-escape-sandbox\"></iframe></span>\n</div></figure>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">Unfortunately I had a Saturday full of work which didn’t leave me a lot of time for coding, but I’m hoping to catch up tomorrow. The amount of time dedicated to coding was 1h, which takes my average to 1h45’. I worked on two beginners javascript projects from this video:&nbsp;</p>\n\n\n\n<figure class=\"wp-block-embed is-type-rich is-provider-youtube wp-block-embed-youtube wp-embed-aspect-16-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<span class=\"embed-youtube\" style=\"text-align:center; display: block;\"><iframe loading=\"lazy\" class=\"youtube-player\" width=\"723\" height=\"407\" src=\"https://www.youtube.com/embed/N65RvNkZFGE?version=3&#038;rel=1&#038;showsearch=0&#038;showinfo=1&#038;iv_load_policy=1&#038;fs=1&#038;hl=en&#038;autohide=2&#038;wmode=transparent\" allowfullscreen=\"true\" style=\"border:0;\" sandbox=\"allow-scripts allow-same-origin allow-popups allow-presentation allow-popups-to-escape-sandbox\"></iframe></span>\n</div></figure>\n\n\n\n<p class=\"wp-block-paragraph\">It does feel a bit funny to work on projects that don’t really create something, but I found that when I was creating my website I spent long hours doing CSS and HTML and not many on javascript. That’s why I’ll prioritise JS, especially on the days when I don’t have too many available hours.&nbsp;</p>\n\n\n\n<p class=\"wp-block-paragraph\">Well, time to shut up and code!&nbsp;<br></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31125,
            Title = "LEGACY: Learning Git and Git Hub and getting to know Brendan Eich",
            Slug = "day-2-learning-git-and-git-hub-and-getting-to-know-brendan-eich",
            Description = "It’s 735am and I didn’t get a lot of sleep last night due to work and I’ll probably nap later before going to work in the afternoon but I wanted to put in a few hours of coding....",
            CardImgUrl = "legacy-day-2-learning-git-and-git-hub-and-getting-to-know-brendan-eich.png",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2019/08/10/day-2-learning-git-and-git-hub-and-getting-to-know-brendan-eich/",
            ReleaseDate = new DateTime(2019, 8, 10),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"has-text-align-justify wp-block-paragraph\">It’s 735am and I didn’t get a lot of sleep last night due to work and I’ll probably nap later before going to work in the afternoon but I wanted to put in a few hours of coding. Before I talk about my learning since the last post, here are a couple of details about lifestyle. </p>\n\n\n\n<p class=\"wp-block-paragraph\">Between napping and sleeping, in the last 2 days I had an average of 4 hours of sleep:</p>\n\n\n\n<figure class=\"wp-block-table\"><table><tbody><tr><td>Thu-Fri:</td><td>315am to 745am + 315pm to 430pm (6h)</td></tr><tr><td>Fri-Sat:&nbsp;</td><td>230am to 415am (1h45)</td></tr><tr><td>Total:&nbsp;</td><td>7h45</td></tr></tbody></table></figure>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">I know it’s very little sleep but I can catch up on Monday during the day. And it plus it serves the purpose of developing grit. One of my biggest problems lately has been to procrastinate to get out of bed and that has a very detrimental cascade effect.<br></p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">Unfortunately I couldn’t exercise due to a busy schedule, but I’ve been consistent in the gym this week, so it doesn’t concern me. I also had a bottle of Moscato Wine + 3\\4 of a big brownie, so my sugar intake was less than ideal. I almost never drink so that’s not a big deal, but the chocolate issue needs to be attacked. At least I didn’t buy it, so that makes me feel a bit better. Plus I had 3 cups of instant coffee: two while learning in the morning and one before work.&nbsp;<br></p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">Now shut up and code Pablo! Ok, yesterday after posting on the blog I learned the basics of Git and Git Hub. I used this excellent tutorial:  </p>\n\n\n\n<figure class=\"wp-block-embed is-type-rich is-provider-youtube wp-block-embed-youtube wp-embed-aspect-16-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<span class=\"embed-youtube\" style=\"text-align:center; display: block;\"><iframe loading=\"lazy\" class=\"youtube-player\" width=\"723\" height=\"407\" src=\"https://www.youtube.com/embed/SWYqp7iY_Tc?version=3&#038;rel=1&#038;showsearch=0&#038;showinfo=1&#038;iv_load_policy=1&#038;fs=1&#038;hl=en&#038;autohide=2&#038;wmode=transparent\" allowfullscreen=\"true\" style=\"border:0;\" sandbox=\"allow-scripts allow-same-origin allow-popups allow-presentation allow-popups-to-escape-sandbox\"></iframe></span>\n</div></figure>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">It sounds like the type of tool I’ll be using a lot. It didn’t seem very hard, at least for the basic purposes of version control and cloud storage. Only time will tell. I didn’t do any coding, only learning in the morning and watching videos while commuting. The total hands-on time dedicated to programming was 2h30. <br></p>\n\n\n\n<p class=\"wp-block-paragraph\">I watched a presentation about the history of Javascript by it’s creator Brendan Eich: </p>\n\n\n\n<figure class=\"wp-block-embed is-type-rich is-provider-youtube wp-block-embed-youtube wp-embed-aspect-16-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<span class=\"embed-youtube\" style=\"text-align:center; display: block;\"><iframe loading=\"lazy\" class=\"youtube-player\" width=\"723\" height=\"407\" src=\"https://www.youtube.com/embed/aX3ZABCdC38?version=3&#038;rel=1&#038;showsearch=0&#038;showinfo=1&#038;iv_load_policy=1&#038;fs=1&#038;hl=en&#038;autohide=2&#038;wmode=transparent\" allowfullscreen=\"true\" style=\"border:0;\" sandbox=\"allow-scripts allow-same-origin allow-popups allow-presentation allow-popups-to-escape-sandbox\"></iframe></span>\n</div></figure>\n\n\n\n<p class=\"wp-block-paragraph\">And a wider range interview with him about computer science:</p>\n\n\n\n<figure class=\"wp-block-embed is-type-rich is-provider-youtube wp-block-embed-youtube wp-embed-aspect-16-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<span class=\"embed-youtube\" style=\"text-align:center; display: block;\"><iframe loading=\"lazy\" class=\"youtube-player\" width=\"723\" height=\"407\" src=\"https://www.youtube.com/embed/IPxQ9kEaF8c?version=3&#038;rel=1&#038;showsearch=0&#038;showinfo=1&#038;iv_load_policy=1&#038;fs=1&#038;hl=en&#038;autohide=2&#038;wmode=transparent\" allowfullscreen=\"true\" style=\"border:0;\" sandbox=\"allow-scripts allow-same-origin allow-popups allow-presentation allow-popups-to-escape-sandbox\"></iframe></span>\n</div></figure>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">The jargon is still way above my head but I love to watch these things regardless so I can have a better view of the big picture while getting used to the way these great computer science think. Brendan isn’t a great orator but his passion is very inspiring. It sounds like this man lives and breathes what he does for a living. When he speaks, it doesn’t sound like work. He truly loves it. I’ll be following him around.&nbsp;</p>\n\n\n\n<p class=\"wp-block-paragraph\">The last thing I watched was half a javascript tutorial for beginners: </p>\n\n\n\n<figure class=\"wp-block-embed is-type-rich is-provider-youtube wp-block-embed-youtube wp-embed-aspect-16-9 wp-has-aspect-ratio\"><div class=\"wp-block-embed__wrapper\">\n<span class=\"embed-youtube\" style=\"text-align:center; display: block;\"><iframe loading=\"lazy\" class=\"youtube-player\" width=\"723\" height=\"407\" src=\"https://www.youtube.com/embed/W6NZfCO5SIk?version=3&#038;rel=1&#038;showsearch=0&#038;showinfo=1&#038;iv_load_policy=1&#038;fs=1&#038;hl=en&#038;autohide=2&#038;wmode=transparent\" allowfullscreen=\"true\" style=\"border:0;\" sandbox=\"allow-scripts allow-same-origin allow-popups allow-presentation allow-popups-to-escape-sandbox\"></iframe></span>\n</div></figure>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">I’m still going to hammer beginners tutorials for a while. I still don’t feel I have a good grasp of the basics. I still have to think a lot and search my notes before writing any piece of code. My plan for the next couple of days is to solve some easy challenges that involve the stuff I want to get good at, such as loops and conditionals and apply to a web page I’m creating. I’ll explain this project later.&nbsp;</p>\n\n\n\n<p class=\"has-text-align-justify wp-block-paragraph\">So that’s it for now!! It’s a beautiful day outside, it feels like the Winter is leaving us and the Spring is almost here. Sounds like a great day for coding! I’ll be back tomorrow morning.&nbsp;<br></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31126,
            Title = "LEGACY: Starting!",
            Slug = "example-post",
            Description = "“Set up the alarm clock” — Jocko Willink. Hi there!! It’s a beautiful Friday morning in Brisbane Australia! Even though I’ve been learning how to code for a while now, I’ll call...",
            CardImgUrl = "legacy-example-post.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2019/08/08/example-post/",
            ReleaseDate = new DateTime(2019, 8, 8),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<blockquote class=\"wp-block-quote is-layout-flow wp-block-quote-is-layout-flow\"><p>&#8220;Set up the alarm clock&#8221;</p><cite>— Jocko Willink.</cite></blockquote>\n\n\n\n<p class=\"wp-block-paragraph\">Hi there!! It&#8217;s a beautiful Friday morning in Brisbane Australia! Even though I&#8217;ve been learning how to code for a while now, I&#8217;ll call today &#8220;Day One&#8221; because I&#8217;m starting this morning to reshape my life around my goal. </p>\n\n\n\n<p class=\"wp-block-paragraph\">The first thing I needed to changed was my sleeping habits. I&#8217;ve been going to bed from 3 to 5am and waking up around mid day and that was affecting my mood, as I felt like I was missing the mornings. There&#8217;s a freshness in the mornings that I don&#8217;t want to miss anymore. Plus that meant I only had a few hours before starting to work, which meant I could only learn after work, when I&#8217;m already tired and not absorbing information so well.</p>\n\n\n\n<p class=\"wp-block-paragraph\">With my new routine I want to close my calendar to pretty much anything other than coding and meditating from 8am to at least 2pm. I did sleep at 315am last night but just pushed myself to wake up using an alarm clock and reshaped my sleeping the hard way . </p>\n\n\n\n<p class=\"wp-block-paragraph\">The second thing I want to fix is my diet. I do eat healthy but I have a bit of a carbs problem. Often times I can&#8217;t resist the urge for  late night chocolate. Also, I eat too much fruit (in my porridge in the morning) plus a few more during the day if I&#8217;m available. There&#8217;s nothing wrong with fruit but at least in my case it contributes to sluggishness. When I tried low carbs diet I was alert for way longer than normal. Not sure what science has been saying about it.</p>\n\n\n\n<p class=\"wp-block-paragraph\">The plan for my coding day is to learn how to use Git and work on a freecodecamp javascript challenge: <a href=\"https://learn.freecodecamp.org/javascript-algorithms-and-data-structures/javascript-algorithms-and-data-structures-projects/telephone-number-validator\">Telephone Number Validator</a> . It&#8217;s a nice challenge that involves a lot of RegEx, something I recently find out I need to understand really well. I won&#8217;t be posting tonight, but definitely tomorrow morning.</p>\n\n\n\n<p class=\"wp-block-paragraph\">See you on the other side!</p>\n\n\n\n<p class=\"wp-block-paragraph\"></p>" },
                    ]
                }
            ]
        },
        new Article
        {
            Id = 31127,
            Title = "LEGACY: A Little Bit About Me",
            Slug = "welcome-to-my-blog",
            Description = "My name is Pablo de Souza, I’m 37 years old and consider myself a very lucky person. I was born in a middle-class family in Brazil with enough health, resources and education to...",
            CardImgUrl = "legacy-welcome-to-my-blog.jpg",
            Author = "Pablo Souza",
            Url = "https://cappuccinocodes.wordpress.com/2019/08/08/welcome-to-my-blog/",
            ReleaseDate = new DateTime(2019, 8, 8),
            Area = Area.Blog,
            Blocks =
            [
                new Block
                {
                    Paragraphs =
                    [
                        new Paragraph { Body = "<p class=\"wp-block-paragraph\" style=\"text-align:justify;\">My name is Pablo de Souza, I&#8217;m 37 years old and consider myself a very lucky person. I was born in a middle-class family in Brazil with enough health, resources and education to live a comfortable life. Even though I lived life in my terms, having a lot of fun and never having any major problems, I feel like at this point there&#8217;s something missing.</p>\n\n\n\n<p class=\"wp-block-paragraph\" style=\"text-align:justify;\">I could write many paragraphs in a self psychoanalisis session to try and find the reasons for my current restlessness, but I just feel I have the capacity to tailor the rest of my existence on earth in a better way than I&#8217;ve done so far. </p>\n\n\n\n<p class=\"wp-block-paragraph\" style=\"text-align:justify;\">I have reasonably well paid dance teacher job. I love what I do and my annual income puts me amongst the top 2% better paid people on earth (don&#8217;t think I make a lot of money please, you don&#8217;t need a lot -in a first world country standard &#8211; to be top 1%), but I can&#8217;t see myself as a dance teacher at 50. I definitely want to keep dancing, but I don&#8217;t want to rely on my body to be earning a living in an industry that values youthfulness and fitness. Hence the need for a career change.</p>\n\n\n\n<p class=\"wp-block-paragraph\" style=\"text-align:justify;\">Five years ago I migrated to Australia and I&#8217;m about a year away from getting a permanent visa, which would allow me the right to study affordably in this beautiful country. The perspective of going back to uni made me think deeply about my possibilities and I had my mind set in the health industry (my father is a doctor, my mother a nurse and I have a degree in Sports Science) . The problem is that working in healthcare means I&#8217;m stuck geographically in 99% of the jobs and I can&#8217;t stand the idea of not doing a bunch of traveling before I go to the grave.</p>\n\n\n\n<p class=\"wp-block-paragraph\" style=\"text-align:justify;\">Something else that contributed to wanting to become a developer was the possibility of self-teaching. Being a doctor or a nurse require knowledge that you can only learn at uni. There&#8217;s an appeal to me in the fact that I can sit my butt on a chair in front of a computer and learn all I need by myself.  </p>\n\n\n\n<p class=\"wp-block-paragraph\" style=\"text-align:justify;\">Down deep I know that the person I need to become to achieve such thing mostly through self-teaching doesn&#8217;t exist yet. But that person is very attractive to me. I want to become that guy: Driven, focused, curious, disciplined and organised.  I think these characteristics summon what I need to be to achieve the goal of becoming a programmer. </p>\n\n\n\n<p class=\"wp-block-paragraph\" style=\"text-align:justify;\">Right now If I had to give scores from 0 to 5 to myself in each of those attributes I&#8217;d say I&#8217;m very curious (5), but I&#8217;m lacking all of the rest: not disciplined enough (2), not driven enough (2), not focused enough (2), and dismally disorganized (probably a zero).</p>\n\n\n\n<p class=\"wp-block-paragraph\" style=\"text-align:justify;\">That&#8217;s why I&#8217;m calling this blog &#8220;Shut up and Code&#8221;. I&#8217;ve read, researched and talked a lot about the subject since I made the decision to learn to code a few months ago, but I haven&#8217;t put the hours in front of a computer doing actual coding. I do value reads that will improve me as a human and to have better knowledge of the big picture, but the fact is that I have to make up for the fact that I&#8217;m starting this thing late in life and PUT IN THE HOURS.  I have to attack this aggressively or otherwise I will fail. This is beyond anything I&#8217;ve ever accomplished in life (by miles) and the person that I am right now can only fail. </p>\n\n\n\n<p class=\"wp-block-paragraph\" style=\"text-align:justify;\">Right now this blog is for me only. I do want it to tell a succesful story of a 37 y old that against all odds was able to change himself and change careers and hopefully inspire and help people in the future. But right now I want to use this space to help me clarify my ideas, keep me centered and focus and above all: maintain discipline. I&#8217;ve started many blogs and failed to be consistent every single time. This has to change. Now. I&#8217;m running out of time. The grave is growing closer. </p>\n\n\n\n<p class=\"wp-block-paragraph\"></p>" },
                    ]
                }
            ]
        },
    ];
}
