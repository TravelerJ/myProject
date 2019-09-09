using SCRM.Domain.MallManagement.Entitys;

namespace SCRM.Application.MallManagement.Dtos
{
    /// <summary>
    /// 数据传输对象扩展
    /// </summary>
    public static class TxnSoDetDtoExtension {    
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static TxnSoDet ToEntity( this TxnSoDetDto dto ) {
            if( dto == null )
                return new TxnSoDet();
            return new TxnSoDet() {
                Id = dto.Id,
                SO_NO = dto.SO_NO,
                ACTIVITY_NO = dto.ACTIVITY_NO,
                GOODS_NO = dto.GOODS_NO,
                GOODS_NAME = dto.GOODS_NAME,
                GOODS_DESC = dto.GOODS_DESC,
                PROBLEM_DESC = dto.PROBLEM_DESC,
                GOODS_TYPE = dto.GOODS_TYPE,
                QTY = dto.QTY,
                PRICE = dto.PRICE,
                AMOUNT = dto.AMOUNT,
                EXEMPT_AMT = dto.EXEMPT_AMT,
                DISCOUNT_TYPE = dto.DISCOUNT_TYPE,
                DISCOUNT_RATE = dto.DISCOUNT_RATE,
                DISCOUNT_AMT = dto.DISCOUNT_AMT,
                YS_AMT = dto.YS_AMT,
                PAY_MODE = dto.PAY_MODE,
                SELL_TYPE = dto.SELL_TYPE,
                PAY_TYPE = dto.PAY_TYPE,
                SALE_PSN = dto.SALE_PSN,
                WH_ID = dto.WH_ID,
                WH_NAME = dto.WH_NAME,
                LC_ID = dto.LC_ID,
                LC_NAME = dto.LC_NAME,
                IS_WORKING = dto.IS_WORKING,
                IS_MATERIAL_GI = dto.IS_MATERIAL_GI,
                IS_GOODS_COMBO = dto.IS_GOODS_COMBO,
                IS_TEMP_BUY = dto.IS_TEMP_BUY,
                DAMAGE_GRADE_RATE = dto.DAMAGE_GRADE_RATE,
                PAINT_AREA_RATE = dto.PAINT_AREA_RATE,
                PAINT_PART_RATE = dto.PAINT_PART_RATE,
                GET_SCORE = dto.GET_SCORE,
                NEED_SCORE = dto.NEED_SCORE,
                REMARK = dto.REMARK,
                SERVICE_NO = dto.SERVICE_NO,
                MAINTAIN_CLASS = dto.MAINTAIN_CLASS,
                MAINTAIN_SUBCLASS = dto.MAINTAIN_SUBCLASS,
                PRICE_PARA = dto.PRICE_PARA,
                GOODS_LARGECLASS = dto.GOODS_LARGECLASS,
                GOODS_INCLASS = dto.GOODS_INCLASS,
                GOODS_SMALLCLASS = dto.GOODS_SMALLCLASS,
                FROM_ORG_NO = dto.FROM_ORG_NO,
                ENGINEER_ID = dto.ENGINEER_ID,
                ENGINEER_NAME = dto.ENGINEER_NAME,
                REL_QTY = dto.REL_QTY,
                IS_SP_UPGRADE = dto.IS_SP_UPGRADE,
                WORK_MH = dto.WORK_MH,
                ASSGIN_TEAM = dto.ASSGIN_TEAM,
                WORK_STATION = dto.WORK_STATION,
                STD_WORK_TIME = dto.STD_WORK_TIME,
                S_PAY_QTY = dto.S_PAY_QTY,
                IS_COMBO_SERVICE = dto.IS_COMBO_SERVICE,
                DC_COUPON = dto.DC_COUPON,
                IS_ADD = dto.IS_ADD,
                ROW_SN = dto.ROW_SN,
                DATA_FLAG = dto.DATA_FLAG,
                DEL_FLAG = dto.DEL_FLAG,
                BG_NO = dto.BG_NO
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        public static TxnSoDetDto ToDto( this TxnSoDet entity ) {
             if( entity == null )
                return new TxnSoDetDto();
            return new TxnSoDetDto {
                Id = entity.Id,
                SO_NO = entity.SO_NO,      
                ACTIVITY_NO = entity.ACTIVITY_NO,      
                GOODS_NO = entity.GOODS_NO,      
                GOODS_NAME = entity.GOODS_NAME,      
                GOODS_DESC = entity.GOODS_DESC,      
                PROBLEM_DESC = entity.PROBLEM_DESC,      
                GOODS_TYPE = entity.GOODS_TYPE,      
                QTY = entity.QTY,      
                PRICE = entity.PRICE,      
                AMOUNT = entity.AMOUNT,      
                EXEMPT_AMT = entity.EXEMPT_AMT,      
                DISCOUNT_TYPE = entity.DISCOUNT_TYPE,      
                DISCOUNT_RATE = entity.DISCOUNT_RATE,      
                DISCOUNT_AMT = entity.DISCOUNT_AMT,      
                YS_AMT = entity.YS_AMT,      
                PAY_MODE = entity.PAY_MODE,      
                SELL_TYPE = entity.SELL_TYPE,      
                PAY_TYPE = entity.PAY_TYPE,      
                SALE_PSN = entity.SALE_PSN,      
                WH_ID = entity.WH_ID,      
                WH_NAME = entity.WH_NAME,      
                LC_ID = entity.LC_ID,      
                LC_NAME = entity.LC_NAME,      
                IS_WORKING = entity.IS_WORKING,      
                IS_MATERIAL_GI = entity.IS_MATERIAL_GI,      
                IS_GOODS_COMBO = entity.IS_GOODS_COMBO,      
                IS_TEMP_BUY = entity.IS_TEMP_BUY,      
                DAMAGE_GRADE_RATE = entity.DAMAGE_GRADE_RATE,      
                PAINT_AREA_RATE = entity.PAINT_AREA_RATE,      
                PAINT_PART_RATE = entity.PAINT_PART_RATE,      
                GET_SCORE = entity.GET_SCORE,      
                NEED_SCORE = entity.NEED_SCORE,      
                REMARK = entity.REMARK,      
                SERVICE_NO = entity.SERVICE_NO,      
                MAINTAIN_CLASS = entity.MAINTAIN_CLASS,      
                MAINTAIN_SUBCLASS = entity.MAINTAIN_SUBCLASS,      
                PRICE_PARA = entity.PRICE_PARA,      
                GOODS_LARGECLASS = entity.GOODS_LARGECLASS,      
                GOODS_INCLASS = entity.GOODS_INCLASS,      
                GOODS_SMALLCLASS = entity.GOODS_SMALLCLASS,      
                FROM_ORG_NO = entity.FROM_ORG_NO,      
                ENGINEER_ID = entity.ENGINEER_ID,      
                ENGINEER_NAME = entity.ENGINEER_NAME,      
                REL_QTY = entity.REL_QTY,      
                IS_SP_UPGRADE = entity.IS_SP_UPGRADE,      
                WORK_MH = entity.WORK_MH,      
                ASSGIN_TEAM = entity.ASSGIN_TEAM,      
                WORK_STATION = entity.WORK_STATION,      
                STD_WORK_TIME = entity.STD_WORK_TIME,      
                S_PAY_QTY = entity.S_PAY_QTY,      
                IS_COMBO_SERVICE = entity.IS_COMBO_SERVICE,      
                DC_COUPON = entity.DC_COUPON,      
                IS_ADD = entity.IS_ADD,      
                ROW_SN = entity.ROW_SN,      
                DATA_FLAG = entity.DATA_FLAG,      
                DEL_FLAG = entity.DEL_FLAG,      
                BG_NO = entity.BG_NO
            };
        }
    }
}