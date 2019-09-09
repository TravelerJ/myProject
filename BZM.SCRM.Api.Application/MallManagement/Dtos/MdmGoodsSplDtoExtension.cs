using SCRM.Domain.MallManagement.Entitys;

namespace SCRM.Application.MallManagement.Dtos
{
    /// <summary>
    /// 数据传输对象扩展
    /// </summary>
    public static class MdmGoodsSplDtoExtension {    
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static MdmGoodsSpl ToEntity( this MdmGoodsSplDto dto ) {
            if( dto == null )
                return new MdmGoodsSpl();
            return new MdmGoodsSpl() {
                Id = dto.Id,
                PL_BUYER_NO = dto.PL_BUYER_NO,
                PL_BUYER_NAME = dto.PL_BUYER_NAME,
                PL_BUYER_TYPE = dto.PL_BUYER_TYPE,
                PL_SELLER_NO = dto.PL_SELLER_NO,
                PL_SELLER_NAME = dto.PL_SELLER_NAME,
                PL_SELLER_TYPE = dto.PL_SELLER_TYPE,
                PL_GOODS_NO = dto.PL_GOODS_NO,
                PL_GOODS_NAME = dto.PL_GOODS_NAME,
                PL_SELL_PRICE = dto.PL_SELL_PRICE,
                PL_PROMO_PRICE = dto.PL_PROMO_PRICE,
                PL_INNER_PRICE = dto.PL_INNER_PRICE,
                PL_CLAIM_PRICE = dto.PL_CLAIM_PRICE,
                PL_SDATE = dto.PL_SDATE,
                PL_EDATE = dto.PL_EDATE,
                PL_UDF1 = dto.PL_UDF1,
                PL_UDF2 = dto.PL_UDF2,
                PL_UDF3 = dto.PL_UDF3,
                PL_UDF4 = dto.PL_UDF4,
                PL_UDF5 = dto.PL_UDF5,
                DEL_FLAG = dto.DEL_FLAG,
                BG_NO = dto.BG_NO
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        public static MdmGoodsSplDto ToDto( this MdmGoodsSpl entity ) {
             if( entity == null )
                return new MdmGoodsSplDto();
            return new MdmGoodsSplDto {
                Id = entity.Id,
                PL_BUYER_NO = entity.PL_BUYER_NO,      
                PL_BUYER_NAME = entity.PL_BUYER_NAME,      
                PL_BUYER_TYPE = entity.PL_BUYER_TYPE,      
                PL_SELLER_NO = entity.PL_SELLER_NO,      
                PL_SELLER_NAME = entity.PL_SELLER_NAME,      
                PL_SELLER_TYPE = entity.PL_SELLER_TYPE,      
                PL_GOODS_NO = entity.PL_GOODS_NO,      
                PL_GOODS_NAME = entity.PL_GOODS_NAME,      
                PL_SELL_PRICE = entity.PL_SELL_PRICE,      
                PL_PROMO_PRICE = entity.PL_PROMO_PRICE,      
                PL_INNER_PRICE = entity.PL_INNER_PRICE,      
                PL_CLAIM_PRICE = entity.PL_CLAIM_PRICE,      
                PL_SDATE = entity.PL_SDATE,      
                PL_EDATE = entity.PL_EDATE,      
                PL_UDF1 = entity.PL_UDF1,      
                PL_UDF2 = entity.PL_UDF2,      
                PL_UDF3 = entity.PL_UDF3,      
                PL_UDF4 = entity.PL_UDF4,      
                PL_UDF5 = entity.PL_UDF5,      
                DEL_FLAG = entity.DEL_FLAG,      
                BG_NO = entity.BG_NO
            };
        }
    }
}